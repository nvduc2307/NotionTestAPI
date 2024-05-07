namespace Notion.models;
public class NotionPage {
    public object parent { get; set; }
    public object properties { get; set; }
}
public class NotionParentPage {
    public string page_id {get; set;}
    public string type {get; set;}
    public NotionParentPage(string _page_id)
    {
        type = nameof(NotionElementType.page_id);
        page_id = _page_id;
    }
}