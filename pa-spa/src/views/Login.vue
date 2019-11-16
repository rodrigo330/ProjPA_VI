<template>
  <div>
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
            </b-form-group>

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
      let axiosConfig = {
        headers: {
          'Content-Type': 'application/json;charset=UTF-8',
          'Access-Control-Allow-Origin': '*'
        }
      }

      this.$auth.login({
        data: {
          Username: this.form.Username,
          Password: this.form.Password
        },
        axiosConfig,
        success: (response) => {
          
          localStorage.setItem('Authorization', response.data.token)
        },
        error: function (res) {
        }
      })
    }
  }
}
</script>
