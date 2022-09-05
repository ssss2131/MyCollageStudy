//  createRouter 用于创建路由的实例对象
//  createWebHashHistory 用于指定路由的工作模式(hash模式)
 
import { createRouter,createWebHashHistory } from "vue-router";

//导入组件
import Home from './Home.vue'
import About from './About.vue'
import Login from './Login.vue'
import Main from './Certificate/Main.vue'
import Privacy from './Privacy.vue'
import tab1 from './About/tab1.vue'
import tab2 from './About/tab2.vue'




// import tab1 from './components/vueRouter/About/tab1.vue'
// import tab2 from './components/vueRouter/About/tab2.vue' 

import { createApp } from "vue";
const router = createRouter({
    history:createWebHashHistory(),
    //提供高亮的类名
    linkActiveClass:'router-active',
    routes:[
        //重定向
        {path:'/',redirect:'/home'},
        {path:"/home",component:Home},
        {
            path:"/about",
            component:About,
            redirect:"/about/tab1",
            //嵌套子路由
            children:[
                {
                    path:'tab1',
                    component:tab1
                },
                {
                    path:'/about/tab2',
                    component:tab2
                }
            ]
        },
        {   //命名式路由  动态声明路由参数
            name:'mov',
            path:"/privacy/:id",
            component:Privacy,props:true
        },
        {
            path:'/Main',
            component:Main
        },
        {
            path:'/Login',
            component:Login
        }
    ]
    })
router.beforeEach((to,from,next)=>{

    //#region 
    // if(to.path==='/Main')
    // {
         
    //     next('/Login')
    // }
    // console.log(to )
    // console.log(from)
    // next();
    //#endregion
    const token = localStorage.getItem("token");
    if(to.path === '/Main' &&!token)
    {
        next('/Login')
    }else
    {
        next();
    }
})

// 共享变量
export default router
