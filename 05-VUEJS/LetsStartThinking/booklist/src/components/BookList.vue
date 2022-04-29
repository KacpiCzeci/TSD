<template>
    <div id="app">
        <div>
        <p>Title: <input v-model="title" type="text"/></p>
        <p>Is book read: <select v-model="isReadOfNewBook">
            <option value="bookRead">Yes</option>
            <option value="bookNotRead">No</option>
        </select>
        </p>
        <button v-on:click="onAddClick">Add</button>
        </div>
        <div v-for="b in books" :key="b._id" class="book">
            <p class="bookTitle">Title: {{ b.title }}</p>
            <p v-bind:class="b.isRead">Is Book Read: <span >{{ b.isRead }}</span></p>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'BookList',
        data() {
            return {
                books: [
                    { title: 'Thinking, fast and slow', isRead: 'bookRead' }, 
                    { title: 'Scrum Guide', isRead: 'bookNotRead' }, 
                ],
                title: '',
                isReadOfNewBook: 'bookNotRead'
            }
        },
        methods: {
                onAddClick() {
                    this.books.push({title: this.title, isRead: this.isReadOfNewBook})
                }
        },
    }
</script>

<style>
    .book{
        background-color: blanchedalmond;
    } 
    .bookTitle {
        font-weight: bold;
    }
    .bookRead {
        color: green;
    }
    .bookNotRead {
        color : red;
    }
</style>