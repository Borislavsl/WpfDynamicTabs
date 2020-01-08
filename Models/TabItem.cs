namespace Models
{
    public class TabItem
    {
        public string Header { get; set; }
        public string Content { get; set; }

        public TabItem(string header, string content)
        {
            Header = header;
            Content = content;
        }
    }
}
