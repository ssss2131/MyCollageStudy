#coding:gbk
 
from random import random, randrange, uniform
 
print("<<<��ӭ�����½����Ϸ<<<");

print("�����������˺�����------");

account = "admin"
password = "123456"
money = 0
inputAccount = ""
inputPassword = ""
inputRes = False

while inputRes== False:
    inputAccount = input("�����������˺�")
    print("---------------------------------")
    inputPassword = input("��������������");
    
    if inputPassword == password and inputAccount == account :
       inputRes = True
    else:
        print("!!�˺Ż����������!!")
     
print("!!**��ӭ������Ϸ**!!")        

input("****��Ϸ��Ҫ֧��1ö���****���»س���ʼ,ctrl+c������Ϸ")
a = 0
chock = 1
myRound = 1
endRound = 10
roundInput = 0

while myRound<=endRound:
    if money -1<0:
        input("!!!�Բ����Ҳ���,���ֵ!!");
        a = input("�������ֵ���")
        print(a)
        if int(a)<=0:
            print("!!!�Բ���,���������д���")
        else:
            money +=int(a);
            print("��ֵ�ɹ� ��ǰ���Ϊ"+str(money))
    print("��ӭ������"+str(myRound)+"�ؿ�;\r ��������"+"0"+"��"+str(2*(myRound))+"��Χ�в�ȡһ�������")
    challenge = randrange(0,2*(myRound))
    
    roundInput = input("����������")
    if int(challenge) == int(roundInput):
        print("*****&&&&������ϲ�����ش���ȷ����&&&&****")
        myRound+=1
    else:       
        input("���ź��ش����<..>   �뻨��һ�Ž�����¿�ʼ��Ϸ,���߰���ctrl+c������Ϸ ��ȷ����"+str(challenge))        
        money-=1

    pass
 

   









 


 

