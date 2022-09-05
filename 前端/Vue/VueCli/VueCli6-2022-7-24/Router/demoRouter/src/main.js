import { createApp } from 'vue'
import App from './App.vue'
import MyApp from './MyApp.vue'
import './index.css'
import { createRouter,createWebHashHistory } from "vue-router";
import './assets/bootstrap.css'
import router from './components/vueRouter/router'
// //导入组件
// import Home from './components/vueRouter/Home.vue'
// import About from './components/vueRouter/About.vue'
// import Privacy from './components/vueRouter/Privacy.vue'

// import tab1 from './components/vueRouter/About/tab1.vue'
// import tab2 from './components/vueRouter/About/tab2.vue'    
// const router = createRouter({
//     history:createWebHashHistory(),
//     //提供高亮的类名
//     linkActiveClass:'router-active',
//     routes:[
//         //重定向
//         {path:'/',redirect:'/home'},
//         {path:"/home",component:Home},
//         {
//             path:"/about",
//             component:About,
//             children:[
//                 {path:'/about/tab1',component:tab1},
//                 {path:'/about/tab2',component:tab2}

//             ]
//         },
//         {path:"/privacy",component:Privacy}
//     ]
//     })

const app = createApp(MyApp)
//挂载路由
app.use(router)

app.mount("#app")
