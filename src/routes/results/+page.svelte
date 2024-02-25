<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Gochi+Hand&family=Press+Start+2P&display=swap" rel="stylesheet">   
</svelte:head>

<script lang='ts'>
   import logo from '$lib/img/fossil-illustration-2-svgrepo-com.svg'
   import background from "$lib/img/background.svg";
</script>


    <div id="app">
        <div class="title-bar">
            <h1><strong>What the Dino?!</strong></h1>
        </div>
<!--        <img src={logo} alt="logo"/>-->
        <div id="journal_page">


            </div>

</div>>

<style>
    :global(body){
        display: flex;
        align-items: center;
        justify-content: center;
        flex-flow: column;
        height:100vh;
        /*background: linear-gradient(135deg, #1F2033, #4F505C)*/
        background-image: url($lib/img/background.svg);
        background-size: cover;
        background-position: center bottom;
        background-repeat: no-repeat;

    }
    #journal_page {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 75vh;
        width: 50vw;
        background-image: url($lib/img/journal.svg);
        background-size: cover;
        background-position: center bottom;
        background-repeat: no-repeat;
    }
   
    .header
    {
        font-family: 'Press Start 2P';
        color:white;
        font-size:2rem;
        
    }
    .title-bar > h1 {
    }
    h1 {
        color: #283618;
        font-family: "Press Start 2P";
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
        gap: 8px;
        justify-content: center;
        line-height: 1.5;
        overflow: hidden;
        padding: 12px 16px;
        text-decoration: none;
        text-overflow: ellipsis;
        transition: all 0.14s ease-out;
        white-space: nowrap;

        font-size: 25px;
        color: white;
        height: 90px;
        font-family: "VT323";

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
        transform: translate(-4px, -4px);
    }
    :focus-visible {
        outline-offset: 1px;
    }

    .pixel2 {
        clip-path: polygon(
                0px calc(100% - 20px),
                4px calc(100% - 20px),
                4px calc(100% - 12px),
                8px calc(100% - 12px),
                8px calc(100% - 8px),
                12px calc(100% - 8px),
                12px calc(100% - 4px),
                20px calc(100% - 4px),
                20px 100%,
                calc(100% - 20px) 100%,
                calc(100% - 20px) calc(100% - 4px),
                calc(100% - 12px) calc(100% - 4px),
                calc(100% - 12px) calc(100% - 8px),
                calc(100% - 8px) calc(100% - 8px),
                calc(100% - 8px) calc(100% - 12px),
                calc(100% - 4px) calc(100% - 12px),
                calc(100% - 4px) calc(100% - 20px),
                100% calc(100% - 20px),
                100% 20px,
                calc(100% - 4px) 20px,
                calc(100% - 4px) 12px,
                calc(100% - 8px) 12px,
                calc(100% - 8px) 8px,
                calc(100% - 12px) 8px,
                calc(100% - 12px) 4px,
                calc(100% - 20px) 4px,
                calc(100% - 20px) 0px,
                20px 0px,
                20px 4px,
                12px 4px,
                12px 8px,
                8px 8px,
                8px 12px,
                4px 12px,
                4px 20px,
                0px 20px
        );
        font-family: "Press Start 2P";
        text-transform: uppercase;
        font-size: 2rem;
        color: white;
        padding: 10px 10px;
        background: black;
        width: 550px;
        z-index: 2;
        border: 2px black;
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
    .submit-flex {
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .title-bar > h1 {
        text-shadow: 5px 5px black;
        color: #283618;
        margin: 0;
        font-size: 4rem;
    }
    


</style>