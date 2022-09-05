// custom-tab-bar/index.js
import {storeBindingsBehavior} from 'mobx-miniprogram-bindings'
import {store} from '../store/store'
Component({
  /**
   * 组件的属性列表
   */
  properties: {
  
  },
  behaviors:[storeBindingsBehavior],
  storeBindings:{
    store,//指定要绑定的store
    fields:{
      info:"info"
    }
  },
  /**
   * 组件的初始数据
   */
  data: {
    active: 0,
    
  },
 

  /**
   * 组件的方法列表
   */
  methods: {
    onChange(event) {
      // event.detail 的值为当前选中项的索引
      this.setData({ active: event.detail });
    } 
  },
  observers:{
    'info':function(val)
    {
      console.log("1"+val)
    }
  }
  
})
