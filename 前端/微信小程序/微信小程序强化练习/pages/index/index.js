// index.js
// 获取应用实例
const app = getApp()

Page({
  data: {
    pageData: "Data From Page",
    recive: ""
  },

  getFromChild(val) {
    console.log(val)
    this.setData({
      recive: val.detail.value
    })
  },
  test() {
    let test1 = this.selectComponent("#test1");
    console.log(test1.data.first)
  }
})