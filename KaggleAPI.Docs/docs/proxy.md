---
id: proxy
title: Proxy
---

import useBaseUrl from '@docusaurus/useBaseUrl';

There are three main approaches to using proxy in the client:

* Adding proxy directly to `HttpClient`
* Adding proxy to `HttpClientHandler`
* Adding proxy to as a URL in `KaggleConfiguration`

### Adding proxy directly to `HttpClient`

We can instantiate a new `HttpClient` with a custom `HttpClientHandler` that has our `WebProxy`:

```csharp
// Include neccessary dependencies
using KaggleAPI.Web;
using KaggleAPI.Web.Models;
using System.Net;
using System.Net.Http;

var config = new KaggleConfiguration
{
    username = "YourUsername",
    key = "YourKey"
};

HttpClient client = new HttpClient(
    new HttpClientHandler { Proxy = new WebProxy("127.0.0.1:8080") }
);

var api = new KaggleClient();
api.Authenticate(client, config, method: AuthenticationMethod.Direct);
```

### Adding proxy to `HttpClientHandler`

We can instantiate a new `HttpClientHandler` that has our `WebProxy`:

```csharp
// Include neccessary dependencies
using KaggleAPI.Web;
using KaggleAPI.Web.Models;
using System.Net;
using System.Net.Http;

var config = new KaggleConfiguration
{
    username = "YourUsername",
    key = "YourKey"
};

HttpClientHandler handler = new HttpClientHandler
{
    Proxy = new WebProxy("127.0.0.1:8080")
};

var api = new KaggleClient();
api.Authenticate(handler, config, method: AuthenticationMethod.Direct);
```

### Adding proxy to as a URL in `KaggleConfiguration` (Not recommended)

Although limited in usage, we can use the `proxy` property from `KaggleConfiguration` as the proxy URL for all in/out-bound traffic:

```csharp
// Include neccessary dependencies
using KaggleAPI.Web;
using KaggleAPI.Web.Models;
using System.Net;
using System.Net.Http;

var config = new KaggleConfiguration
{
    username = "YourUsername",
    key = "YourKey",
    proxy = "127.0.0.1:8080"
};

var api = new KaggleClient();
api.Authenticate(config, method: AuthenticationMethod.Direct);
```

As an example, [mitmproxy](https://mitmproxy.org/) can be used to inspect the requests and responses:

<img alt="mitmproxy" src={useBaseUrl('img/Mitmproxy_logo.svg')} height="100px" />
