<template>
  <div class="home">
    <div>
     <apexchart height="200" type="bar" :options="chartOptions" :series="series"></apexchart>
    </div>
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
      chartOptions: {
        chart: {
          id: 'vuechart-example'
        },
        xaxis: {
          categories: []
        }
      },
      series: [{
        name: 'Qtd Livros doados',
        data: []
      }],
      fields: [{
        key: 'id',
        sortable: true
        },
        {
        key: 'nome',
        sortable: true
        }],
      alunos: []
    }
  },
  methods: {
    getData: function () {
      axios.get('https://localhost:5001/api/alunos').then(response => (this.alunos = response.data))
    },
    getGraphData: function () {
      axios.get('https://localhost:5001/api/alunos/livro/graph').then((response) => {
        response.data.forEach(element => {
          if(element.year == new Date().getFullYear()){
            this.chartOptions.xaxis.categories.push(element.month + '/' + element.year)
            this.series[0].data.push(element.value)
          }
        });
      })
    }
  },
  created () {
    this.getData()
    this.getGraphData()
  }
}
</script>
