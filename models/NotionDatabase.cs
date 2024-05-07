using System.Text.Json.Serialization;

namespace Notion.models;
public class NotionDatabase {
    public NotionParentPage parent { get; set; }
    public object title {get; set; }
    public object properties {get; set; }
}
public class NotionParentDatabase {
    public string type {get; set; }
    public string database_id {get; set; }
    public NotionParentDatabase(string _database_id)
    {
        type = nameof(NotionElementType.database_id);
        database_id = _database_id;
    }
}
public class NotionDatabaseId {
    public string id { get; set; }
}