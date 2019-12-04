import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Cadastro from './views/Cadastro.vue'
import Aluno from './views/Aluno.vue'
import AlunoEditar from './views/AlunoEditar.vue'
import LivroEditar from './views/LivroEditar.vue'
import Login from './views/Login.vue'
import Admin from './views/CriarUsuarioAdmin.vue'


Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        auth: true
      }
    },
    {
      path: '/login',
      name: 'login',
      component: Login,
      meta: {
        auth: undefined
      }
    },
    {
      path: '/Cadastro',
      name: 'Cadastro',
      component: Cadastro,
      meta: {
        auth: true
      }
    },
    {
      path: '/Aluno/:alunoid',
      name: 'Aluno',
      component: Aluno,
      meta: {
        auth: true
      }
    },
    {
      path: '/Aluno/:alunoid/editar',
      name: 'AlunoEditar',
      component: AlunoEditar,
      meta: {
        auth: true
      }
    },
    {
      path: '/Livro/:livroid',
      name: 'livro',
      component: LivroEditar,
      meta: {
        auth: true
      }
    },
    {
      path: '/admin',
      name: 'admin',
      component: Admin,
      meta: {
        auth: undefined
      }
    }
  ]
})
