
NPM Promise化

  安装:npm install --save miniprogram-api-promise@1.0.4 

  构建npm

  使用: import {promisefyAll} from 'miniprogram-api-promise'

        const wxp = wx.p = {}
        promisefyAll(wx,wxp)


Mobx　全局数据共享

  安装:npm install --save mobx-miniprogram@4.13.2 mobx-miniprogram-bindings@1.2.1

  构建npm

  使用
    创建一个新文件夹存放后再其里面创建store.js文件
      文件内容
        import {observable,action} from 'mobx-miniprogram'

        export const store = observable({

          需要共享的数据

          //计算属性
          get funName()
          {

          },
          ...
          updateNum1:action(function(args){

          }),
          ...
        })
    在页面中使用
      １、导入需要的成员
        import {createStoreBindings} from 'mbox-miniprogram-bindings'
        import {store} from '../../store/store'
      ２、绑定方法
        page({
          onLoad:function(){
            this.storeBindings = createStoreBindings(this,{
              store,
              filed:[''],
              actions:['']
            })
          }
        })

      ３、清理
      onUnload:function(){
        this.storeBindings.destroyStoreBingdings()
      }
      将Store绑定到组件中
        import {storeBindingsBehavior} from 'mbox-miniprogram-bindings'
        import {store} from '../../store/store'

        Component({
          behaviors:[storeBindingsBehavior],
          storeBindings:{
            store,//指定要绑定的store
            fields:{
              numA:()=>store.numA,
              numB:(store)=>store.numB,
              sum:'sum'
            }
          },
          actions:{//指定要绑定的方法
            updateNum2:'updateNum2'
          }
        })

分包
    每个包大小小于2MB
      在app.json中设置
        "subpackages":[
          {
            "root":"pkgA",
            "name":"a",
            "pages":[
              ...
            ]
          },
          ...
        ]
    分包原则
      1、主包无法引用分包的私有资源
      2、分包之间不能相互引用私有资源
      3、分包可以引用主包内的公共资源

    独立分包
       不打开主包的情况下启动 在分包对象中添加independent:true
       普通分包需要运行主包才能运行
        引用原则:
          1、主包无法引用独立分包内的私有资源
          2、独立分包之间，不能相互引用私有资源
          3、独立分包和普通分包之间，不能相互引用私有资源
          4、独立分包中不能引用主包内的公共资源

分包预下载
    配置:
        在app.json的preloadRule节点下定义
        与pages平级
        "preloadRule":{
          "pages/index/index":{
            "packages":["a"],
            network:"all",
            
          }
        }  
    公共预下载小于2M  