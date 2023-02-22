KaggleAPI-NET provides an easy to use .NET Standard API client for [Kaggle API](https://github.com/Kaggle/kaggle-api). It aims to expose the complete Kaggle API in native C#, which allows .NET developers to programmatically interact with available Kaggle API services using the cross-platform .NET Standard specification.

KaggleAPI-NET is [Apache-2.0](https://www.apache.org/licenses/LICENSE-2.0)-licensed, so personal and commmercial use alike is allowed. For further details, see the [LICENSE](LICENSE) file.

### Features


* ✅ Typed responses and requests to over 24 endpoints. Complete and always up to date.
* ✅ Supports `.NET Standard 2.X`, which includes all major platforms, including mobile:
  * `.NET Framework`
  * `UWP`
  * `.NET Core`
  * `Xamarin.Forms`
* ✅ Allow full control of one's `HttpClient`, thereby maximizing flexibility
* ✅ Logging supported
* ✅ All features from Kaggle API reimplemented for ease of development
* ✅ Complete unit testing for all functionalities <sup>*\*Not well-developed yet\**</sup>

### Target

`.NET Standard 2.0`

### Get KaggleAPI-NET

For ease of installation, you can add the lastest release of KaggleAPI-NET into your project using [Nuget](https://www.nuget.org/packages/KaggleAPI.Web/)

### Usage

* Include the library
```cs
using KaggleAPI.Web;
using KaggleAPI.Web.Models;
```
* Create a new client
```cs
KaggleClient kaggle = new KaggleClient();
```
* Provide the client credentials for authentication
```cs
kaggle.Authenticate(
    new KaggleConfiguration { username = "YourUsername", key = "YourKey" },
    method: AuthenticationMethod.Direct
);
```
* Make a request to list all Kaggle competitions given below queries
```cs
List<CompetitionInquiry>? result = await kaggle.CompetitionsList(search: "searchTerm");
```
* Print the titles of all competitions found
```cs
foreach (CompetitionInquiry competition in result)
    Console.WriteLine(competition.title);
```
* Finally, dispose the client
#### Note that this disposes all copy of the credentials, and not the HttpClient.
```cs
kaggle.Dispose()
```

More examples can be found on the website and in the KaggleAPI.Tests directory.

### Docs and Usage

More Information, Installation-Instructions, Examples, Guides can be found at [petterpet01.github.io/KaggleAPI-NET/](https://petterpet01.github.io/KaggleAPI-NET/)

### Installation

Installation Instructions can be found in the [Getting Started Guide](https://petterpet01.github.io/KaggleAPI-NET/docs/getting_started)

### Donations

If you want to support this project or my work in general, you can send me supportive messages and donate a buck or two.