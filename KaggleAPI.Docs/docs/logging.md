---
id: logging
title: Logging
---

The library provides a way to inject your own, custom API information logger. Logged messages are replicated one-to-one with all Kaggle API CLI messages. By default, no logging is performed.

```csharp
var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };

var api = new KaggleClient(new YourLogger());
api.Authenticate(config, method: AuthenticationMethod.Direct);
```

The `IKaggleInformationLogger` interface can be found [here](https://github.com/PetterPet01/KaggleAPI-NET/blob/main/KaggleAPI.Web/Interfaces/IKaggleInformationLogger.cs).

## ConsoleLogger

We can create a simple console-based logger:

```csharp
using KaggleAPI.Web.Interfaces;

public class ConsoleLogger : IKaggleInformationLogger
{
    public void OnLog(string message)
    {
        Console.WriteLine(message);
    }
}
```

And use it as is:

```csharp
var config = new KaggleConfiguration { username = "YourUsername", key = "YourKey" };

var api = new KaggleClient(new ConsoleLogger());
api.Authenticate(config, method: AuthenticationMethod.Direct);
```

This logger produces a simple console output similar to the Kaggle API CLI:

```text
Downloaded metadata to D:/Kaggle/dataset-metadata.json

successfully updated dataset metadata
```
