namespace Notion.models;
public abstract class NotionElement {
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}

public enum NotionElementType {
    database_id,
    page_id,
    database,
    people,
    title,
    text
}
