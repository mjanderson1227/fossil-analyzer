<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Gochi+Hand&family=Press+Start+2P&display=swap" rel="stylesheet">   
</svelte:head>

<script lang='ts'>
   import logo from '$lib/img/fossil-illustration-2-svgrepo-com.svg'
</script>

<div class='header'>
    <a
    <img src={logo} alt="logo"/>
    <h1>WHAT THE DINO?!</h1>  
</div>

  


<style>
    :global(body){
        height:100vh;
        background: linear-gradient(135deg, #1F2033, #4F505C)
    }
    
   
    .header
    {
        font-family: 'Press Start 2P';
        color:white;
        font-size:2rem;
        
    }
   
    


</style>