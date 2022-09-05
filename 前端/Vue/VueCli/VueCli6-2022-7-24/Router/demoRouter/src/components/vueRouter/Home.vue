<template>
  <div>
    <h1>MyHome</h1>
    <button class="btn btn-primary" @click="goPrivacy(1)">Privacy</button>&nbsp;
    <router-link :to="{name:'mov', params:{id:5}}" class="btn btn-primary">命名式路由</router-link>&nbsp;
    <router-link to="/Main" class="btn btn-primary">Main</router-link>
  </div>
</template>

<script>
export default {
  methods:{
    goPrivacy(id)
    {
      this.$router.push(`/privacy/${id}`);
    }
  }
}
</script>

<style>

</style>