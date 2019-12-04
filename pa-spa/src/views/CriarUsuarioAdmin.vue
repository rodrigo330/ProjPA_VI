<template>
  <div>

    <h1>Criar usuario admin</h1>
    <b-container class="bv-example-row pt-5">
      <b-row>
        <b-col sm="6" offset="3">
          <b-form @submit.prevent="login" method="post">
            <b-form-group
              id="username-inp"
              label="Username"
              label-for="username"
            >
              <b-form-input
                id="username"
                v-model="form.Username"
                type="text"
                required
                placeholder="Coloque seu usuario"
              ></b-form-input>
            </b-form-group>

            <b-form-group id="password-inp" label="Senha" label-for="password">
              <b-form-input
                id="password"
                v-model="form.Password"
                required
                placeholder="Coloque sua senha"
                type="password"
              ></b-form-input>
              <p>A senha deve conter no minimo 4-30</p>
            </b-form-group>


            <p>(essa pagina nao é para existir mas criei ela para voce testar)</p>
            <b-button type="submit" variant="primary">Submit</b-button>
            <b-button type="reset" variant="danger">Reset</b-button>
          </b-form>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>

export default {
  data () {
    return {
      form: {
        Username: '',
        Password: ''
      }
    }
  },
  methods: {
    login () {
      this.axios.post('http://localhost:5000/api/auth/register', this.form).then(() => {this.$router.push('/')})
    }
  }
}
</script>
