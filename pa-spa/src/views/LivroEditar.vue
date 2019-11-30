<template>
    <div>
        <b-container class="bv-example-row pt-5">
            <b-row>
                <b-col sm="6" offset="3">
                    <b-jumbotron>
                        <h1>Editar Livro</h1>
                        <b-form-group label="Nome do Livro" label-for="nome">
                            <b-form-input id="nome" v-model="livro.nome"  required></b-form-input>
                        </b-form-group>

                        <b-form-group label="Data de doação">
                            <b-form-input v-model="livro.data_Da_Doacao" type="date" required></b-form-input>
                        </b-form-group>

                        <b-button class="mr-2" v-on:click="update" variant="primary" >Salvar</b-button>
                        <b-button v-on:click="deletar" variant="success" >Deletar Livro</b-button>
                        
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
      livro: ''
    }
  },
  methods: {
    getData: function () {
      this.axios.get('https://localhost:5001/api/alunos/livro/' + this.$route.params.livroid).then((response) => {
                                                                                                    this.livro = response.data;
                                                                                                    this.livro.data_Da_Doacao = this.livro.data_Da_Doacao.split('T')[0];
                                                                                                    })
      
      //console.log(this.livro.data_Da_Doacao);
      //console.log(moment(livro.data_Da_Doacao).format('MMMM Do YYYY, h:mm:ss a'))
      
    },
    deletar: function () {
      var aux = this.livro.alunoID
      this.axios.delete('https://localhost:5001/api/alunos/livro/' + this.livro.id + '/delete').then(() => {this.$router.push('/aluno/' + aux);})
      
      //window.location.reload()
    },
    update: function () {
      
      var aux = this.livro.alunoID
      this.axios.put('https://localhost:5001/api/alunos/livro/' + this.livro.id + '/edit', this.livro).then(() => {this.$router.push('/aluno/' + aux);})
      //this.$router.push('/')
      //window.location.reload()
    }
  },
  created () {
    this.getData()
  }
}
</script>
