### VueCli
    项目创建
        Vue create 项目名称
        选择Bible less
        选择Vue2
        cd到该项目
        yarn run 运行项目

    运行原理
        index.html呈现页面
        .Vue文件是Vue组件 
            组成部分1、 html   标签 只能有一个根节点
                    2、 style  标签 设置lang="less" 使用less 默认css
                    3、 script 标签 
                                    定义,作用
                                        data(){} 注意这里是函数 不是对象
                                        methods(){}定义方法
                                        watch(){}定义监听器
                                        computed(){}定义计算属性
                                        filters(){}定义私有过滤器
        main.js
                导入Vue构造函数 
                导入组件
                负责将组件渲染到index页面预留的dom节点上 将组件替换index上的节点 可以通过{el:"#app"} 或者{}.$mount("#app")进行挂载