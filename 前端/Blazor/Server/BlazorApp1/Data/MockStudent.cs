namespace BlazorApp1.Data
{
    public record MockStudent(string Name,string Say,string Sex)
    {
        public int Age { get; set; }
    }
}
