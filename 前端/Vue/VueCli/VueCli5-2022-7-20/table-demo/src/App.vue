<template>
  <div>
    <h1>App 根组件</h1>
    <hr>
    <MyTable :data="goodsList">
    <!-- 将内容渲染到插槽中 -->
        <template v-slot:header>
          <th>#</th>
          <th>商品名称</th>
          <th>价格</th>
          <th>标签</th>
          <th>操作</th>
        </template>
        <template v-slot:body="{row,index}">
          <td>{{index}}</td>
          <td>{{row.goods_name}}</td>
          <td>￥{{row.goods_price}}</td>
          <td> 
            <input class="mx-1" v-if="row.inputVisiable" v-model="row.inputValue" @blur="onBlur(row.id)" v-focus/>
            <button class="btn btn-primary" v-else @click="addTag(row.id)" >+Tag</button>
            <span class="badge bg-warning mx-2" v-for="item in row.tages" :key="item">{{item}}</span>
          </td>
          <td>
            <button type="button" class="btn btn-danger btn-sm" @click="onRemove(row.id)">删除</button>
          </td>
        </template>
    </MyTable>
  </div>
</template>

<script>
//导入myTable组件
import MyTable from './components/my-table/MyTable.vue'//？？@用不了 换成.就好了
export default {
  //为App组件设置name属性方便后期梅花
  name:'myApp',
  components:{
    //将导入的MyTable注入到该组件中
    MyTable//标签名与导入定义的名字使用相同值
  },
  data(){
    return {
      //商品信息列表
      goodsList:[]
 
    }
  },
  methods:{
    onBlur(id){
      this.addTag(id);
      
    },
    addTag(id){ 
       var target = this.goodsList.find(c=>c.id==id);
       const val = target.inputValue;

       target.tages.push(val);
       target.inputValue=""
       target.inputVisiable=!target.inputVisiable;
    },
    onRemove(id){
      this.goodsList = this.goodsList.filter(c=>c.id!==id)
      // alert("删除数据的id是"+id);
    },
    // <!-- promise async await -->
    async getGoodsList()
    {//解构复制  /api/goods
      const {data:res} = await this.$http.get("/api/goods");
      console.log(res)
      if(res.status!==0)
      {
        return console.log("获取商品列表失败");
      }
      this.goodsList = res.data;
    }
  },
  //自定义指令
  directives:{
     focus(el)
     {
      el.focus();
     }
  },
    created(){
      console.log("hello");
      this.getGoodsList();//发起请求
    }
}
</script>

<style lang="less" scoped>

</style>

