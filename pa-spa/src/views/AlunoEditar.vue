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
      console.log(this.$route.params.alunoid)
      this.axios.get('https://localhost:5001/api/alunos/' + this.$route.params.alunoid).then(response => (this.aluno = response.data))
    },
    deletar: function () {
      this.axios.delete('https://localhost:5001/api/alunos/' + this.$route.params.alunoid)
      //this.$router.push('/')
      //window.location.reload()
    },
    update: function () {
      this.axios.put('https://localhost:5001/api/alunos/' + this.$route.params.alunoid, this.aluno).then(this.getData())
      //this.$router.push('/')
      //window.location.reload()
    }
  },
  created () {
    this.getData()
  }
}
</script>
