import { createRouter,createWebHashHistory  } from "vue-router";
import Login from './Certificate/Login.vue'
import Privacy from './Certificate/Privacy.vue'
import Home from './Home.vue'
const router = createRouter({
    history:createWebHashHistory(),
    linkActiveClass:'router-active',
    routes:[
        {
            path:'/Home',
            component:Home
        },
        {
            path:'/',
            redirect:'/Home',
            
        },
        {
            path:'/Login',
            component:Login
        },
        {
            path:'/Privacy',
            component:Privacy,         
        }
    ]
})
router.beforeEach((to,from,next)=>{
    var token = localStorage.getItem('token');
 
    if(to.path==="/Privacy"&&token===null)
    {
        alert("请登录");
        next('/Login');
    }
    else{
        next();
    }
   
})
export default router;