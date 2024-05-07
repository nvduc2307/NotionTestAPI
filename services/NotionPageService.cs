using Newtonsoft.Json;
using Notion.iservices;
using Notion.models;
using RestSharp;

namespace Notion.services;
public class NotionPageService : INotionPageService
{
    private NotionInfo _notionInfo;
    public NotionPageService(NotionInfo notionInfo)
    {
        _notionInfo = notionInfo;
    }
    public async Task<int> CreateContentForDatabase(NotionPage notionPage)
    {
        var url = "/v1/pages/";
        var result = 0;
        try
        {
            var content = JsonConvert.SerializeObject(notionPage);
            var options = new RestClientOptions(NotionInfo.urlBaseNotion){MaxTimeout = -1,};
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Post);
            request.AddHeader(NotionRequireHeader.ContentType, "application/json");
            request.AddHeader(NotionRequireHeader.NotionVersion, NotionInfo.versionNotion);
            request.AddHeader(NotionRequireHeader.Authorization, _notionInfo.IntegrationSecretNotion);
            request.AddStringBody(content, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            Console.WriteLine(content);
        }
        catch (System.Exception)
        {
            
        }
        return result;
    }
}