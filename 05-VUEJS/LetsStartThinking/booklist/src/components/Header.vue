<template>
  <header>
    <h1>BookList</h1>
    <MenuItems v-bind:items="items" @clicked="onChildClick"/>
  </header>
</template>

<script>
import MenuItems from './MenuItems.vue';

export default {
  name: 'HeaderItem',
  data(){
      return {
          items: ["Home", "About"]
      }
  },
  components: {
      MenuItems
  },
  methods: {
      onChildClick(value){
          this.$emit('clicked', value);
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