<template>
    <div>
        <h2>Add new Todo</h2>
        <div>
            <p>Title: <input v-model="title" type="text"></p>
            <button v-on:click="onAddClick">Add</button>
        </div>
    </div>
</template>

<script>
import { store } from '../store/store.js';

export default {
    name: 'AddNewTodoView',
    data() {
        return {
            title: '',
            store,
        }
    },
    methods: {
        onAddClick() {
            if(this.title != ''){
                store.addTodo(this.title);
                this.$emit('onAddClick', 'Added new task!');
                this.$router.push('/');
            }
        }
    }
}
</script>
