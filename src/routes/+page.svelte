<script lang="ts">
    import logo from "$lib/img/image_photo_icon.png";
    import file from "$lib/img/file_folder.png";

    let avatar: string, fileinput: HTMLInputElement;

    const onFileSelected = (
        e: Event & { currentTarget: EventTarget & HTMLInputElement },
    ) => {
        const files = (e.target as HTMLInputElement).files;

        if (!files) return;

        let image = files[0];

        let reader = new FileReader();
        reader.readAsDataURL(image);
        reader.onload = (e) => {
            const stringResult = e.target?.result?.toString();
            if (stringResult) {
                avatar = stringResult;
            }
        };
    };
    let avatar: string | ArrayBuffer | null;
    let fileinput: string | undefined;

	const onFileSelected =(e)=>{
  let image = e.target.files[0];
            let reader = new FileReader();
            reader.readAsDataURL(image);
            reader.onload = e => {
                 avatar = e.target.result
            };
}
</script>

<div id="app">
    <h1><strong>Get Boned</strong></h1>
    <hr />
    <h2>Upload a fossil for analysis</h2>
    <div id="drag_box">
        {#if avatar}
            <img class="avatar" src={avatar} alt="d" />


<div id="app" >

    <h1><strong>What the Dino?!</strong></h1>
    <hr width="25%" color="bc6c25"/>
<!--    <h2>Upload a fossil  for analysis</h2>-->
    <div id="drag_box" on:click={()=>{fileinput.click();}}>
    {#if avatar}
        <img class="avatar" src="{avatar}" alt="d" />
        {:else}
            <img class="avatar" src={logo} alt="" />
        <img class="avatar" src="{logo}" alt="" />
        {/if}
    </div>
    <img
        class="upload"
        src={file}
        alt=""
        on:click={() => {
            fileinput.click();
        }}
    />
    <div
        class="chan"
        on:click={() => {
            fileinput.click();
        }}
    >
        Choose Image
    </div>
    <input
        style="display:none"
        type="file"
        accept=".jpg, .jpeg, .png"
        on:change={(e) => onFileSelected(e)}
        bind:this={fileinput}
    />

<!--				<img class="upload" src={file} alt="" on:click={()=>{fileinput.click();}} />-->
<!--        <div class="chan" on:click={()=>{fileinput.click();}}>Choose Image</div>-->
        <input style="display:none" type="file" accept=".jpg, .jpeg, .png" on:change={(e)=>onFileSelected(e)} bind:this={fileinput} >
    </div>
    <div class="container">
        <div>
            <div class="pixel2">pixelated button #2<br/>with multiple lines</div>
        </div>
    </div>
</div>

<style>
    :global(body) {
        height: 100vh;
        background: linear-gradient(360deg, #283618, #fefae0);
    }
    #drag_box {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 300px;
        width: 550px;
        border: 4px dashed #bc6c25;
        border-radius: 10px;
        margin: 10px;


    }
    #app {
        display: flex;
        align-items: center;
        justify-content: center;
        flex-flow: column;
    }

    #app > hr {
        width: 25%;
        color: "bc6c25";
    }

    .upload {
        display: flex;
        height: 50px;
        width: 50px;
        cursor: pointer;
    }
    .upload:hover {
        transform: scale(1.1);
    }
    .avatar {
        display: flex;
        height: 300px;
        width: 300px;
    }
    h1 {
        color: #BC6C25;
        font-family: 'Press Start 2P';
        color: #bc6c25;
    }
    h2 {
        color: #283618;
        font-family: 'Press Start 2P';
    }
    .chan {
        color: #BC6C25;
        font-family: 'Press Start 2P';
        color: #bc6c25;
    }
    .chan:hover {
        color: #283618;
        cursor: pointer;
    }
    .container {
        margin: 50px;
        display: block;
        width: 400px;
        margin-left: auto;
        margin-right: auto;
        text-align: center;
    }

    .pixel2 {
        outline: 0;
        grid-gap: 8px;
        align-items: center;
        background: 0 0;
        border: 1px solid #000;
        border-radius: 4px;
        cursor: pointer;
        display: inline-flex;
        flex-shrink: 0;
        font-size: 16px;
        gap: 8px;
        justify-content: center;
        line-height: 1.5;
        overflow: hidden;
        padding: 12px 16px;
        text-decoration: none;
        text-overflow: ellipsis;
        transition: all .14s ease-out;
        white-space: nowrap;

        font-size: 25px;
        color: white;
        height: auto;
        margin: 10px;
        font-family: 'VT323';

        position: relative;
        display: inline-block;
        vertical-align: top;
        text-transform: uppercase;

        cursor: pointer;

        -webkit-touch-callout: none;
        -webkit-user-select: none;
        -khtml-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
    }

    .pixel2:active {
        top: 2px;
        box-shadow: 4px 4px 0 #000;
        transform: translate(-4px,-4px);


    }
    :focus-visible{
        outline-offset: 1px;
    }

    .pixel2 {
        position: relative;
        display: block;
        margin: 10px;
        font-family: 'VT323';
        text-transform: uppercase;

        font-size: 25px;
        color: white;
    }

    .pixel2::before {
        content: "";
        display: block;
        position: absolute;
        top: 10px;
        bottom: 10px;
        left: -10px;
        right: -10px;
        background: black;
        z-index: -1;
    }

    .pixel2::after {
        content: "";
        display: block;
        position: absolute;
        top: 4px;
        bottom: 4px;
        left: -6px;
        right: -6px;
        background: black;
        z-index: -1;
    }

    .pixel2 {
        padding: 10px 10px;
        position: relative;
        background: black;
        width: auto;
        z-index: 2;
    }

</style>

 
