<template>
  <div>
    <!-- <img alt="Vue logo" src="./assets/logo.png" /> -->
    <h1>Demo-Login</h1>
    <hr>
    <div class="container">
      <div class="menu">
        <router-link to="/Home" class="btn btn-primary">Home主页</router-link>
        <router-link to="/Privacy" class="btn btn-primary">Privacy</router-link>
        <router-link to="/Login"  class="btn btn-primary" v-if="!isLogin">Login</router-link>
        <button v-if="isLogin" class="btn btn-danger" @click="signOut">注销</button> 
      </div>
    
      <router-view class="routeView" @loginState="login"></router-view>
    </div>
  </div>
</template>

<script>
 

export default {
  props:
  {
    loginState:{
      type:Boolean,
      default:false
    }
  },
  data(){
    return {isLogin:this.loginState}
  },
  name: 'App',
  components: {
   
  } ,
  methods:{
    //获取用户登录
    login(data)
    {   
      this.isLogin = data      
    },
    ifLogin()
    {
      var token = localStorage.getItem('token');  
      if(token){        
        this.isLogin=true;
      }
      else{  
        this.isLogin=false;
      }
    },
    signOut()
    {
      localStorage.removeItem('token');
      this.isLogin=false;
    }
  },
  created(){
    this.ifLogin()
  } 
}
</script>
