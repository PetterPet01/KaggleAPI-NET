/*
 * Copyright 2023 PetterPet
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using KaggleAPI.Web;
using KaggleAPI.Web.Models;
using Microsoft.Extensions.Configuration;
using static KaggleAPI.Tests.Information;
using static KaggleAPI.Tests.MockFields;
using static KaggleAPI.Web.KaggleEnum;

namespace KaggleAPI.Tests
{
    static class Information
    {
        static IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("MockInformation.json")
            .Build();

        public static readonly string MockUsername = configuration["username"];
        public static readonly string MockKey = configuration["key"];
        public static readonly string MockCompetitionName = configuration["competitionName"];
        public static readonly string MockDatasetName = configuration["datasetName"];
        public static readonly string MockKernelName = configuration["kernelName"];
    }

    static class MockFields
    {
        public static readonly HttpClient client = new HttpClient();
    }

    public class AuthenticationTest
    {
        [Fact]
        public void Authenticate_InputIsKaggleConfiguration_ReturnDirect()
        {
            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            Assert.True(method == AuthenticationMethod.Direct);
        }

        [Fact]
        public void Authenticate_InputIsFilename_ReturnFile()
        {
            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                filename: @"MockAuthentication\kaggle.json",
                method: AuthenticationMethod.File
            );
            Assert.True(method == AuthenticationMethod.File);
        }

        [Fact]
        public void Authenticate_InputIsEnvironmentMethod_ReturnEnvironment()
        {
            Environment.SetEnvironmentVariable("KAGGLE_USERNAME", MockUsername);
            Environment.SetEnvironmentVariable("KAGGLE_KEY", MockKey);

            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                method: AuthenticationMethod.Environment
            );
            Assert.True(method == AuthenticationMethod.Environment);
        }

        [Fact]
        public void Authenticate_InputIsUserMethod_ReturnUser()
        {
            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                method: AuthenticationMethod.User
            );
            Assert.True(method == AuthenticationMethod.User);
        }

        [Fact]
        public void Authenticate_InputIsAutoMethod_ReturnDirect()
        {
            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Auto
            );
            Assert.True(method == AuthenticationMethod.Direct);
        }

        [Fact]
        public void Authenticate_InputIsAutoMethod_ReturnFile()
        {
            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                filename: @"MockAuthentication\kaggle.json",
                method: AuthenticationMethod.Auto
            );
            Assert.True(method == AuthenticationMethod.File);
        }

        [Fact]
        public void Authenticate_InputIsAutoMethod_ReturnEnvironment()
        {
            Environment.SetEnvironmentVariable("KAGGLE_USERNAME", MockUsername);
            Environment.SetEnvironmentVariable("KAGGLE_KEY", MockKey);

            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                filename: "wrong.json",
                method: AuthenticationMethod.Auto
            );
            Assert.True(method == AuthenticationMethod.Environment);
        }

        [Fact]
        public void Authenticate_InputIsAutoMethod_ReturnUser()
        {
            Environment.SetEnvironmentVariable("KAGGLE_USERNAME", null);
            Environment.SetEnvironmentVariable("KAGGLE_KEY", null);

            KaggleClient api = new KaggleClient();
            AuthenticationMethod method = api.Authenticate(
                client,
                filename: "wrong.json",
                method: AuthenticationMethod.Auto
            );
            Assert.True(method == AuthenticationMethod.User);
        }
    }

    public class ClientTests
    {
        //static void AssertNoExceptions(KaggleStatus status)
        //{
        //    if (status.Exception != null && status.Exception.code != null)
        //        throw new Exception(
        //            $"{status.Exception.message}{Environment.NewLine}{status.Exception.code}"
        //        );
        //}

        public async void CompetitionsList_InputIsNotNull()
        {
            int page = 1;
            string searchTerm = "people";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<CompetitionInquiry>? result = await api.CompetitionsList(
                group: CompetitionGroup.General,
                category: CompetitionCategory.All,
                sortBy: CompetitionSortBy.LatestDeadline,
                page: page,
                search: searchTerm,
                quiet: true
            );

            foreach (CompetitionInquiry competition in result)
                Console.WriteLine(competition.title);

            Assert.NotNull(result);
        }

        [Fact]
        public async void CompetitionsList_InputIsNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<CompetitionInquiry>? result = await api.CompetitionsList(
                null,
                null,
                null,
                null,
                null,
                false
            );

            Assert.NotNull(result);
        }

        [Fact]
        public async void CompetitionSubmit_InputIsNotNull()
        {
            string fileToSubmitPath = "MockDataset\\sample_submission.csv.7z";
            string message = "Updated submission";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            CompetitionSubmitStatus? result = await api.CompetitionSubmit(
                path: fileToSubmitPath,
                message: message,
                competition: MockCompetitionName
            );

            Assert.NotNull(result);
        }

        [Fact]
        public async void CompetitionSubmissions_InputIsNotNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<CompetitionSubmissionInquiry>? result = await api.CompetitionSubmissions(
                competition: MockCompetitionName
            );

            Assert.NotNull(result);
        }

        [Fact]
        public async void CompetitionListFiles_InputIsNotNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<CompetitionDataFileInquiry>? result = await api.CompetitionListFiles(
                competition: MockCompetitionName
            );

            Assert.NotNull(result);
        }

        [Fact]
        public async void CompetitionDownload_InputIsCompetition()
        {
            string expectedFilename =
                $@"competitions\{MockCompetitionName}\{MockCompetitionName}.zip";
            string rootDir = "competitions";

            //Clear up directory
            if (Directory.Exists(rootDir))
                Directory.Delete(rootDir, true);

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            await api.CompetitionDownload(competition: MockCompetitionName);

            Assert.True(File.Exists(expectedFilename));

            //Clear up directory
            Directory.Delete(rootDir, true);
        }

        [Fact]
        public async void CompetitionDownload_InputIsCompetitionAndFilename()
        {
            string filename = "test.csv";
            string expectedFilename = $@"competitions\{MockCompetitionName}\{filename}";
            string rootDir = "competitions";

            //Clear up directory
            if (Directory.Exists(rootDir))
                Directory.Delete(rootDir, true);

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            await api.CompetitionDownload(competition: MockCompetitionName, filename: filename);

            Assert.True(File.Exists(expectedFilename));

            //Clear up directory
            Directory.Delete(rootDir, true);
        }

        [Fact]
        public async void CompetitionLeaderboard_InputIsViewTrue()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            CompetitionLeaderboardInquiry? Result = await api.CompetitionLeaderboard(
                competition: MockCompetitionName,
                null,
                view: true
            );

            Assert.NotNull(Result);
        }

        [Fact]
        public async void CompetitionLeaderboard_InputIsDownloadTrue()
        {
            string expectedFilename =
                $@"competitions\{MockCompetitionName}\{MockCompetitionName}.zip";
            string rootDir = "competitions";

            //Clear up directory
            if (Directory.Exists(rootDir))
                Directory.Delete(rootDir, true);

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            await api.CompetitionLeaderboard(
                competition: MockCompetitionName,
                null,
                download: true
            );

            Assert.True(File.Exists(expectedFilename));

            //Clear up directory
            Directory.Delete(rootDir, true);
        }

        [Fact]
        public async void DatasetList_InputSearchIsDemographics()
        {
            string search = "demographics";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<DatasetInquiry>? result = await api.DatasetList(search: search);

            Assert.NotNull(result);
        }

        [Fact]
        public async void DatasetView_InputIsDataset()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            DatasetInquiry? result = await api.DatasetView(MockDatasetName);

            Assert.NotNull(result);
        }

        [Fact]
        public async void DatasetMetadata_InputIsDatasetPathIsNullUpdateIsFalse()
        {
            string[] dataset = MockDatasetName.Split('/');
            string expectedFilename = $@"datasets\{dataset[0]}\{dataset[1]}\dataset-metadata.json";
            string rootDir = "datasets";

            //Clear up directory
            if (Directory.Exists(rootDir))
                Directory.Delete(rootDir, true);

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            string savedPath = await api.DatasetMetadata(
                MockDatasetName,
                path: null,
                update: false
            );

            Assert.NotNull(savedPath);
            Assert.Contains(expectedFilename, savedPath);
            Assert.True(File.Exists(savedPath));

            //Clear up directory
            Directory.Delete(rootDir, true);
        }

        [Fact]
        public async void DatasetMetadata_InputIsDatasetAndPathIsNotNullAndUpdateIsTrue()
        {
            string datasetPath = @"MockDataset";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            await api.DatasetMetadata(MockDatasetName, path: datasetPath, update: true);
        }

        [Fact]
        public async void DatasetListFiles_InputIsDataset()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            DatasetDataFilesInquiry? result = await api.DatasetListFiles(MockDatasetName);

            Assert.NotNull(result);
        }

        [Fact]
        public async void DatasetStatus_InputIsDataset()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            string result = await api.DatasetStatus(MockDatasetName);

            Assert.NotNull(result);
        }

        [Fact]
        public async void DatasetDownload_InputIsDataset()
        {
            string[] dataset = MockDatasetName.Split('/');
            string expectedFilename = $@"datasets\{dataset[0]}\{dataset[1]}\{dataset[1]}.zip";
            string rootDir = "datasets";

            //Clear up directory
            if (Directory.Exists(rootDir))
                Directory.Delete(rootDir, true);

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            bool? succeeded = await api.DatasetDownload(MockDatasetName);

            Assert.True(succeeded);
            Assert.True(File.Exists(expectedFilename));

            //Clear up directory
            Directory.Delete(rootDir, true);
        }

        [Fact]
        public async void DatasetCreateVersion_InputIsPathAndVersionNotes()
        {
            string datasetPath = @"MockDataset";
            string versionNotes = "Updated data";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            DatasetCreateVersionStatus? result = await api.DatasetCreateVersion(
                datasetPath,
                versionNotes
            );

            Assert.NotNull(result);
        }

        [Fact]
        public async void DatasetCreateNew_InputIsPath()
        {
            string datasetPath = @"MockDataset";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            DatasetCreateNewStatus? result = await api.DatasetCreateNew(datasetPath);

            Assert.NotNull(result);
        }

        [Fact]
        public async void KernelsList_InputIsNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<KernelInquiry>? result = await api.KernelsList();

            Assert.NotNull(result);
        }

        [Fact]
        public void KernelsInitialize_InputIsNull()
        {
            string expectedFilename = Path.Combine(
                Directory.GetCurrentDirectory(),
                "kernel-metadata.json"
            );

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            string result = api.KernelsInitialize();

            Assert.NotNull(result);
            Assert.Equal(expectedFilename, result);
            Assert.True(File.Exists(result));

            File.Delete(result);
        }

        [Fact]
        public async void KernelsPush_InputIsNull()
        {
            string kernelPath = @"MockKernel";

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            KernelPushStatus? result = await api.KernelsPush(kernelPath);

            Assert.NotNull(result);
        }

        [Fact]
        public async void KernelsPull_InputIsNull()
        {
            string[] kernel = MockKernelName.Split('/');
            string expectedDirectory = Path.Combine(
                Directory.GetCurrentDirectory(),
                $@"kernels\{kernel[0]}\{kernel[1]}"
            );

            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            string result = await api.KernelsPull(MockKernelName, null, true);

            Assert.NotNull(result);
            Assert.Equal(expectedDirectory, result);

            Directory.Delete(result, true);
        }

        [Fact]
        public async void KernelsOutput_InputIsNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            List<string>? result = await api.KernelsOutput(MockKernelName, null, true);

            Assert.NotNull(result);

            foreach (string file in result)
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async void KernelsStatus_InputIsNull()
        {
            KaggleClient api = new KaggleClient();
            api.Authenticate(
                client,
                new KaggleConfiguration { username = MockUsername, key = MockKey },
                method: AuthenticationMethod.Direct
            );
            KernelStatusInquiry? result = await api.KernelsStatus(MockKernelName);

            Assert.NotNull(result);
        }
    }
}
