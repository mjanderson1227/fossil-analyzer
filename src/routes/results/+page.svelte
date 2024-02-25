<script lang="ts">
    import type { ModelResponse } from "./types";
    import { onMount } from "svelte";

    // Variable is loaded from the server
    export let data: ModelResponse;

    onMount(() => {
        console.log(data);
    });

    import Guesses from "./guesses.svelte";
    import Pg1 from "./journalpg1.svelte";
</script>

<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link
        href="https://fonts.googleapis.com/css2?family=Gochi+Hand&family=Press+Start+2P&display=swap"
        rel="stylesheet"
    />
</svelte:head>

<div class="wrapper">
    <div class="logo"></div>
    <div class="header"><h1><strong>What the Dino?!</strong></h1></div>
    <div class="guesses"><Guesses listData={data} /></div>
    <div class="journal_page">
        <div class="pg1"><Pg1 /></div>
    </div>
</div>

<style>
    :global(body) {
        display: flex;
        align-items: left;
        justify-content: center;
        flex-flow: column;
        height: 100%;
        overflow: hidden;
        margin: 2% 0 15%;
        background-image: url($lib/img/background.svg);
        background-size: cover;
        background-position: center bottom;
        background-repeat: no-repeat;
    }
    .wrapper {
        display: grid;
    }
    .logo {
        grid-column: 1;
        grid-row: 1;
        height: 10vh;
        width: 10vh;
        margin-left: 2vw;
        margin-right: 2vw;
        background-image: url($lib/img/fossil-illustration-2-svgrepo-com.svg);
        background-size: 100%;
        background-position: center center;
        background-repeat: no-repeat;
    }
    .header {
        font-family: "Press Start 2P";
        grid-column: 2;
        grid-row: 1;
        vertical-align: center;
    }
    .guesses {
        grid-row-start: 2;
        grid-row-end: 4;
        grid-column-start: 4;
        grid-column-end: auto;
        height: 20vw;
        width: 20vw;
        margin-top: 40%;
        justify-content: center;
        background-color: blanchedalmond;
        background-size: contain;
    }
    .journal_page {
        grid-column-start: 1;
        grid-column-end: 4;
        grid-row-start: 2;
        height: 80vh;

        background-image: url($lib/img/journal.svg);
        background-size: contain;
        background-position: center;
        background-repeat: no-repeat;
        display: grid;
    }

    .pg1 {
        grid-column: 1;
        grid-row: 2;
    }

    h1 {
        color: #283618;
        font-family: "Press Start 2P";
    }
</style>
