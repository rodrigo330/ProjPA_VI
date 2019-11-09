<template>
  <div class="home">
    <b-table striped hover :items="alunos" :fields="fields">
      <template slot="id" slot-scope="data">
        <router-link :to="`/aluno/${data.item.id}`">
          {{ data.item.id }}
        </router-link>
      </template>
    </b-table>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'home',
  data () {
    return {
      fields: ['id', 'nome', 'livrosDoados', 'dataEntrada'],
      alunos: []
    }
  },
  methods: {
    getData: function () {
      axios.get('https://localhost:5001/api/alunos').then(response => (this.alunos = response.data))
    }
  },
  created () {
    this.getData()
  }
}
</script>
