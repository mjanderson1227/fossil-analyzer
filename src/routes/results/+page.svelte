<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Gochi+Hand&family=Press+Start+2P&display=swap" rel="stylesheet">   
</svelte:head>

<script lang='ts'>
  
   
</script>

    

    <div class="wrapper">
        <div class='logo'></div>
        <div class='header'><h1><strong>What the Dino?!</strong></h1></div>
        <div class='guesses'></div>
        <div class='journal_page'> </div>
    </div>
      



<style>
    :global(body){
        
        height:100vh;
        /*background: linear-gradient(135deg, #1F2033, #4F505C)*/
        background-image: url($lib/img/background.svg);
        background-size: cover;
        background-position: center bottom;
        background-repeat: no-repeat;

    }
    .wrapper {
        display: grid;
  
        height: 100vh;
        width: 50vw;
        
    }
    .logo {
        grid-column: 1;
        grid-row:1;
        height: 18vh;
        width: 10vw;
        
        background-image: url($lib/img/fossil-illustration-2-svgrepo-com.svg);
        background-size: cover;
        background-position: center center;
        background-repeat: no-repeat;
    }
    .header {
        grid-column: 2/6;
        grid-row:1
    }
    .guesses {
        grid-column: 1/6;
        grid-row: 2;
        height:20rem;
        width:20rem;
        margin-top: 10rem;
        margin-left: 1rem;
        background-color:blanchedalmond;
        background-position: center center;
    }
    .journal_page {
        grid-column: 6/8;
        grid-row: 2;
        height: 120vh;
        width: 75vw;
        background-image: url($lib/img/journal.svg);
        background-size: cover;
        background-position: center bottom;
        background-repeat: no-repeat;
    }
   
   
    
    h1 {
        color: #283618;
        font-family: "Press Start 2P";
    }
   

    
    :focus-visible {
        outline-offset: 1px;
    }

  



   
    .title-bar > h1 {
        text-shadow: 2px 2px black;
        color: #283618;
        margin: 0;
        font-size: 2rem;
        float: left
    }
    

