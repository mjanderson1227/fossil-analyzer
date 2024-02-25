<script lang="ts">
    import type { ModelResponse } from "./types";

    // Variable is loaded from the server
    export let data: ModelResponse;

    import Sticky from "./guesses.svelte";
    import Pg1 from "./journalpg1.svelte";
</script>

<div class="wrapper">
    <div class="logo"></div>
    <div class="header"><h1><strong>What the Dino?!</strong></h1></div>
    <div class="guesses"><Sticky /></div>
    <div class="journal_page">
        <div class="pg1"><Pg1 /></div>
    </div>
</div>

<div class="wrapper">
    <div class="logo"></div>
    <div class="header"><h1><strong>What the Dino?!</strong></h1></div>
    <div class="guesses"></div>
    <div class="journal-page"></div>
</div>

<style>
    :global(body) {
        height: 140vh;
        width: 90vw;
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
        grid-row: 1;
        height: 1;
        width: 10vw;

        background-image: url($lib/img/fossil-illustration-2-svgrepo-com.svg);
        background-size: cover;
        background-position: center center;
        background-repeat: no-repeat;
    }
    .header {
        grid-column: 2/6;
        grid-row: 1;
    }
    .guesses {
        grid-column: 1/6;
        grid-row: 2;
        height: 20rem;
        width: 20rem;
        margin-top: 10rem;
        margin-left: 1rem;
        background-color: blanchedalmond;
        background-position: center center;
    }
    .journal-page {
        grid-column: 6/8;
        grid-row: 2;
        height: 60em;
        width: 65em;

        background-image: url($lib/img/journal.svg);
        background-size: cover;
        background-position: center bottom;
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
