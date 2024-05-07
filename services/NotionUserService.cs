using Newtonsoft.Json;
using Notion.iservices;
using Notion.models;
using RestSharp;
namespace Notion.services;
public class NotionUserService : INotionUserService
{
    private NotionInfo _notionInfo;

    public NotionUserService(NotionInfo notionInfo)
    {
        _notionInfo = notionInfo;
    }
    public async Task<IEnumerable<NotionUser>> GetUsers()
    {
        var url = "/v1/users";
        var results = new List<NotionUser>();
        try
        {
            var options = new RestClientOptions(NotionInfo.urlBaseNotion)
            {
            MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader(NotionRequireHeader.NotionVersion, NotionInfo.versionNotion);
            request.AddHeader(NotionRequireHeader.Authorization, _notionInfo.IntegrationSecretNotion);
            RestResponse response = await client.ExecuteAsync(request);
            var contents = response.Content;
            var st = contents.IndexOf("[");
            var en = contents.IndexOf("]");
            var usersContent = contents.Substring(st, en - st + 1);
            results = JsonConvert.DeserializeObject<List<NotionUser>>(usersContent);
        }
        catch (System.Exception)
        {
        }
        return results;
    }
}