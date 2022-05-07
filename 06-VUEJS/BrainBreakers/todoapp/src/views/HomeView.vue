<template> 
    <div id="home" class="container-home">
      <div class="searchbar-container">
        <input class="searchbar" v-model="regex" type="text" @keyup="search" placeholder="Search...">
      </div>
      <div v-if="length == 0">
        <p class="notodo">The list is empty! Add new todos ...</p>
      </div>
      <div v-else>
      <router-view :key="$route.path"></router-view>
        <div v-for="td in todos" :key="td._id" class="todo" v-on:click="onClick(td.id)">
            <p class="todoTitle">{{ td.title }}</p>
        </div>
      </div>
    </div>
</template>
    
<script>
export default {
  name: 'HomeView',
  components: {
  },
  data(){
    return{
      length: this.$store.getters.getTodoLen,
      todos: this.$store.getters.getAll,
      regex: '',
      current: '',
    }
  },
  methods: {
    onClick(id){
      if(this.current === id){
        this.current = '';
        this.$router.push({name:'home'});
      }
      else{
        this.current = id;
        this.$router.push({name:'details', params:{ id:id } });
      }
    },
    search(){
      if(this.regex !== ''){
        this.todos = this.$store.getters.getByTitle(this.regex);
      }
      else {
        this.todos = this.$store.getters.getAll;
      }
    }
  }
}
</script>

<style>
  .container-home{
    overflow-y: scroll;
  }
  .searchbar, .todo{
    border-radius: 12px;
    border-style: solid;
    border-color: #000000;
    border-width: 1px;
    margin-top: 15px;
    margin-bottom: 15px;
    margin-right: 30px;
    margin-left: 30px;
  }
  .searchbar{
    display: flex;
    padding: 20px;
    width: 100%;
    box-sizing: border-box;
  }
  .searchbar-container{
    display: flex;
    width: 100%;
  }
  .notodo{
    color: #A5A5A5;
    text-align: center;
  } 
  .todoTitle {
    margin: 20px;
  }
</style>
