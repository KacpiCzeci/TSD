<template>
    <div>
        <h2>Add new Todo</h2>
        <div>
            <p>Title: <input v-model="title" type="text"></p>
            <div>
                <label for="done">Done</label>
                <input type="checkbox" v-model="done" class="done">
            </div>
            <button v-on:click="onAddClick">Add</button>
        </div>
    </div>
</template>

<script>
export default {
    name: 'AddNewTodoView',
    data() {
        return {
            title: '',
            done: false,
        }
    },
    methods: {
        onAddClick() {
            if(this.title != ''){
                this.$store.dispatch('addTodo', {title: this.title, done: this.done});
                this.$emit('onAddClick', 'Added new task!');
                this.$router.push('/');
            }
        }
    }
}
</script>
