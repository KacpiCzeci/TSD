<template>
    <div class="container">
        <div class="subcontainer">
            <div class="title">
                <p class="p1">404</p>
            </div>
            <div class="text">
                <p class="p2">NOT FOUND</p>
            </div>
        </div>
    </div>
</template>

<style>
    .container {
        width: 100%;
        height: 100%;
        display: flex;
    }

    .subcontainer {
        width: 100%;
        display: flex;
        flex-direction: column;
        justify-content: center;
    }

    .title {
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    .text {
        display: flex;
        flex-direction: column;
        align-self: center;
    }

    .p1 {
        font-family: bold 1em;
        font-weight: 600;
        font-size: 100px;
        color: #42b983;
        margin: 0px 30px 0px 30px;
    }

    .p2 {
        font-family: bold 1em;
        font-weight: 600;
        font-size: 30px;
        color: #2c3e50;
        margin: 0px 30px 0px 30px;
    }
</style>