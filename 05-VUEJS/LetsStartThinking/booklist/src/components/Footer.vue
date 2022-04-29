<template>
  <footer>
    <p> BookList Copyright &copy; 2022</p>
  </footer>
</template>

<script>
    export default {
        name: 'FooterItem'
    }
</script>

<style scoped>
footer {
  display: flex;
  flex-direction: row;
  justify-content: center;
  align-items: center;
  position: fixed;
  bottom:0;
  text-align: center;
  width: 100%
}
</style>