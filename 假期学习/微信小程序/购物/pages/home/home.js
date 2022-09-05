// pages/home/home.js
import { createStoreBindings  } from 'mobx-miniprogram-bindings'
import {store} from '../../myMobx/myMobx'

Page({

  /**
   * 页面的初始数据
   */
  data: {
    subNav:[
      {
        id:1,
        pic:"https://img.yzcdn.cn/vant/apple-1.jpg",
        text:"子标题1"
      },
      {
        id:2,
        pic:"https://img.yzcdn.cn/vant/apple-1.jpg",
        text:"子标题2"
      },
      {
        id:3,
        pic:"https://img.yzcdn.cn/vant/apple-1.jpg",
        text:"子标题3"
      },
      {
        id:4,
        pic:"https://img.yzcdn.cn/vant/apple-1.jpg",
        text:"子标题4"
      }
    ],
    product:[
      {
        id:1,
        pic:"photo-o",
        text:"产品1"      
      },
      {
        id:2,
        pic:"photo-o",
        text:"产品2"      
      },
      {
        id:3,
        pic:"photo-o",
        text:"产品3"      
      },
      {
        id:4,
        pic:"photo-o",
        text:"产品4"      
      },
      {
        id:5,
        pic:"photo-o",
        text:"产品5"      
      },
      {
        id:6,
        pic:"photo-o",
        text:"产品6"      
      },
      {
        id:7,
        pic:"photo-o",
        text:"产品7"      
      },

      {
        id:8,
        pic:"photo-o",
        text:"产品8"      
      },
      {
        id:9,
        pic:"photo-o",
        text:"产品9"      
      },
      {
        id:10,
        pic:"photo-o",
        text:"产品10"      
      },

    ]
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad(options) {
    
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow() {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh() {
    console.log("chu fa")
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom() {
    console.log("chu fa")
    wx.showLoading({
      title: '加载中',
    })
    
    setTimeout(function () {
      wx.hideLoading()
    }, 2000)
    
    
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage() {

  }
})