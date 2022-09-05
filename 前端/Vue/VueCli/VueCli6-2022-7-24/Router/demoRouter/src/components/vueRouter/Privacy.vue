<template>
  <div>
    <h1>Privacy</h1>
    <h1>{{$route.params.id}}</h1>
    <h2>{{id}}</h2>
    <button class="btn btn-danger" @click="goBack">回 退</button>
  </div>
</template>

<script>
export default {
    // props:['id']
    props:{
      'id':{
        type:String
      }
    },
    methods:{
      goBack()
      {
        this.$router.go(-1);
      }
    }
    }
    // 路由传参可以通过props接收
    //     或者通过$route.params.参数名获取值

    //编程式导航
</script>

<style>

</style>