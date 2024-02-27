using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using static System.Guid;

namespace MLModel1_ConsoleApp1;

internal struct DinoGuess
{
    internal string species;
    internal string part;
    internal double score;
    internal string summary;
    internal string[] questions;
    internal string questionReply;

    public DinoGuess()
    {
        species = "Dinosaur";
        part = "Bone";
        score = 0;
        summary = "Generating…";
        questions = new[] { "Generating…", "Generating…", "Generating…" };
        questionReply = "Generating…";
    }
}

internal abstract class Program
{
    private static Dictionary<string, DinoGuess> activeDinos;
    private static bool llamaWaiting;

    public static void Check(byte[] image, string uid)
    {
        var sampleData = new MLModel1.ModelInput
        {
            ImageSource = image
        };
        var sortedScoresWithLabel = MLModel1.PredictAllLabels(sampleData);
        var i = 0;
        foreach (var pair in sortedScoresWithLabel)
        {
            if (i < 3)
            {
                var dinoPart = pair.Key.Split("-");
                var tmp = new DinoGuess();
                tmp.species = dinoPart[0];
                tmp.part = dinoPart[1];
                tmp.score = pair.Value;
                Console.WriteLine("SCOREEEEEEEEEEEEEEEEEEEEEE " + tmp.score);
                var tmpId = uid;
                if (i != 0)
                    tmpId += i;
                activeDinos[tmpId] = tmp;
            }
            else
            {
                break;
            }

            i++;
        }

        //    for (i = 0; i < 3; i++)
        //       Console.WriteLine("I am " + (int)(scoreGuesses[i] * 100d) + "% sure this is a " + partGuesses[i] +
        //                         " from a " + dinoGuesses[i]);
    }

    public static void Main(string[] args)
    {
        //askLlama("Hello");
        //Check(File.ReadAllBytes("C:\\Users\\stick\\Desktop\\data.png"));
        llamaWaiting = false;
        activeDinos = new Dictionary<string, DinoGuess>();
        //  askLlama("Who is Joe Biden?");


        //   Console.WriteLine(t.Result);
        SimpleListenerExample();
        try
        {
        }
        catch (Exception e)
        {
            //seriously dont care
        }
    }

    private static async Task<byte[]> generateDinoPic(string dinoPart)
    {
        var api = new Uri(
            "https://api.cloudflare.com/client/v4/accounts/86d4bfc229ec47c8fcc5bafd928e2696/ai/run/@cf/stabilityai/stable-diffusion-xl-base-1.0");
        var cli = new HttpClient();
        cli.DefaultRequestHeaders.Add("Authorization", "Bearer NgUH61k9ltDY7M9kVuPJoBaEpA3BVraSXv-7Zgi9");
        var json = JsonConvert.SerializeObject(new
        {
            prompt = dinoPart,
            num_steps = 50
        });
        var response = await cli.PostAsync(api, new StringContent(json));
        var reply = await response.Content.ReadAsByteArrayAsync();
        return reply;
    }

    public static void SimpleListenerExample()
    {
        var listener = new HttpListener();
        listener.Prefixes.Add("http://+:81/dino/");
        listener.Prefixes.Add("http://+:81/chat/");
        listener.Prefixes.Add("http://+:81/image/");
        listener.Start();
        //   Console.WriteLine("Ready!");
        while (true)
        {
            var context = listener.GetContext();
            var request = context.Request;
            var response = context.Response;
            var responseString = "get out illegal request lol";
            var body = request.InputStream;
            var encoding = request.ContentEncoding;
            var reader = new StreamReader(body, encoding);
            byte[] buffer = { };
            //   Console.WriteLine("we got here");
            if (request.Url.ToString().Contains("image"))
            {
                if (request.Headers["session"] is not null)
                {
                    var dino = activeDinos[request.Headers["session"]];
                    var t = generateDinoPic("Draw the "+dino.part+" of a "+dino.species+" in an x-ray. Draw sketchbook-style.");
                    while (!t.IsCompleted) Thread.Sleep(10);
                    buffer = t.Result;
                    //Console.WriteLine("we sent " +buffer.Length);
                    response.Headers.Add("Content-Type", "image/png");
                    responseString = null;
                }
            }
            else if (request.Url.ToString().Contains("dino"))
            {
                //    if (request.ContentType != null) Console.WriteLine("Client data content type {0}", request.ContentType);
                var s = reader.ReadToEnd();
                //File.WriteAllText("C:\\users\\stick\\desktop\\data.png", s);
                var image = Convert.FromBase64String(s);
                if (!request.HasEntityBody)
                    // Console.WriteLine("omg no body " + image.Length);
                    return;

                var dinoID = NewGuid().ToString();
                Check(image, dinoID);
                responseString = buildDinoResponseString(dinoID);
                new Thread(() => { generateSummary(dinoID); }).Start();
            }
            else if (request.Url.ToString().Contains("chat"))
            {
                if (request.Headers["session"] is not null && request.Headers["message"] is not null)
                {
                    string prompt;
                    var sessionID = request.Headers["session"];
                    var message = request.Headers["message"];
                    if (activeDinos.ContainsKey(sessionID))
                    {
                        var activeDino = activeDinos[sessionID];
                        if (message != "hello")
                        {
                            prompt =
                                "Do not provide any URLs or talk about anything else besides dinosaurs. \nIn the context of a " +
                                activeDino.species + " " + activeDino.part + ": " + message +
                                "\nRespond in ONLY ONE sentence.";
                            activeDino.questionReply = askLlama(prompt);
                            activeDinos[sessionID] = activeDino;
                        }

                        responseString = buildChatResponseString(sessionID);
                    }
                }
            }

            if (responseString is not null) buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Flush();
            //    Console.WriteLine("Processed request. Took " + (Now.ToUnixTimeMilliseconds() - startTime) + " ms");
            output.Close();
        }
    }

