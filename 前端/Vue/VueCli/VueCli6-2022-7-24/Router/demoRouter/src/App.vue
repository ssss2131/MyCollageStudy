<template>
  <div>
    <a href="#/Home">Home</a>
    <a href="#/About">About</a>
    <a href="#/Privicy">Privicy</a>
    <component :is="myRoute"></component>
  </div>
</template>

<script>
import AboutVue from './components/About.vue'
import HomeVue from './components/MyHome.vue'
import PrivicyVue from './components/Privicy.vue'
export default {
  data()
  {
    return {
      myRoute:"HomeVue"
 
    }
  },
  methods:{
    switchurl()
    {  
      var path = window.location.pathname;
      switch(path)
      {
        case "/Home":
          this.myRoute="HomeVue";
          break;
        case "/Privicy":
          this.myRoute="PrivicyVue";
          break;
        case "/About":
          this.myRoute="AboutVue";
          break;
      }
    }
  },
  components:{
    AboutVue,
    HomeVue,
    PrivicyVue
  },
  created()
  {
    // this.switchurl();
  
      window.onhashchange=()=>{
  
      switch(location.hash)
      {
        case '#/Home':
          this.myRoute="HomeVue"
          break;
        case '#/About':
          this.myRoute="AboutVue"
          break;
        case '#/Privicy':
          this.myRoute="PrivicyVue"
          break;
      }
    }
  }
}
</script>

<style>

</style>