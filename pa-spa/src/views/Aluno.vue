<template>
    <div>
      <div>
        <b-container class="bv-example-row pt-5 ">
            <b-row>
                <b-col sm="9" offset="1">
                    <b-jumbotron style="display: inline-block">
                        <h1 class="float-left">{{aluno.id}} {{aluno.nome}}</h1>
                        <b-button class="m-2 float-right" v-on:click="goToEditar" variant="primary" >Editar</b-button>
                    </b-jumbotron>
                </b-col>
            </b-row>
        </b-container>

      </div>
        <b-jumbotron>
          <div style="display: inline-block">

            <b-form-group label="Nome do Livro" label-for="nome">
                <b-form-input id="nome" v-model="livroAux.nome"  required></b-form-input>
            </b-form-group>
            <b-form-group label="Data da Doação do livro" v-if="!status">
                <b-form-input v-model="livroAux.dataEntrada" type="date" required></b-form-input>
            </b-form-group>
             <b-form-checkbox
                id="checkbox-1"
                v-model="status"
                name="checkbox-1"
              >
                Usar data atual
              </b-form-checkbox>
            <b-button v-on:click="adicionarLivro()" variant="success" class="m-3">Adicionar livro</b-button>
          </div>
        </b-jumbotron>
        <div class="home">
          <b-table striped hover bordered fixed :items="aluno.livros" :fields="fields">
            <template slot="nome" slot-scope="data">
              <router-link :to="`/aluno/${data.item.id}`">
                {{ data.item.nome }}
              </router-link>
            </template>
          </b-table>
        </div>
    </div>
</template>
<script>

export default {
  data () {
    return {
      aluno: '',
      livroAux: {
        alunoID:'',
        nome: '',
        dataEntrada: ''
      },
      fields: [{
        key: 'nome',
        sortable: true
        },
        {
        key: 'dataEntrada',
        sortable: true
        } ],
        status: true
    }
  },
  methods: {
    getData: function () {
      //console.log(this.$route.params.alunoid)
      this.axios.get('https://localhost:5001/api/alunos/' + this.$route.params.alunoid).then(response => (this.aluno = response.data))
    },
    deletar: function () {
      this.axios.delete('https://localhost:5001/api/alunos/' + this.$route.params.alunoid)
    },
    update: function () {
      this.axios.put('https://localhost:5001/api/alunos/' + this.$route.params.alunoid, this.aluno).then(this.getData())
    },
    deletarLivro: function (id) {
      this.axios.delete('https://localhost:5001/api/alunos/' + id + '/Delete').then(this.getData())
    },
    adicionarLivro: function () {
      if(this.livroAux.dataEntrada == '')
        this.livroAux.dataEntrada = new Date();
      console.log(this.livroAux)
      this.livroAux.alunoID = this.aluno.id
      this.axios.post('https://localhost:5001/api/alunos/' + this.$route.params.alunoid + '/add',this.livroAux).then(this.getData())
      //location.reload();
      //this.$router.push('/')
      //window.location.reload()
    },
    goToEditar: function () {
      this.$router.push('/aluno/'+this.$route.params.alunoid+'/editar')
      //window.location.reload()
    }
  },
  created () {
    this.getData()
  }
}
</script>
