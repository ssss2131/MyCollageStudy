namespace BlazorApp1.ComponentClass.MyTable
{
    public record ButtonStyle(string MyHref)
    {
        public string Text { get; set; } = "按钮控件";
        public string Style { get; set; } = "btn btn-info";
    }
}
