// components/test2/test2.js
Component({
  options:{
    styleIsolation:"isolated",
    pureDataPattern:/^_/
    
  },
  observers:{
    'myData':function(val) {
      val +="-"
      console.log(val)
   
    }
  },
  /**
   * 组件的属性列表
   */
  properties: {
    reciveData:{
      type:String,
      value:""
    }
  },

  /**
   * 组件的初始数据
   */
  data: {
    myData:0,
    childData:"childData"
  },

  /**
   * 组件的方法列表
   */
  methods: {
    addData()
    {
      this.setData({
        myData:this.data.myData +=1
      })
    },
    send()
    {
      this.triggerEvent('mySend',{value:this.data.childData})
    }
  }
})
