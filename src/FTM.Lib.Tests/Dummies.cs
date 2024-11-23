﻿using Microsoft.Extensions.Logging.Abstractions;

namespace FTM.Lib.Tests;

public static class Dummies
{
    private static Guid Guid() => System.Guid.NewGuid();

    public static string GuidString() => Guid().ToString();

    public static MastodonStatus MastodonStatus(string status = "lorem ipsum",
        string? language = null, MastodonStatusVisibility? visibility = null)
    {
        return new MastodonStatus(status, language, visibility);
    }

    public static FeedItem FeedItem(string? feedId = null, string? itemId = null,
        string title = "Dummy Title", string? summary = "Dummy Summary",
        string? content = "Dummy Content", string language = "en-US",
        string? link = "https://example.com")
    {
        feedId ??= GuidString();
        itemId ??= GuidString();
        var publishDate = new DateTimeOffset(2024, 10, 1, 15, 0, 0, TimeSpan.FromHours(2));

        var uri = string.IsNullOrEmpty(link)
            ? null
            : new Uri(link);

        return new FeedItem(feedId, itemId, title, publishDate,
            summary, content, language, uri);
    }

    public static WorkerContext WorkerContext(FeedConfiguration configuration)
    {
        return new WorkerContext
        {
            Configuration = configuration,
            Logger = NullLogger.Instance,
            HttpClient = new HttpClient()
        };
    }

    public static FeedConfiguration FeedConfiguration(
        string title = "Dummy Feed", Uri? feedUri = null,
        string summarySeparator = "",
        string mastodonServer = "https://social.colormixed.de",
        string mastodonAccessToken = "abc")
    {
        feedUri ??= new Uri("https://example.com/feed.xml");

        return new FeedConfiguration(title, feedUri, summarySeparator,
            mastodonServer, mastodonAccessToken);
    }

    public static FeedIdItemId FeedIdItemId(string? feedId = null, string? itemId = null)
    {
        feedId ??= GuidString();
        itemId ??= GuidString();
        return new FeedIdItemId(feedId, itemId);
    }

    public static Feed Feed(string? id = null,
        string website = "https://example.com/feed.xml",
        string title = "Dummy Feed", string description = "Dummy Description",
        string language = "en-US", FeedItem[]? items = null)
    {
        id ??= GuidString();
        items ??= [];

        var lastUpdatedTime = new DateTimeOffset(2024, 10, 1, 15, 0, 0, TimeSpan.FromHours(2));

        return new Feed(
            id,
            new Uri(website),
            title,
            lastUpdatedTime,
            description,
            language,
            items);
    }
}