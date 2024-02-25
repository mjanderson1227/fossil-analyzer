<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Delicious+Handrawn&display=swap" rel="stylesheet">
</svelte:head>
<script>
    //put your js here

</script>

<sticky class='sticky'>
    <div class='head'>Results</div>
    <div class='guesses'> 
        <ul>guess 1:</ul>
        <ul>guess 2:</ul>
        <ul>guess 3:</ul>
    </div>
</sticky>

<style>
    .sticky{
        font-family: 'Delicious Handrawn';
    }
    
    .head {
        font-size: 3rem;
        text-align: center;
    }

    .guesses{
        font-size: 2rem;
        list-style-type: circle;
        text-align: left;
    }

</style>