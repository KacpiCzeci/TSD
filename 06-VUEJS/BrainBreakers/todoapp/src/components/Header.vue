<template>
  <header>
    <h1 v-on:click="onAddClick">Todo List</h1>
    <nav>
      <router-link to="/">Home</router-link>
      <router-link to="/add">Add New</router-link>
    </nav>
  </header>
</template>

<script>

export default {
  name: 'HeaderItem',
  data(){
      return {
          items: ["Home", "About"]
      }
  },
  components: {
  },
  methods: {
      onAddClick(){
          this.$router.push('/');
      }
  }
}
</script>

<style scoped>
    header {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }
</style>