<template>
    <div>
        <p>{{ todo.title }}</p>
        <p v-if="todo.details != ''">{{ todo.details }}</p>
        <p v-else>No details provided</p>
        <div>
            <label for="done">Done</label>
            <input type="checkbox" v-model="todo.completed" class="done" v-on:change="updateTodo">
        </div>
        <button v-on:click="deleteTodo">Delete</button>
    </div>
</template>

<script>
export default {
    name: 'DetailsView',
    data() {
        return {
            todo: this.$store.getters.getTodo(this.$route.params.id),
        }
    },
    methods: {
        updateTodo(){
            this.$store.dispatch('updateTodo', {id: this.todo.id, done: this.todo.completed});
        },
        deleteTodo() {
            this.$store.dispatch('deleteTodo', this.todo.id);
            this.$emit('deleteTodo', 'Deleted task!');
            this.$router.push('/');
        }
    }
}
</script>