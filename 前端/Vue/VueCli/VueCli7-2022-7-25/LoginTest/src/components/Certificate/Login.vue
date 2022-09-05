<template>
  <div>  
      <h1>Login页面</h1>
      <div class="LoginStyle">
        <div class="mb-3">
          <label for="exampleFormControlInput1" class="form-label">Email address</label>
          <input v-model.trim="username" type="email" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
        </div>
        <div class="mb-3">
          <label for="exampleFormControlTextarea1" class="form-label">Example textarea</label>
          <input v-model.trim="password" class="form-control" id="exampleFormControlTextarea1" rows="3" type="password"/>
        </div>
      </div>
      <button class="btn btn-primary" @click="login">登 录</button>
  </div>

</template>

<script>
export default {
  data(){
    return {
      username:" ",
      password:"",
      isLogin:false
    }
  },
  methods:{
    login()
    {
      if(!this.username.match(/^\w+@\w+\.\w+$/i))
      {
        alert("邮箱格式不正确")
        return;
      }
      // alert(this.username+" "+this.password)
      if(this.username==="123@qq.com"&&this.password==='123')
      {
        alert("登陆成功");        
        localStorage.setItem("token","normalTest");
        this.isLogin=true
        this.$emit("loginState",this.isLogin);
        this.$router.push("/Privacy")
      }
      else
      {
        alert("登陆失败")
      }

    }
  }
 
}
</script>

<style scoped>
 

</style>