<template>
  <table class="table table-bordered table-striped">
    <!-- 商品标题 -->
    <thead>
        <!-- a.具名插槽 -->
        <tr>  
            <slot name="header"></slot>
        </tr>
    </thead>
    <!-- 商品主体 -->
    <tbody>
        <tr v-for="(item,index) in data" :key="item.id">
        <!-- b.作用域插槽 -->
            <slot name="body" :row="item" :index="index"></slot>
        </tr>
    </tbody>
  </table>
</template>

<script>
export default {
    //父传子 props
    props:{
        data:{
            type:Array,
            require:true,
            default:[]
        }
    }
}
</script>
<!-- 使用less 定义scoped防止外部css影响 -->
<style lang="less" scoped>

</style>