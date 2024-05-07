using Notion.models;

namespace Notion.iservices;
public interface INotionDatabaseService {
    public Task<string> CreateANewDatabase(NotionDatabase notionDatabase);
}