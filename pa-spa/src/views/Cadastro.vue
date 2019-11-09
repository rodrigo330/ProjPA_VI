<template>
    <div name="Cadastro">
        <b-container class="bv-example-row pt-5">
            <b-row>
                <b-col sm="6" offset="3">
                    <b-jumbotron>
                        <h1>Cadastro Aluno</h1>
                        <b-form @submit="formSubmit">
                            <b-form-group label="Nome" label-for="nome">
                                <b-form-input id="nome" v-model="form.nome" placeholder="Digite o nome completo" required></b-form-input>
                            </b-form-group>

                            <b-form-group label="RA">
                                <b-form-input v-model="form.id" placeholder="Digite o RA" required></b-form-input>
                            </b-form-group>

                            <b-form-group label="Data de entrada na faculdade">
                                <b-form-input v-model="form.dataEntrada" type="date" placeholder="Digite a data que o aluno entrou na faculdade" required></b-form-input>
                            </b-form-group>
                            <b-button type="submit" variant="primary">Cadastrar</b-button>
                            <b-button type="reset" variant="danger">Resetar</b-button>
                        </b-form>
                    </b-jumbotron>
                </b-col>
            </b-row>
        </b-container>
    </div>
</template>

<script>
export default {
  name: 'Cadastro',
  data () {
    return {
      form: {
        nome: '',
        id: '',
        dataEntrada: '',
        livrosDoados: 0
      }
    }
  },
  methods: {
    formSubmit (e) {
      e.preventDefault()
      let currentObj = this
      this.axios.post('http://localhost:5000/api/alunos', currentObj.form)
      //this.$router.push('/')
      //window.location.reload()
    }
  }
}
</script>
