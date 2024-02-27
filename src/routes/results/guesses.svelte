<script lang="ts">
    import type {ModelResponse} from "./types";

    export let listData: ModelResponse;
    const values: any = Object.values(listData).slice(0, 3);
</script>

<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link
        href="https://fonts.googleapis.com/css2?family=Delicious+Handrawn&display=swap"
        rel="stylesheet"
    />
</svelte:head>

<sticky class="guesses">
    <div class="head">Results:</div>
    {#each values as entry}
        {entry.species}
        {entry.bone}<br/>
        <center>{Math.floor(entry.score * 100)}% match</center>
    {/each}
</sticky>

<style>
    .head {
        font-size: 5vh;
        text-align: center;
    }

    .guesses {
        font-family: "Delicious Handrawn";
        font-size: 3.5vh;
        list-style-type: circle;
        text-align: left;
    }
</style>
