<template>
    <div>
      <div>
        <b-container class="bv-example-row pt-5 ">
            <b-row>
                <b-col lg="8" offset="1">
                    <b-jumbotron style="display: inline-block">
                        <h2 class="float-left">{{aluno.id}} {{aluno.nome}}</h2>
                        <b-button class="m-2 float-right" v-on:click="goToEditar" variant="primary" >Editar</b-button>
                    </b-jumbotron>
                </b-col>
                <b-col lg="3" offset="0">
                    <b-jumbotron style="display: inline-block">
                        <h3 class="float-right">QTD Doados</h3>
                        <p> {{size(aluno.livros)}} </p>
                        {{livroAux.dataEntrada}}
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
                <b-form-input v-model="livroAux.data_Da_Doacao" type="date" required></b-form-input>
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
          <b-table striped hover bordered  :items="aluno.livros" :fields="fields">
            <template slot="nome" slot-scope="data">
              <router-link :to="`/livro/${data.item.id}`">
                {{ data.item.nome }}
              </router-link>
            </template>
            <template slot="Deletar" slot-scope="data">
                <b-button v-on:click="deletarLivro(data.item.id)" variant="primary" >Deletar</b-button>
            </template>
          </b-table>
        </div>
    </div>
</template>
<script>

export default {
  data () {
    return {
      aluno: {
        livros: []
      },
      livroAux: {
        alunoID:'',
        nome: '',
        data_Da_Doacao: ''
      },
      fields: [{
        key: 'nome',
        sortable: true
        },
        {
        key: 'data_Da_Doacao',
        sortable: true
        },
        {
          key: 'Deletar'
        } ],
        status: true
    }
  },
  methods: {
    getData: function () {
      var self = this
      //console.log(this.$route.params.alunoid)
      //this.axios.get('https://localhost:5001/api/alunos/' + self.$route.params.alunoid).then(response => (self.aluno = response.data))
      //console.log('gfvgg')
      this.axios.get('https://localhost:5001/api/alunos/' + self.$route.params.alunoid).then((response) => {
                                                                                                    this.aluno = response.data;
                                                                                                    this.aluno.livros.forEach(element => {
                                                                                                      element.data_Da_Doacao = element.data_Da_Doacao.split('T')[0];
                                                                                                    });
                                                                                                    //this.livro.data_Da_Doacao = this.livro.data_Da_Doacao.split('T')[0];
                                                                                                    })
    },
    deletar: function () {
      this.axios.delete('https://localhost:5001/api/alunos/' + this.$route.params.alunoid)
    },
    update: function () {
      this.axios.put('https://localhost:5001/api/alunos/' + this.$route.params.alunoid, this.aluno).then(this.getData())
    },
    deletarLivro: function (id) {
      //this.axios.delete('https://localhost:5001/api/alunos/' + id + '/Delete').then(this.getData())
      
      this.axios.delete('https://localhost:5001/api/alunos/livro/' + id + '/delete').then(()=>{this.getData();})
    },
    adicionarLivro: function () {
      if(this.livroAux.data_Da_Doacao == '')
        this.livroAux.data_Da_Doacao = new Date();

      this.livroAux.alunoID = this.aluno.id
      this.axios.post('https://localhost:5001/api/alunos/' + this.$route.params.alunoid + '/add',this.livroAux).then(()=>{this.getData();})
      //location.reload();
      //this.$router.push('/')
      //window.location.reload()
    },
    goToEditar: function () {
      this.$router.push('/aluno/'+this.$route.params.alunoid+'/editar')
      //window.location.reload()
    },
    size: function (arr) {
      if(arr != null)
        return arr.length
      return 0
    },
  },
  created () {
    this.getData()
  }
}
</script>
