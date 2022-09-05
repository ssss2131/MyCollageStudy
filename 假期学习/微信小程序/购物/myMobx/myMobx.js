import {observable,action} from 'mobx-miniprogram'

export const store = observable({

  activeIndex:0,
  test:"test",
  
  onChange:action(function(detail)
  {
    this.activeIndex = detail;
  
  })
})