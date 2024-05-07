using System;
using System.Net.Mime;
using System.Collections.Generic;
using Newtonsoft.Json;
using Notion.models;
using Notion.services;
using RestSharp;

var secretApi = "secret_y4s9gMzvcGgA3qkeukLYiI0VtMmHIX3l8wZZ4pErJVa";
var parentPageId = "51908c44571e4db0999a780a49e76dc0";

var notionInfo = new NotionInfo(secretApi, parentPageId);
var notionUserService = new NotionUserService(notionInfo);
var notionDatabaseService = new NotionDatabaseService(notionInfo);
var notionPageService = new NotionPageService(notionInfo);

var notionDatabase = new NotionDatabase() {
    parent = new NotionParentPage(parentPageId),
    title = new List<object>() {
        new {
            text = new NotionText("Manage Beam"),
        }
    },
    properties = new {
        user = new NotionUser(){
            name = "user",
            people = new {},
        },
        name = new NotionTitle() {
            name = "name",
            title = new {},
        },
    }
};
var databaseId = await notionDatabaseService.CreateANewDatabase(notionDatabase);

var notionPage = new NotionPage() {
    parent = new NotionParentDatabase(databaseId),
    properties = new {
        name = new {
            title = new List<object>() {
                new {
                    text = new NotionText("Hy")
                }
            }
        }
    }
};
await notionPageService.CreateContentForDatabase(notionPage);
