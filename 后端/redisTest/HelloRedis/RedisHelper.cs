using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace HelloRedis
{
    public class RedisHelper
    {
        private static string? ConnectionString= "localhost:6379,connectRetry=1,syncTimeout=1000,connectTimeout=1000";

        private static ConnectionMultiplexer GetConnection()
        {
            var con = ConnectionMultiplexer.Connect(ConnectionString);
            return con;
        }
        //String 类型
        public static string GetString(string key)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            return db.StringGet(key);
        }
        public static void SetString(string key, string value)
        { 
            using var con = GetConnection();
            var db = con.GetDatabase();
            db.StringSet(key, value);
            Console.WriteLine("设置成功");
        }
        //List类型
        public static List<object> ListGet(string key)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            
            List<object> list = new List<object>();
            for (int i = 0; i < db.ListLength(key); i++)
            {
                list.Add(db.ListGetByIndex(key, i));
                Console.WriteLine(db.ListGetByIndex(key,i));
            }
            return list;
        }
        public static void ListPush(string key,string value)
        {
            using var con = GetConnection(); 
            var db = con.GetDatabase();
            db.ListLeftPush(key, value);
        }
        //Set类型
        public static ISet<object> SetGet(string key)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            HashSet<object> set = new HashSet<object>();
            foreach (var item in db.SetMembers(key))
            {
                set.Add(item);
                Console.WriteLine(item);
            }    
            return set;
        }
        public static void SetIn(string key, string value)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            db.SetAdd(key, value);

        }
        //Hash类型
        public static Hashtable GetHash(string hashKeyName)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            var keys = db.HashKeys(hashKeyName);
            Hashtable hash = new Hashtable();
            foreach (var item in keys)
            {
                hash.Add(keys, item);
                Console.WriteLine(item);
            }
            return hash;
        }
        public static void HashAdd(string hashKeyName, string keyName,string value)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            db.HashSet(hashKeyName, keyName, value);
        }
        //删除键
        public static void DeleteKey(string key)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            if (!db.StringGet(key).IsNullOrEmpty)
            {
                db.KeyExpire(key, TimeSpan.FromSeconds(0));
                Console.WriteLine("Remove OK");
            }          
        }
        //删除list的key
        public static void DeleteListKey(string key)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            if (ListGet(key) != null)
            {
                db.KeyExpire(key, TimeSpan.FromSeconds(0));
                Console.WriteLine("Remove OK");
            }
        }
        public static void TimeOut(string keyName, TimeSpan dispire)
        {
            using var con = GetConnection();
            var db = con.GetDatabase();
            var res = db.KeyExpire(keyName, dispire);
            Console.WriteLine(res);
        }

    }
}
