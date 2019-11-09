import bearer from '@websanova/vue-auth/drivers/auth/bearer'
import axios from '@websanova/vue-auth/drivers/http/axios.1.x'
import router from '@websanova/vue-auth/drivers/router/vue-router.2.x'
/**
 * Authentication configuration, some of the options can be override in method calls
 */
const config = {
  auth: bearer,
  http: axios,
  router: router,
  fetchData: { enabled: false },
  refreshData: { enabled: false },
  tokenDefaultName: 'Authorization',
  tokenStore: ['localStorage'],
  authRedirect: { path: '/login' },
  loginData: {
    url: 'http://localhost:5000/api/auth/login',
    method: 'POST',
    redirect: '/',
    fetchUser: false
  }
}
export default config
