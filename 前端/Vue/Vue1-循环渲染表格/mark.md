## Vue 的基本使用
   基本使用步骤 
   1. 导入Vue文件 在body 页面元素最后面使用script标签引入
   2. 实例化一个Vue对象 const vm = new Vue({})
   3. 通过dom中的id 或者 name属性节点声明el,设置data数据节点 
<pre>
   new Vue({
        el:"#app" //".app"
        data:{
            list:[],

        },
        methods:{
            
        }
   })
</pre>
   4. MvvM中对应关系


   Vue中常见的指令
   1. v-bind 数据单向绑定到视图 简写: ":for"
   `
    <input id="'cd'+item.id"/>
    <label :for="'cd'+item.id"></label>
    <label v-bind:for="'cd'+item.id"></label>
   `
   1. v-model 数据双向绑定视图到数据源
   `
    <input v-model.trim="{{item.id}}"/> //移除输入的空格
    <input v-model.number="{{item.id}}"/>//获取用户输入的数字 自动转化文number类型
    <input v-model.lazy="{{item.id}}"/>//在发生change时而非input更新
   `
   1. v-show 设置标签的disable属性
   2. v-if v-else 判断 //true渲染 否则删除 相对v-show有很小的性能损失
   `
    <input v-if="1===1"/>
    <input v-eles/>
   `
   1. v-on 事件绑定 简写:"@" .prevent 阻止表单默认提交行为
  
    <form @submit.prevent="add">
    </form>

   2. v-for 循环 需要设置 :key 使用id唯一标识
   <tr v-for="item in list"></tr>//list是vm对象中data属性里面的一个子元素
  
<pre>
    Vue过滤器用法   
     remove(id)
                {
                    console.log(id);
                    //过滤出不删的数组
                    this.list=this.list.filter(item=>item.id!==id)                  
                }
</pre>  
   
###时间的转换 dayjs库
   npm install dayjs --save
   https://dayjs.fenxianglu.cn/category/#node-js