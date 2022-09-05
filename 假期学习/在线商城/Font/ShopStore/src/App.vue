<template> 
 
  <router-view></router-view>
  <!-- <router-view></router-view> -->
</template>

<script>
import ElementUI from './components/ElementUI.vue'
import Login from './components/StoreBack/Login.vue'

export default {
  name: 'App',
  components: {
    ElementUI,
    Login
  },
  methods:{
    async getMenus()
    {
      const{data:res}=await this.$http.get("Api/Menu/GetMenus");
       console.log(res)
    },
    async postMenu()
    {
      alert("he")
      const{data:res}=await this.$http.post("Api/Menu/AddMenu",this.newMenu);
    }

  },
  data()
  {
    return{
      menus:[],
      newMenu:{
        menuName:"商品管理",
        url:"/Back/GoodsControl",
        parentId:null
      }
    }
  },
  created()
  {
    // this.getMenus();
  }
}
</script>
