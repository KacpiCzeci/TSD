<template>
    <div class="menu">
        <div v-for="i in items" :key="i._id" class="item">
            <a class="itemName" href="#" @click="onClick(i)">{{ i }}</a>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'MenuItems',
        props: {
            items: Array
        },
        methods: {
            onClick(name) {
                this.$emit('clicked', name);
            }
        }
    }
</script>

<style>
    .menu {
        display: flex;
        flex-direction: row;
    }

    .item{
        display: flex;
        justify-content: center;
        align-items: center;
        margin: 10px;
    }

    .item:hover {
        transform: scale(1.05);
        cursor: pointer;
    }
</style>