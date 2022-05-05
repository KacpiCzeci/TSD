<template>
  <HeaderItem/>
  <router-view @onAddClick="messageFromChild" @deleteTodo="messageFromChild"/>
  <div v-if="show" class="msg-container">
    <div class="msg-subcontainer">
      <p class="msg-p">{{ message }}</p>
    </div>
  </div>
  <FooterItem/>
</template>

<script>
import HeaderItem from './components/Header.vue';
import FooterItem from './components/Footer.vue';

export default {
  name: 'App',
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      message: '',
      show: false,
    }
  },
  methods: {
    messageFromChild(value){
      this.message = value;
      this.show = true;
      setTimeout(() => { this.show = false; }, 1500);
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  #text-align: center;
  color: #2c3e50;
}

nav {
  padding: 30px;
}

nav a {
  padding: 10px;
  font-weight: bold;
  color: #2c3e50;
}

nav a.router-link-exact-active {
  color: #42b983;
}



.msg-container{
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  position: fixed;
  bottom:40px;
  text-align: center;
  width: 100%;
}

.msg-subcontainer{
  width: 200px;
  border-radius: 24px;
  background-color: #A5A5A5;
}

.msg-p{
  color: #ffffff;
}
</style>
