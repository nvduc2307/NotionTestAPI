using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Notion.models;
public class NotionUser : NotionElement {
    public object people { get; set; }
    public NotionUser()
    {
        id = "%5E~Sz";
        type = nameof(NotionElementType.people);
        people = new List<object>();
    }
}
public class NotionPeople {
    [JsonPropertyName("object")]
    public string object1 { get; set; }
    public string id {get; set;}
    public string name {get; set;}
    public string avatar_url {get; set;}
    public string type {get; set;}
}
public enum NotionUserType {
    person,
    bot
}