import {observable,action} from 'mobx-miniprogram'


export const store = observable({
  info:10,
  updateInfo:action(function(){
    this.info +=1;
  }) 
})