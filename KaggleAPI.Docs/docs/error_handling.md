---
id: error_handling
title: Error Handling
---

API calls can fail when input data is malformed or the server detects issues with the request. As an example, the following request obviously fails:

```csharp
List<CompetitionDataFileInquiry>? result = await api.CompetitionListFiles(
    competition: "BadCompetitionName"
);
```

When a request fails, a `KaggleAPIException` is thrown.

## KaggleAPIException

A very general API error. The message is either *(1)* parsed from the API response's JSON body or *(2)* Json deserialization error messages, both with a status code in string format appended. The response is available as a public property.

```csharp
try
{
    List<CompetitionDataFileInquiry>? result = await api.CompetitionListFiles(
        competition: "BadCompetitionName"
    );
}
catch (KaggleAPIException e)
{
    //Prints:
    /*  Permission 'competitions.get' was denied
        Status code: 403 Forbidden  */
    Console.WriteLine(e.Message);
    // Prints: Forbidden
    Console.WriteLine(e.Response?.StatusCode);
}
```