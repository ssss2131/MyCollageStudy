// components/test/test.js
const behavior = require('../../behaviors/my-behaviors')
Component({
  options:{
    styleIsolation:"isolated",
    pureDataPattern:/^_/,
    multipleSlots:true
  },
  lifetimes:{
    created:function(){

    },
    attached:function(){

    },
    detached:function(){
 
    } 
  },
  pageLifetimes:{
    show:function() {
      
    },
    hide:function() {  
    },
    resize:function() {
      
    }

  }, 
  observers:{ 
    'first':function(val) 
    { 
      console.log(val+"!")
    }
  },
  /**
   * 组件的属性列表
   */
  properties: {

  },

  /**
   * 组件的初始数据
   */
  data: {
    first:"first",
    test:{id:1}
  },

  /**
   * 组件的方法列表
   */
  methods: {
    input:function(e)
    {
       this.setData({
         first:e.detail.value
       })
    }
  }
})
