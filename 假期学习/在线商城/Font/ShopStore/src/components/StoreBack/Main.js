import {createRouter,createWebHashHistory} from "vue-router"
import Login from './Login.vue'
import SignUp from './SignUp.vue'
import ConfirmCode from './SignUp/ConfirmCode.vue'
import BasicInfo from './SignUp/BasicInfo.vue'
import Home from './Home/Home.vue'
const router = createRouter({
    history:createWebHashHistory(),
    linkActiveClass:'router-active',
    routes:[
        {
            path:"/",
            redirect:'/login'
        },
        {
            path:'/login',
            component:Login
        },
        {
            path:'/signUp',
            component:SignUp,
            children:[
                {
                    path:'basicInfo',
                    component:BasicInfo
                },
                {
                    path:'confirmCode',
                    component:ConfirmCode
                }
            ]
        },
        {
            path:"/home",
            component:Home
        }
    ]
})


export default router