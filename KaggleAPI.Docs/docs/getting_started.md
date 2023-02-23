---
id: getting_started
title: Getting Started
---

import InstallInstructions from '../src/install_instructions'

## Adding KaggleAPI-NET to your project

The library can be added to your project via the following methods:

### Package Managers

<InstallInstructions />

### Add DLL Manually

You can also grab the latest compiled DLL from our [GitHub Releases Page](https://github.com/petterpet01/kaggleapi-net/releases). It can be added to your project via Visual Studio or directly in your `.csproj`:

```xml
<ItemGroup>
  <Reference Include="KaggleAPI.Web">
    <HintPath>..\Dlls\KaggleAPI.Web.dll</HintPath>
  </Reference>
</ItemGroup>
```

### Compile Yourself

```sh
git clone https://github.com/PetterPet01/KaggleAPI-NET.git
cd KaggleAPI-NET
dotnet restore
dotnet build

ls -la KaggleAPI.Web/bin/Debug/netstandard2.0/KaggleAPI.Web.dll
```

## First API Calls

You're now ready to issue your first calls to the Kaggle API, a small console example:

```csharp
using System;
using System.Threading.Tasks;
using KaggleAPI.Web;
using KaggleAPI.Web.Models;

class Program
{
    static async Task Main()
    {
        var kaggle = new KaggleClient();

        kaggle.Authenticate(
            new KaggleConfiguration { username = "YourUsername", key = "YourKey" },
            method: AuthenticationMethod.Direct
        );

        List<CompetitionInquiry>? result = await kaggle.CompetitionsList(
            group: CompetitionGroup.General,
            category: CompetitionCategory.All,
            sortBy: CompetitionSortBy.LatestDeadline,
            page: 1,
            search: "searchTerm",
            quiet: true
        );

        foreach (CompetitionInquiry competition in result)
            Console.WriteLine(competition.title);
    }
}
```

## Guides

All other relevant topics are covered in the "Guides" section in the sidebar!
