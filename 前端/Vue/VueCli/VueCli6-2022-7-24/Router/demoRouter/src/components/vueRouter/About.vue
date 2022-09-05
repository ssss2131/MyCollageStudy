<template>
  <div>
    <h1>About</h1>
    <hr/>
    
    <div class="container">
      <h1>hellp</h1>
       <router-link to="/about/tab1" class="btn btn-primary">tab1</router-link>&nbsp;
       <router-link to="/about/tab2" class="btn btn-primary">tab2</router-link>
           <hr/>
           <router-view></router-view>
    </div>
  </div>
</template>

<script>
export default {
  
}
</script>

<style   scoped>
.container{
  width: 50%;
  height: auto;
  background: gray;
}
</style>