#coding:gbk
 
from random import random, randrange, uniform
 
print("<<<欢迎来到猜金币游戏<<<");

print("请输入您的账号密码------");

account = "admin"
password = "123456"
money = 0
inputAccount = ""
inputPassword = ""
inputRes = False

while inputRes== False:
    inputAccount = input("请输入您的账号")
    print("---------------------------------")
    inputPassword = input("请输入您的密码");
    
    if inputPassword == password and inputAccount == account :
       inputRes = True
    else:
        print("!!账号或者密码错误!!")
     
print("!!**欢迎进入游戏**!!")        

input("****游戏需要支付1枚金币****按下回车开始,ctrl+c结束游戏")
a = 0
chock = 1
myRound = 1
endRound = 10
roundInput = 0

while myRound<=endRound:
    if money -1<0:
        input("!!!对不起金币不足,请充值!!");
        a = input("请输入充值金额")
        print(a)
        if int(a)<=0:
            print("!!!对不起,您的输入有错误")
        else:
            money +=int(a);
            print("充值成功 当前余额为"+str(money))
    print("欢迎来到第"+str(myRound)+"关卡;\r 您将会在"+"0"+"到"+str(2*(myRound))+"范围中猜取一个随机数")
    challenge = randrange(0,2*(myRound))
    
    roundInput = input("输入您的数")
    if int(challenge) == int(roundInput):
        print("*****&&&&！！恭喜您，回答正确！！&&&&****")
        myRound+=1
    else:       
        input("很遗憾回答错误<..>   请花费一颗金币重新开始游戏,或者按下ctrl+c结束游戏 正确答案是"+str(challenge))        
        money-=1

    pass
 

   









 


 

