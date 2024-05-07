namespace Notion.models;
public class NotionTitle : NotionElement {
    public object title { get; set; }
    public NotionTitle()
    {
        id = "title";
        type = nameof(NotionElementType.title);
        title = new {};

    }
}