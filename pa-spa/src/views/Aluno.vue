<template>
    <div>
        <b-container class="bv-example-row pt-5">
            <b-row>
                <b-col sm="6" offset="3">
                    <b-jumbotron>
                        <h1>{{aluno.id}}</h1>

                        <b-form-group label="Nome" label-for="nome">
                            <b-form-input id="nome" v-model="aluno.nome"  required></b-form-input>
                        </b-form-group>

                        <b-form-group label="Livros Doados">
                            <b-form-input v-model="aluno.livrosDoados" required></b-form-input>
                        </b-form-group>

                        <b-form-group label="Data de entrada na faculdade">
                            <b-form-input v-model="aluno.dataEntrada" type="date" required></b-form-input>
                        </b-form-group>

                        <b-button class="mr-2" v-on:click="update" variant="primary" >Salvar</b-button>
                        <b-button v-on:click="deletar" variant="success" >Deletar Aluno</b-button>


                        <div class="p-2 m-5" style="display: inline-block">
                          <b-form-input class="float-left" v-model="livroAux.nome" required style="width:62%"></b-form-input>
                          <b-button class="float-right" v-on:click="adicionarLivro()" variant="success" >Adicionar livro</b-button>
                        </div>
                        {{livroAux.alunoID}}
                        <b-card class="m-2 p-0" v-for="livro in aluno.livros">
                          <div class="float-left mt-2">{{livro.nome}}</div>
                          <b-button class="float-right" v-on:click="deletarLivro(livro.id)" variant="success" >Deletar</b-button>
                        </b-card>
                    </b-jumbotron>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>
<script>

export default {
  data () {
    return {
      aluno: '',
      livroAux: {
        alunoID:'',
        nome: ''
      }
    }
  },
  methods: {
    getData: function () {
      this.axios.get('https://localhost:5001/api/alunos/' + this.$route.params.alunoid).then(response => (this.aluno = response.data))
    },
    deletar: function () {
      this.axios.delete('https://localhost:5001/api/alunos/' + this.$route.params.alunoid)
      //this.$router.push('/')
      //window.location.reload()
    },
    update: function () {
      this.axios.put('https://localhost:5001/api/alunos/' + this.$route.params.alunoid, this.aluno)
      //this.$router.push('/')
      //window.location.reload()
    },
    deletarLivro: function (id) {
      this.axios.delete('https://localhost:5001/api/alunos/' + id + '/Delete')
      //this.$router.push('/')
      //window.location.reload()
    },
    adicionarLivro: function () {
      this.livroAux.alunoID = this.aluno.id
      this.axios.post('https://localhost:5001/api/alunos/' + this.$route.params.alunoid + '/add',this.livroAux)
      //this.$router.push('/')
      //window.location.reload()
    }
  },
  created () {
    this.getData()
  }
}
</script>
