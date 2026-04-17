![Logo](https://apps.exactonline.com/content/css/images/exact-logo-red.png)

[![](https://img.shields.io/nuget/v/ExactOnline.Client.Sdk.svg)](https://www.nuget.org/packages/ExactOnline.Client.Sdk)

C# client SDK for the Exact Online RESTFul API
===============

This is the original client SDK from Exact which doesn't seem to be supported anymore.
This is what has been changed/added in this repo since their last commit:

* Bulk support thanks to @aspin-fvdmolen.
* Sync support (building further on the same concept).
* A lot of code clean-up and some refactoring.
* All projects have been migrated to SDK style projects building for net472 and netstandard2.0 where possible (not yet for the OAuth project due to the winforms dependency).
* Support for building nuget packages (4.0.0-beta for now).
* ExactOnlineAuthenticator is added to more easily work with the OAuth authentication.
* A WebApplication sample is added to show the usage of that authenticator.
* The ConsoleApplication sample is changed to also use that authenticator.
* ExactOnline.Client.Sdk.Sync project (full entity sync support) has been added as well as an example Sync.EntityFramework target.
* The ConsoleApplication sample is updated to show the usage of the sync support.
* Add ExactOnline.Client.OAuth2 => .netstandard2.0 OAuth2 support (thanks to https://github.com/titarenko/OAuth2)
* Add ExactOnline.Client.Sync.EntityFrameworkCore => .NET 6 EntityFrameworkCore Sync support
* Add WebApplicationCore sample that uses these new projects
* Use HttpClient iso HttpWebRequest
* Replace GetAccessTokenDelegate with async Func
* Pass cancellationtokens everywhere
* Update packages
* Update tests

<h3>Dare to contribute</h3>

At Exact we know how important it is to have an API you can easily work with. In reaching this ambition the next step is to offer you a C# client SDK which gives you a set of easy functions to call our API. Just some words for otherwise long statements. Combine it with the right Oauth framework and you are quickly on your way.

We have built this open-source client SDK so that you, as part of our community, can contribute to this C# SDK or just build a client SDK for the language you love. Check out the Github page and start contributing to make all our lives more focused.

<h3>Quick Guide</h3>

The Exact Online Client SDK provides a rich application framework and simplifies the interconnection with the Exact Online RESTful API. The Exact Online API can help you to quickly integrate with Exact Online and build innovative apps within the .NET environment. This document describes how to get started using the Exact Online Client SDK. 

The sample code in this document is in C#

<h4>1.	Reference Libraries</h4>

Include following references in your web project:
- ExactOnline.Client.Models.dll
- ExactOnline.Client.Sdk

Add following namespaces in your code file:
```
using ExactOnline.Client.Models;
using ExactOnline.Client.Sdk;
```

<h4>2.  OAuth</h4>
We have added an ExactOnline.Client.OAuth module, which takes care of the authentication. In this way you can easily execute the integration tests and user acceptance tests. When you want to use this you need to fill in your own client ID, client secret and callback url in the ExactOnline.Client.Sdk.TestContext in the TestObjectsCreator class. Of course you also can use your own OAuth implementation. 

<h4>3.	Initializing Exact Client </h4>

ExactOnline Client only supports the OAuth authentication for the API calls. To know more about OAuth please refer to <a href="https://developers.exactonline.com/#Getting started.html%3FTocPath%3DAuthorization%2520(OAuth2)%7C_____0">Getting started - OAuth</a>. To initialize the ExactOnlineClient object you need to provide the “apiEndPoint” & “AccessTokenDelegate”:
```
ExactOnlineClient client = new ExactOnlineClient (apiEndPoint, AccessTokenDelegate);
```

For multiple administrations you can also specify the division

```
ExactOnlineClient client = 
        new ExactOnlineClient (apiEndPoint, division, AccessTokenDelegate);
```

<u>apiEndPoint:</u> Exact Online URL for your country. For Netherlands: “https://start.exactonline.nl”

<u>AccessTokenDelegate:</u> Delegate that will be responsible to retrieve and refresh the OAuth access token. See the example application to see how it is used <a href="https://github.com/exactonline/exactonline-api-dotnet-client/blob/master/src/ConsoleApplication/Program.cs">Example OAuth.</a>

<h4>4.	Insert Record Using ExactOnline Client </h4>
To insert a record using the ExactOnlineClient instance for a specific entity, you first need to initialize the object for that entity and provide all the required values.

E-g: To insert a new “Document” record, first create a new object for “Document”:
```
Document document = new Document
		   {
			Subject = "User Acceptance Test Document",
			Body = "User Acceptance Test Document",
			Category = GetCategoryId (client),
			Type = 55, //Miscellaneous
			DocumentDate = DateTime.Now.Date
		   };
```

Use the ExactOnlineClient instance to insert the record:
```
bool created = client.For<Document>().Insert(ref document);
```

“Insert” method takes entity object as reference and returns “true” if the insertion is successful.
After successful insertion, the document ID can be retrieved as:

<i>document.ID</i>

<h4>5.	Retrieve Data Using Exact Client </h4>

To retrieve the entity based on ID you can use the “GetEntity” function. E-g: Retrieve document by ID: 
```
client.For<Document>().GetEntity(documentID);
```

To retrieve specific fields of the entity based on filter use “select” and “where” functions. E-g: Retrieve document with specific fields for subject “User Acceptance Test Document”
```
var fields = new[] { "ID, Subject, Type, Category" };
var documents = client.For<Document>().Select(fields).Top(5).Where("Subject+eq+'User Acceptance Test Document'").Get();
```
If  “Select(fields)” is not specified you will get an exception. You always need to specify which fields you need, to limit the data traffic.
Paging: For paging use “Skip” and “Top” functions
```
var documents = client.For<Document>().Select(fields).Skip(2).Top(5)
.Where("Subject+eq+'User Acceptance Test Document'").Get();
```

<h4>6.	Update Record Using Exact Client</h4>

Update the fields in the entity object and pass this object to “Update” function of the ExactOnlineClient instance, which will return “true” if update is successful.
```
document.Subject = "User Acceptance Test Document Updated";
document.DocumentDate = DateTime.Now.Date;
var updated = client.For<Document>().Update(document);
```

<h4>7.	Delete Record</h4>
To delete a record you need to provide the entity object to the “Delete” method of the ExactOnlineClient instance, which will return “true” if the operation is successful.
```
var deleted = client.For<Document>().Delete(document);
```

<h4>8.	Synchronization</h4>

The `ExactOnline.Client.Sdk.Sync` package adds full-entity synchronization on top of the core SDK. It transparently picks the best available endpoint per entity type (`/sync` when supported, otherwise `/bulk`, otherwise the standard single endpoint), pages through all results, deduplicates sync-feed doubles, tracks a watermark (`Timestamp` or `Modified`), and — for entities that support it — applies deletions from the `/sync/Deleted` feed.

There are two ways to drive a sync:

1. **`ISyncTarget` / `ISyncTargetController<TModel>`** — a simple "sink" contract when all you want to do is read entities and write them to somewhere.
2. **`SyncOperation<TModel>`** — a configurable orchestrator with per-page delegates, giving full control over watermarks, page handling, and deletions without implementing the full controller contract.

<h5>8.1. Sync target approach</h5>

Implement `ISyncTargetController<TModel>` (or derive from `SyncTargetControllerBase<TModel>`) for each entity you want to sync, and expose them via an `ISyncTarget` (or `SyncTargetBase`). The SDK takes care of pagination, deduplication, and the `Deleted` feed.

```csharp
public class MySyncTarget : SyncTargetBase
{
    protected override ISyncTargetController<TModel> CreateControllerFor<TModel>() =>
        new MyController<TModel>(/* connection, dbContext, ... */);
}

// Run the sync for a single entity type
var result = await client
    .For<Account>()
    .SynchronizeWithAsync(new MySyncTarget(), client, fields: ["Name", "Code"], ct: ct);

Console.WriteLine(result); // SyncResult.ToString() reports records read / upserted / deleted

// Or sync everything the SDK knows how to sync
foreach (var modelType in ExactOnlineSynchronizer.SupportedModelTypes)
{
    await client.SynchronizeWithAsync(new MySyncTarget(), modelType, ct: ct);
}
```

Ready-made EF / EF Core targets are provided in `ExactOnline.Client.Sdk.Sync.EntityFramework` and `ExactOnline.Client.Sdk.Sync.EntityFrameworkCore`.

<h5>8.2. SyncOperation approach</h5>

When you need per-page context (page index, skiptoken, raw entities before dedup, running totals) or you don't want to implement `ISyncTargetController<TModel>` just to plug in some custom logic, use `SyncOperation<TModel>` directly. The operation exposes a fluent builder — each `With*` / `On*` / `ReportProgress` call configures one stage and returns the same instance.

```csharp
var result = await SyncOperation.For<Account>(client)
    .WithFields("Name", "Code")

    // Return the highest Timestamp you have stored locally. Called once at the start of the run.
    .WithMaxTimestamp(ct => LoadWatermarkAsync(ct))

    // Optional: for non-sync endpoints on models that expose a Modified field.
    .WithMaxModified(ct => Task.FromResult<DateTime?>(null))

    // Called once per page. Return the number of records actually inserted or updated.
    .OnPage(async page =>
    {
        Console.WriteLine($"Page {page.PageIndex} ({page.Entities.Count} entities), skiptoken={page.SkipToken}");
        return await UpsertAsync(page.Entities, page.Fields, page.CancellationToken);
    })

    // Called once per page of deleted keys. Return the number actually deleted.
    .OnDeletedPage(dp => DeleteAsync(dp.EntityKeys, dp.CancellationToken))

    // Optional: called after each page with a cumulative progress snapshot.
    .ReportProgress(p => Console.WriteLine(
        $"  read={p.RecordsRead}, upserted={p.RecordsInsertedOrUpdated}, " +
        $"deletedRead={p.RecordsDeletedRead}, deleted={p.RecordsDeleted}"))

    .RunAsync(ct);
```

`SyncPageContext<TModel>` gives you everything the loop knows about the current page:

| Property | Description |
|---|---|
| `Entities` | Deduplicated entities ready to persist (after `FilterDoubles` for sync-feed endpoints). |
| `RawEntities` | The original page as returned by the API — useful if you need the raw sync-feed history. |
| `PageIndex` | 0-based page counter within the run. |
| `SkipToken` | Skiptoken for the *next* page (null on the last page). |
| `MaxTimestamp` / `MaxModified` | Watermark the run started from. |
| `Fields` | Final list of selected fields (identifier/timestamp/modified added automatically). |
| `EndpointType` | `Sync`, `Bulk`, or `Single` — picked automatically per entity. |
| `CancellationToken` | The token passed to `RunAsync`. |

`DeletedPageContext` exposes the same shape for `OnDeletedPage` (`EntityKeys`, `PageIndex`, `SkipToken`, `MaxTimestamp`, `CancellationToken`).

Any stage you omit is simply skipped — e.g. leave out `.OnDeletedPage(...)` if you don't care about deletions, or `.WithMaxTimestamp(...)` for a full reload from `Timestamp = 0`. A `SyncOperation<TModel>` is single-use; create a new one for each run.

<h5>8.3. Example: sync Accounts into a local store</h5>

The snippet below is a complete, runnable example that pulls `Account` changes into a simple in-memory store and deletes rows the API reports as removed. Swap the store for EF/Dapper/whatever you actually persist to.

```csharp
using ExactOnline.Client.Models.CRM;
using ExactOnline.Client.Sdk.Controllers;
using ExactOnline.Client.Sdk.Sync;

var client = new ExactOnlineClient(
    exactOnlineUrl: "https://start.exactonline.nl/",
    division: 123456,
    accesstokenFunc: ct => accessTokenProvider.GetAsync(ct));

// Pretend this is your local database
var accounts = new Dictionary<Guid, Account>();
var watermark = 0L;

var result = await SyncOperation.For<Account>(client)
    .WithFields("Name", "Code", "Email", "Country")

    .WithMaxTimestamp(_ => Task.FromResult(watermark))

    .OnPage(page =>
    {
        foreach (var a in page.Entities)
        {
            accounts[a.ID] = a;
            if (a.Timestamp > watermark) watermark = a.Timestamp;
        }
        return Task.FromResult(page.Entities.Count);
    })

    .OnDeletedPage(dp =>
    {
        var removed = 0;
        foreach (var key in dp.EntityKeys)
        {
            if (accounts.Remove(key)) removed++;
        }
        return Task.FromResult(removed);
    })

    .ReportProgress(p => Console.WriteLine($"page {p.PageIndex}: +{p.RecordsInsertedOrUpdated} / -{p.RecordsDeleted}"))

    .RunAsync(CancellationToken.None);

Console.WriteLine(result);
// store `watermark` somewhere durable so the next run only fetches changes since this one
```

<h4>9.	Exceptions</h4>
<table>
<tr><td><b>Exception</b></td>		<td><b>Description</b></td></tr>
<tr><td>UnauthorizedException</td>	<td>When access token is null or invalid while making a request</td></tr>
<tr><td>BadRequestException</td>	<td>When composed request is not in a correct format</td></tr>
<tr><td>ForbiddenException</td>	<td>When some specific operation is not allowed to be performed.</td></tr>
<tr><td>NotFoundException</td>	<td>When trying to retrieve a record which does not exist in the database.</td></tr>
<tr><td>InternalServerError</td>	<td>Please find the validation errors in the error message.</td></tr>
</table>
