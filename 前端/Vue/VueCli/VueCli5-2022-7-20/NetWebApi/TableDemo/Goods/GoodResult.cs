namespace TableDemo.Goods
{
    public record GoodResult(int status,string message)
    {
        public List<MyGood>? Data { get; set; }
    }

    public class MyGood
    {
        public int id { get; set; }
        public string? goods_name { get; set; }
        public decimal goods_price { get; set; }
        public string[]? tages { get; set; }
        public bool inputVisable { get; set; }
        public string? inputValue { get; set; }
    }
}
