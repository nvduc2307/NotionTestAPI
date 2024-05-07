using Newtonsoft.Json;
using Notion.iservices;
using Notion.models;
using RestSharp;

namespace Notion.services;
public class NotionDatabaseService : INotionDatabaseService
{
    private NotionInfo _notionInfo;
    public NotionDatabaseService(NotionInfo notionInfo)
    {
        _notionInfo = notionInfo;
    }
    public async Task<string> CreateANewDatabase(NotionDatabase notionDatabase)
    {
        var result = "";
        var url = "/v1/databases/";
        try
        {
            var content = JsonConvert.SerializeObject(notionDatabase);
            var options = new RestClientOptions(NotionInfo.urlBaseNotion){MaxTimeout = -1,};
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader(NotionRequireHeader.ContentType, "application/json");
            request.AddHeader(NotionRequireHeader.NotionVersion, NotionInfo.versionNotion);
            request.AddHeader(NotionRequireHeader.Authorization, _notionInfo.IntegrationSecretNotion);
            
            request.AddStringBody($"{content}", DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            result = JsonConvert.DeserializeObject<NotionDatabaseId>(response.Content)?.id;
            Console.WriteLine(response.Content);
            Console.WriteLine(result);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            result = "";
        }
        return result;
    }
}