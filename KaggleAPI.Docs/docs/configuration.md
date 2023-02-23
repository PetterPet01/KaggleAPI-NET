---
id: configuration
title: Configuration
---

To configure the Kaggle API client functionality, the `KaggleConfiguration` class exists.

```csharp
var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };

var api = new KaggleClient(config);
```

We won't cover every possible configuration in this part, head over to the specific guides for that in [Authentication](authentication).

## HttpClient Notes

One important part of the configuration is the used `HttpClient`. By default, every time `Authenticate()` is called on `KaggleClient`, a new `HttpClient` is created in the background. For Web Applications that require a lot of different clients due to user based access tokens, it is **not** advised to create a new `HttpClient` from scratch with every HTTP call. Instead, a default (static) `HttpClient` should be used to create a new `KaggleClient` with a new access token.

Consider the following HTTP Endpoint:

```csharp
HttpResponseMessage Get()
{
    var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };

    var api = new KaggleClient(); 
    api.Authenticate(config);
}
```

This creates a new `HttpClient` every time a request is made, which can be quite bad for the performance. Instead, we should use a static `HttpClient`:

```csharp
// somewhere global/static
public static HttpClient httpClient = new HttpClient();

HttpResponseMessage Get()
{
    var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };

    var api = new KaggleClient();
    api.Authenticate(httpClient, config);
}
```

This way, a single `HttpClient` will be used.
