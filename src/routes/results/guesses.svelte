<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Delicious+Handrawn&display=swap" rel="stylesheet">
</svelte:head>
<script>
    let match0 = .97;
    let match1 = .02;
    let match2 = .01;
    

</script>

<sticky class='guesses'>
    <div class='head'>Results:</div>
    Stegosaurus Femur<br><center>97% match</center>
            Velociraptor Skull<br><center>2% match</center>
            Tyrannosaurus Rex Ribs<br><center>1% match</center>
</sticky>

<style>

    
    .head {
        font-size: 3rem;
        text-align: center;
    }

    .guesses{
        font-family: 'Delicious Handrawn';
        font-size: 2rem;
        list-style-type: circle;
        text-align: left;
    
    }

</style>