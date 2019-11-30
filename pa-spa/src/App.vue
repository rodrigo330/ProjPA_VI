<template>
  <div id="app">
    <div>
      <b-navbar toggleable="lg" type="dark" variant="info">
        <b-navbar-brand href="/">Doação de Livro</b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <b-collapse id="nav-collapse" is-nav>
          <b-navbar-nav>
            <b-nav-item href="/cadastro">Cadastrar Aluno</b-nav-item>
          </b-navbar-nav>
            <!-- Search Bar -->
            <b-navbar-nav class="ml-auto">
            <b-form-input size="sm" class="mr-sm-2" v-model="Ra" placeholder="Search" v-on:keydown.enter="goTo"></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" v-on:click="goTo">Search</b-button>
            <b-button v-if="isLogged()" size="sm" class="ml-2 my-2 my-sm-0" v-on:click="sair">Logout</b-button>
          </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
    <router-view/>
  </div>
</template>

<style lang="scss">
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>

<script>
export default {
  data () {
    return {
      Ra: ''
    }
  },
  methods: {
    goTo: function (event) {
      this.$router.push('/aluno/' + this.Ra)
      window.location.reload()
    },
    sair: function (event) {
      localStorage.setItem('Authorization', "")
      this.$router.push('/login/')
      window.location.reload()
    },
    isLogged: function (event){
      if(localStorage.getItem('Authorization') == null){
        return false
      }
      return true
    }
  }
}
</script>
