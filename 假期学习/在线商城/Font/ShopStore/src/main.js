import { createApp } from 'vue'
import App from './App.vue'
import './index.css'
import Axios from 'axios'
import ElementPlus from 'element-plus'
import router from './components/StoreBack/Main'
// import '/bootstrap/dist/css/bootstrap.min.css'
import './assets/bootstrap.min.css'
// import './element-plus/dist/index.css'
import {ElLoading } from 'element-plus'

var app = createApp(App);
//设置请求根路径
Axios.defaults.baseURL="https://localhost:7138";
let loadingInstance = null
//请求拦截器
Axios.interceptors.request.use(config=>{
    config.headers.Authorization ='Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjUiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJub3JtYWwgdXNlciIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InVzZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9tb2JpbGVwaG9uZSI6IjEyMzEyMzEyMzExIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6InN0cmluZzIiLCJuYmYiOjE2NTkwODcxNTMsImV4cCI6MTY1OTA4NzI3MywiaXNzIjoiaHR0cDovL3d3dy5zdG9yZS5jb20iLCJhdWQiOiJ0ZXN0ZXIifQ.hu1PiBNc0HS1Gsp2IunqHrlc3s7lRZPsk2q-ZR-ko20'
    loadingInstance = ElLoading.service({fullscreen:false})
    return config
})
 
//响应拦截器
Axios.interceptors.response.use(response=>{  
    loadingInstance.close();
    return response;
})
//将该Axios挂载到app实例中 通过this.$http
app.config.globalProperties.$http = Axios;
app.use(ElementPlus)
app.use(router)

app.mount("#app");