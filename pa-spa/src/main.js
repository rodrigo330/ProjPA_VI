import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import VueAuth from '@websanova/vue-auth'
import VueAuthOptions from './auth'
import VueAxios from 'vue-axios'
import axios from 'axios'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import App from './App.vue'
import router from './router'
import store from './store'

Vue.router = router

Vue.use(BootstrapVue)
Vue.use(VueAxios, axios)
Vue.use(VueAuth, VueAuthOptions)

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