    private static void generateSummary(string guid)
    {
        var activeDino = activeDinos[guid];
        var prompt = "Hi, this is an API!";
        var summary = "This is the summary";
        var questions = new string[3];
        prompt =
            "Do not provide any URLs or talk about anything else besides dinosaurs. \nGive a 3-sentence summary of a " +
            activeDino.species + " " + activeDino.part +
            ". \nAlso, provide 3 potential followup questions, very brief, for me to ask you. \nAlways format your response like this: \nRESPONSE: <your response> \nQUESTIONS: Q1:<Q1> Q2:<Q2> Q3:<Q3>";
        var msg = askLlama(prompt);
        summary = msg.Substring(0, msg.IndexOf("QUESTIONS"));
        summary = summary.Replace("RESPONSE:", "");
        summary = summary.Trim();
        activeDino.summary = summary;
        Console.WriteLine("----summary-----\n" + summary + "\n----summary-----");
        activeDinos[guid] = activeDino;
        //      Console.Write(".....done\ngenerating questions.....");
        for (var i = 0; i < 3; i++)
        {
            //           Console.Write("Q" + (i + 1) + "......");
            var startInd = msg.IndexOf("Q" + (i + 1) + ": ") + 3;
            var question = msg.Substring(startInd);
            question = question.Substring(0, i == 2 ? question.Length : question.IndexOf('\n'));
            question = question.Trim();
            questions[i] = askLlama(
                "Simply this question down to a single short sentence in the form of a question. PARAPHRASE TO FIVE WORDS!! DO NOT INCLUDE ANYTHING IN YOUR RESPONSE BESIDES MY QUESTION!! ---- THE QUESTION:    \n" +
                question);
            questions[i] = questions[i].Replace("/", " or ");
            var rgx = new Regex("[^a-zA-Z0-9 -]");
            questions[i] = rgx.Replace(questions[i], "") + "?";
        }

        activeDino.questions = questions;
        activeDinos[guid] = activeDino;
        //   Console.WriteLine("ASYNC TASK DONE ASSHOLE. HERE IS THE FUCKING DINOSAUR::\n"+activeDinos[guid].summary);
    }

    private static string buildDinoResponseString(string uid)
    {
        var dinos = new
        {
            guess0 = new
            {
                activeDinos[uid].species,
                bone = activeDinos[uid].part,
                activeDinos[uid].score
            },
            guess1 = new
            {
                activeDinos[uid + 1].species,
                bone = activeDinos[uid + 1].part,
                activeDinos[uid + 1].score
            },
            guess2 = new
            {
                activeDinos[uid + 2].species,
                bone = activeDinos[uid + 2].part,
                activeDinos[uid + 2].score
            },
            session = uid
        };
        return JsonConvert.SerializeObject(dinos);
    }

    private static string buildChatResponseString(string guid)
    {
        var dino = activeDinos[guid];
        var chatResponse = new
        {
            dino.summary,
            followup0 = dino.questions[0],
            followup1 = dino.questions[1],
            followup2 = dino.questions[2],
            answer = dino.questionReply
        };
        return JsonConvert.SerializeObject(chatResponse);
    }


    private static async Task<string> llamaCompute(string msg)
    {
        var proc = new Process();
        var setup = new ProcessStartInfo();
        setup.FileName = "ollama";
        setup.ArgumentList.Add("run");
        setup.ArgumentList.Add("llama2:chat");
        setup.ArgumentList.Add("--nowordwrap");
        setup.ArgumentList.Add(msg);
        setup.UseShellExecute = false;
        setup.RedirectStandardOutput = true;
        setup.CreateNoWindow = true;
        proc.StartInfo = setup;
        proc.Start();
        var dataStream = proc.StandardOutput;
        proc.WaitForExit();
        return await dataStream.ReadToEndAsync();
    }

    private static string askLlama(string msg)
    {
        /*
            if (llamaWaiting)
                Thread.Sleep(500);
            llamaWaiting = true;*/
        var outP = llamaCompute(msg);
        outP.Wait();
        var reply = outP.Result;
        //     Console.WriteLine("------------ llama");
        //     Console.WriteLine(reply);
        //      Console.WriteLine("------------ llama");
        //  llamaWaiting = false;
        return reply.Trim();
    }
}