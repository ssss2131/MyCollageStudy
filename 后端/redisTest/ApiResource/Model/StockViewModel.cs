namespace ApiResource.Model
{
    public class StockViewModel
    {
        public int id { get; set; }
        public string? bookName { get; set; }
        public string? isbn { get; set; }
        public float count { get; set; }
        public int authorId { get; set; }


    }
}
