// custom-tab-bar/index.js
import { storeBindingsBehavior  } from 'mobx-miniprogram-bindings'
import {store} from '../myMobx/myMobx'

Component({
  /**
   * 组件的属性列表
   */
  properties: {

  },
  options:{
    styleIsolation:'shared'
  },
  behaviors:[storeBindingsBehavior],
  storeBindings:{
    store,
    fields:{
      active:'activeIndex'
    },
    actoins:{

    }
  },

  /**
   * 组件的初始数据
   */
  data: { 
  
    menus:[
      {
        "id":1,
        "pagePath": "/pages/home/home",
        "text": "首页",
        "icon":"home-o",
        "info":0
      },
      {
        "id":2,
        "pagePath": "/pages/classify/classify",
        "text": "分类",
        "icon":"search",
        "info":0
      },
      {
        "id":3,
        "pagePath": "/pages/personal/personal",
        "text": "个人信息",
        "icon":"setting-o",
        "info":0
      },
      {
        "id":4,
        "pagePath": "/pages/car/car",
        "text": "购物车",
        "icon":"shopping-cart-o",
        "info":0
      }
    ]
  },

  /**
   * 组件的方法列表
   */
  methods: {
    onChange:function(event){
      
      
      // this.setData({ active: event.detail });    
      wx.switchTab({
        url: this.data.menus[event.detail].pagePath,
      }) 
      store.onChange(event.detail);    
    }
  }
  
})
