namespace Notion.models;
public class NotionText {
    public string content { get; set; }
    public string link  { get; set; }
    public NotionText(string _content)
    {
        content = _content;
    }
}