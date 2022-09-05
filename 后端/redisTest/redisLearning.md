###Redis学习 草稿
    redis 秘钥 
            新增 Set {Name}:{Name2} {value}
            获取 Get {Name}:{Name2} 若为空则返回null

                EXPIRE
                    设置过期时间 TTL的总和
                    EXPIRE {Name}:{Name2} {Secound}
                TTL
                    生存时间 
                    -1为永久存在
                    -2表示秘钥不存在
                    TTL {Name}:{Name2} =>返回现在的存活时间
    redis 计数器
            INCR {Name} 
            DEL {Name}
            //默认会后面都是1 如果想增加或减少自定义数量
            INCRBY {Name} {Number}
            DELBY {Name} {Number}
            //优点:体现了原子性 在多用户操作的时候不会出现只增加了一次的问题

            官方解释:
            问题在于，只要有一个客户端使用密钥，以这种方式执行增量才会起作用。查看如果两个客户端同时访问此密钥会发生什么情况：
            客户端 A 读取计数为 10。
            客户端 B 读取次数计为 10。
            客户端 A 递增 10 并将计数设置为 11。
            客户端 B 递增 10 并将计数设置为 11。
            我们希望值为 12，但结果是 11！这是因为以这种方式递增值不是原子操作。在 Redis 中调用 INCR 命令将防止这种情况发生，因为它是原子操作。
    redis 复杂类型
        1、 List 重要命令是RPUSH，LPUSH，LLEN，LRANGE，LPOP和RPOP
                RPUSH:在队列末尾添加一个数 RPUSH {Name} {value},{value}...
                LPUSH:在队列头部添加一个数 LPUSH {Name} {value},{value}...
                LRANGE:获取list中的数据 LRANGE {Start} {End}
                        End =-1代表检索至队列末尾 -2检索至倒数第二位
                LLEN:返回列表的长度 LLEN {Name}
                LPOP:在列表头部弹出一个数据 并返回它
                RPOP:在列表末尾弹出一个数据 并返回它
        2、 Set 重要命令是SADD，SREM，SISMEMBER，SMEMBERS和SUNION