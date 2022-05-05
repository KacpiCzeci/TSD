<template>
    <div>
        <p>{{ text }}</p>
        <button v-on:click="deleteTodo">Delete</button>
    </div>
</template>

<script>
import { store } from '../store/store.js';

export default {
    name: 'DetailsView',
    data() {
        return {
            text: store.getTodo(this.$route.params.id).text,
            id: store.getTodo(this.$route.params.id).id,
        }
    },
    methods: {
        deleteTodo() {
            store.deleteTodo(this.id);
            this.$emit('deleteTodo', 'Deleted task!');
            this.$router.push('/');
        }
    }
}
</script>