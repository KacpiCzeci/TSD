<template>
  <HeaderItem @clicked="onChildClick"/>
  <BookList />
  <FooterItem />
</template>

<script>
import HeaderItem from './components/Header.vue';
import BookList from './components/BookList.vue';
import FooterItem from './components/Footer.vue';

export default {
  name: 'App',
  components: {
    HeaderItem,
    BookList,
    FooterItem,
  },
  methods: {
    onChildClick(value){
      alert("Clicked " + value);
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  }
</style>
