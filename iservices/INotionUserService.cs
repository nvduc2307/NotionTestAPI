using Notion.models;

namespace Notion.iservices;
public interface INotionUserService {
    public Task<IEnumerable<NotionUser>> GetUsers();
}