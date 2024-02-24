<script lang="ts">
    import logo from '$lib/img/image_photo_icon.png';
    import file from '$lib/img/file_folder.png';

    let  avatar, fileinput;
	
	const onFileSelected =(e)=>{
  let image = e.target.files[0];
            let reader = new FileReader();
            reader.readAsDataURL(image);
            reader.onload = e => {
                 avatar = e.target.result
            };
}
</script>



<div id="app" >

    <h1><strong>Get Boned</strong></h1>
    <hr width="25%" color="bc6c25"/>
    <h2>Upload a fossil  for analysis</h2>
    <div id="drag_box">
    {#if avatar}
        <img class="avatar" src="{avatar}" alt="d" />
        {:else}
        <img class="avatar" src="{logo}" alt="" />

        {/if}

        </div>
				<img class="upload" src={file} alt="" on:click={()=>{fileinput.click();}} />
        <div class="chan" on:click={()=>{fileinput.click();}}>Choose Image</div>
        <input style="display:none" type="file" accept=".jpg, .jpeg, .png" on:change={(e)=>onFileSelected(e)} bind:this={fileinput} >

</div>

<style>
    :global(body) {
        height: 100vh;
        background: linear-gradient(360deg ,#283618, #FEFAE0);
    }
    #drag_box {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 400px;
        width: 550px;
        border: 4px dashed #BC6C25;
        border-radius: 10px;
        margin: 10px;


    }
	#app{
	display:flex;
		align-items:center;
		justify-content:center;
		flex-flow:column;

}
 
	.upload{
		display:flex;
	    height:50px;
		width:50px;
		cursor:pointer;
	}
    .upload:hover{
        transform: scale(1.1);
    }
	.avatar{
		display:flex;
		height:300px;
		width:300px;
	}
    h1 {
        color: #BC6C25;
    }
    h2 {
        color: #283618;
    }
    .chan {
        color: #BC6C25;
    }
    .chan:hover {
        color: #283618;
        cursor: pointer;
    }
</style>

 