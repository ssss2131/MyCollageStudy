import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import './assets/css/bootstrap.css'
 
import Axios from 'axios'
//单页面实例
const app = createApp(App)

//设置请求根路径
Axios.defaults.baseURL="https://localhost:7116";
//将该Axios挂载到app实例中 通过this.$http
app.config.globalProperties.$http = Axios;
//设置挂载点
app.mount("#app")
