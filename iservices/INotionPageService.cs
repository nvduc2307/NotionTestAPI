using Notion.models;

namespace Notion.iservices;
public interface INotionPageService {
    public Task<int> CreateContentForDatabase(NotionPage notionPage);
}