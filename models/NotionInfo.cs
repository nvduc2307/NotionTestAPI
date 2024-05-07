namespace Notion.models;
public class NotionInfo {
    public const string urlBaseNotion = "https://api.notion.com";
    public const string versionNotion = "2022-06-28";
    public string IntegrationSecretNotion { get; set; }
    public string ParentPageId { get; set; }
    public NotionInfo(string integrationSecretNotion, string ParentPageId)
    {
        IntegrationSecretNotion = integrationSecretNotion;
    }
}