<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Gochi+Hand&family=Press+Start+2P&display=swap" rel="stylesheet">   
</svelte:head>

<script lang='ts'>
    let colors = [
		"#4F505C",
		"#272833"
	]
	let degstring = '45deg'
</script>

<nav> 
    <a href="/">home</a>
</nav>
<h1> Results:</h1>
<div

></div>

<style>
    :global(body){
        height:100vh;
        background: linear-gradient(135deg, #1F2033, #4F505C)
    }
    
    
    h1
    {
        font-family: 'Press Start 2P';
        color:white
    }


</style>