/*
 * Copyright 2023 PetterPet
 * Copyright 2020 Kaggle Inc
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

 * Copyright 2019 Kaggle Inc
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

using KaggleAPI.Web.Helpers;
using KaggleAPI.Web.Models;
using MimeTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KaggleAPI.Web
{
    internal enum Operation
    {
        CompetitionsList,
        CompetitionsSubmissionsList,
        CompetitionsSubmissionsUrl,
        CompetitionsSubmissionsUpload,
        CompetitionsSubmissionsSubmit,
        CompetitionsDataListFiles,
        CompetitionsDataDownloadFile,
        CompetitionsDataDownloadFiles,
        CompetitionDownloadLeaderboard,
        CompetitionViewLeaderboard,
        DatasetsList,
        DatasetsListFiles,
        DatasetsStatus,
        DatasetsView,
        DatasetsDownloadFile,
        DatasetsDownload,
        DatasetsUploadFile,
        DatasetsCreateVersionById,
        DatasetsCreateVersion,
        DatasetsCreateNew,
        KernelsList,
        KernelPush,
        KernelPull,
        KernelOutput,
        KernelStatus,
        MetadataGet,
        MetadataPost
    }

    internal sealed class KaggleAPI : IDisposable
    {
        static readonly string baseUrl = "https://www.kaggle.com/api/v1";
        static readonly Dictionary<Operation, string> opToPath = new Dictionary<Operation, string>
        {
            { Operation.CompetitionsList, "/competitions/list" },
            { Operation.CompetitionsSubmissionsList, "/competitions/submissions/list/{0}" },
            { Operation.CompetitionsSubmissionsUrl, "/competitions/{0}/submissions/url/{1}/{2}" },
            {
                Operation.CompetitionsSubmissionsUpload,
                "/competitions/submissions/upload/{0}/{1}/{2}"
            },
            { Operation.CompetitionsSubmissionsSubmit, "/competitions/submissions/submit/{0}" },
            { Operation.CompetitionsDataListFiles, "/competitions/data/list/{0}" },
            { Operation.CompetitionsDataDownloadFile, "/competitions/data/download/{0}/{1}" },
            { Operation.CompetitionsDataDownloadFiles, "/competitions/data/download-all/{0}" },
            { Operation.CompetitionDownloadLeaderboard, "/competitions/{0}/leaderboard/download" },
            { Operation.CompetitionViewLeaderboard, "/competitions/{0}/leaderboard/view" },
            { Operation.DatasetsList, "/datasets/list" },
            { Operation.DatasetsListFiles, "/datasets/list/{0}/{1}" },
            { Operation.DatasetsStatus, "/datasets/status/{0}/{1}" },
            { Operation.DatasetsView, "/datasets/view/{0}/{1}" },
            { Operation.DatasetsDownload, "/datasets/download/{0}/{1}" },
            { Operation.DatasetsDownloadFile, "/datasets/download/{0}/{1}/{2}" },
            { Operation.DatasetsUploadFile, "/datasets/upload/file/{0}/{1}" },
            { Operation.DatasetsCreateVersionById, "/datasets/create/version/{0}" },
            { Operation.DatasetsCreateVersion, "/datasets/create/version/{0}/{1}" },
            { Operation.DatasetsCreateNew, "/datasets/create/new" },
            { Operation.KernelsList, "/kernels/list" },
            { Operation.KernelPush, "/kernels/push" },
            { Operation.KernelPull, "/kernels/pull" },
            { Operation.KernelOutput, "/kernels/output" },
            { Operation.KernelStatus, "/kernels/status" },
            { Operation.MetadataPost, "/datasets/metadata/{0}/{1}" },
            { Operation.MetadataGet, "/datasets/metadata/{0}/{1}" },
        };

        internal string authToken = "";
        internal HttpClient client = new HttpClient();

        internal KaggleAPI(string authToken, HttpClient client)
        {
            this.authToken = authToken;
            this.client = client;
        }

        internal KaggleAPI(string username, string key, HttpClient client)
            : this(
                Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format($"{username}:{key}"))),
                client
            ) { }

        internal HttpRequestMessage CreateKaggleRequestMessage(
            string method,
            Uri requestUri,
            string accept = "application/json"
        )
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), requestUri);

            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authToken}");
            request.Headers.TryAddWithoutValidation("User-Agent", "Swagger-Codegen/1/python");
            if (accept != string.Empty)
                request.Headers.TryAddWithoutValidation("Accept", "application/json");

            return request;
        }

        void UpdateQuery(
            UriBuilder builder,
            Dictionary<string, string> queries,
            bool skipEmptyQuery = true
        )
        {
            if (skipEmptyQuery)
                foreach (string key in queries.Keys)
                    if (queries[key] == null)
                        queries.Remove(key);

            builder.Query = new FormUrlEncodedContent(queries).ReadAsStringAsync().Result;
        }

        //List competitions
        internal HttpRequestMessage CraftCompetitionsList(
            string group = "general",
            string category = "all",
            string sortBy = "latestDeadline",
            int? page = 1,
            string search = null
        )
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsList;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += opToPath[op];

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "group", group },
                    { "category", category },
                    { "sortBy", sortBy },
                    { "page", page.HasValue ? page.ToString() : null },
                    { "search", search }
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsSubmissionsList(string id, int? page = 1)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsSubmissionsList;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            UpdateQuery(url, new Dictionary<string, string>() { { "page", page.ToString() } });

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsSubmissionsUrl(
            string fileName,
            string id,
            long contentLength,
            long lastModifiedDateUtc
        )
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsSubmissionsUrl;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id, contentLength, lastModifiedDateUtc);

            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("POST"), url.Uri);
            request.Headers.TryAddWithoutValidation("Authorization", $"Basic {authToken}");
            request.Headers.TryAddWithoutValidation("User-Agent", "Swagger-Codegen/1/python");
            request.Headers.TryAddWithoutValidation("Accept", "application/json");

            if (fileName != string.Empty)
            {
                var multipartContent = new MultipartFormDataContent
                {
                    { new StringContent(fileName), "fileName" }
                };
                request.Content = multipartContent;
            }

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsSubmissionsUpload(
            string file,
            string guid,
            long contentLength,
            long lastModifiedDateUtc
        )
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsSubmissionsUpload;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], guid, contentLength, lastModifiedDateUtc);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);
            var multipartContent = new MultipartFormDataContent();

            var file1 = new ByteArrayContent(File.ReadAllBytes(file));
            file1.Headers.Add("Content-Type", MimeTypeMap.GetMimeType(Path.GetExtension(file)));
            multipartContent.Add(file1, "file", Path.GetFileName(file));

            request.Content = multipartContent;

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsSubmissionsSubmit(
            string blobFileTokens,
            string submissionDescription,
            string id
        )
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsSubmissionsSubmit;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            var multipartContent = new MultipartFormDataContent
            {
                { new StringContent(blobFileTokens), "blobFileTokens" },
                { new StringContent(submissionDescription), "submissionDescription" }
            };
            request.Content = multipartContent;

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsDataListFiles(string id)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsDataListFiles;

            if (id == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter id when calling CompetitionsDataListFiles"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsDataDownloadFile(string id, string filename)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsDataDownloadFile;

            if (id == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter id when calling CompetitionsDataDownloadFile"
                );
            if (filename == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter filename when calling CompetitionsDataDownloadFile"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id, filename);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri, "");

            return request;
        }

        internal HttpRequestMessage CraftCompetitionsDataDownloadFiles(string id)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionsDataDownloadFiles;

            if (id == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter id when calling CompetitionsDataDownloadFiles"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftCompetitionDownloadLeaderboard(string id)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionDownloadLeaderboard;

            if (id == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter id when calling CompetitionDownloadLeaderboard"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftCompetitionViewLeaderboard(string id)
        {
            //Response is in application/json
            Operation op = Operation.CompetitionViewLeaderboard;

            if (id == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter id when calling CompetitionViewLeaderboard"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftDatasetsList(
            string group = "internal",
            string sortBy = "hottest",
            string filetype = "all",
            string license = "all",
            string tagids = null,
            string search = null,
            string user = null,
            int? page = 1,
            long? maxSize = null,
            long? minSize = null
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsList;

            if (page != null && page < 1)
                throw new ArgumentException(
                    "The required parameter page must be at least 1 when calling DatasetsList"
                );
            if (maxSize != null && maxSize < 1)
                throw new ArgumentException(
                    "The required parameter maxSize must be at least 1 when calling DatasetsList"
                );
            if (minSize != null && minSize < 1)
                throw new ArgumentException(
                    "The required parameter minSize must be at least 1 when calling DatasetsList"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "group", group },
                    { "sortBy", sortBy },
                    { "filetype", filetype },
                    { "license", license },
                    { "tagids", tagids },
                    { "search", search },
                    { "user", user },
                    { "page", page.ToString() },
                    { "maxSize", maxSize.ToString() },
                    { "minSize", minSize.ToString() },
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftDatasetsListFiles(string ownerSlug, string datasetSlug)
        {
            //Response is in application/json
            Operation op = Operation.DatasetsListFiles;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsListFiles"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsListFiles"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftDatasetsStatus(string ownerSlug, string datasetSlug)
        {
            //Response is in application/json
            Operation op = Operation.DatasetsStatus;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsStatus"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsStatus"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftDatasetsDownload(
            string ownerSlug,
            string datasetSlug,
            string datasetVersionNumber = null
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsDownload;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsDownload"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsDownload"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            if (datasetVersionNumber != string.Empty)
                UpdateQuery(
                    url,
                    new Dictionary<string, string>()
                    {
                        { "datasetVersionNumber", datasetVersionNumber }
                    }
                );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri, "");

            return request;
        }

        internal HttpRequestMessage CraftDatasetsDownloadFile(
            string ownerSlug,
            string datasetSlug,
            string filename,
            string datasetVersionNumber = ""
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsDownloadFile;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsDownload"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsDownload"
                );
            if (filename == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter filename when calling DatasetsDownload"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug, filename);

            if (datasetVersionNumber != string.Empty)
                UpdateQuery(
                    url,
                    new Dictionary<string, string>()
                    {
                        { "datasetVersionNumber", datasetVersionNumber }
                    }
                );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri, "");

            return request;
        }

        internal HttpRequestMessage CraftDatasetsView(string ownerSlug, string datasetSlug)
        {
            //Response is in application/json
            Operation op = Operation.DatasetsView;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsView"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsView"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri, "");

            return request;
        }

        internal HttpRequestMessage CraftDatasetsUploadFile(
            string fileName,
            long contentLength,
            long lastModifiedDateUtc
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsUploadFile;

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], contentLength, lastModifiedDateUtc);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            var multipartContent = new MultipartFormDataContent
            {
                { new StringContent(fileName), "fileName" }
            };
            request.Content = multipartContent;

            return request;
        }

        internal HttpRequestMessage CraftDatasetsCreateVersionById(
            int? id,
            DatasetNewVersionRequest datasetNewVersionRequest
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsCreateVersionById;

            if (id == null)
                throw new ArgumentException(
                    "Missing the required parameter id when calling DatasetsCreateVersionById"
                );
            if (datasetNewVersionRequest == null)
                throw new ArgumentException(
                    "Missing the required parameter datasetNewVersionRequest when calling DatasetsCreateVersionById"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], id);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            request.Content = new StringContent(
                JsonHelper.SerializeObject(datasetNewVersionRequest)
            );
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return request;
        }

        internal HttpRequestMessage CraftDatasetsCreateVersion(
            string ownerSlug,
            string datasetSlug,
            DatasetNewVersionRequest datasetNewVersionRequest
        )
        {
            //Response is in application/json
            Operation op = Operation.DatasetsCreateVersion;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling DatasetsCreateVersion"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling DatasetsCreateVersion"
                );
            if (datasetNewVersionRequest == null)
                throw new ArgumentException(
                    "Missing the required parameter datasetNewVersionRequest when calling DatasetsCreateVersion"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            request.Content = new StringContent(
                JsonHelper.SerializeObject(datasetNewVersionRequest)
            );
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return request;
        }

        internal HttpRequestMessage CraftDatasetsCreateNew(DatasetNewRequest datasetNewRequest)
        {
            //Response is in application/json
            Operation op = Operation.DatasetsCreateNew;

            if (datasetNewRequest == null)
                throw new ArgumentException(
                    "Missing the required parameter datasetNewRequest when calling DatasetsCreateNew"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            request.Content = new StringContent(JsonHelper.SerializeObject(datasetNewRequest));
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return request;
        }

        internal HttpRequestMessage CraftKernelsList(
            int? page = 1,
            int? pageSize = 20,
            string search = null,
            string group = "everyone",
            string user = "",
            string language = "all",
            string kernelType = "all",
            string outputType = "all",
            string sortBy = "hotness",
            string dataset = "",
            string competition = "",
            string parentKernel = ""
        )
        {
            //Response is in application/json
            Operation op = Operation.KernelsList;

            //if (kernelPushRequest == null)
            //    throw new ArgumentException("Missing the required parameter kernelPushRequest when calling KernelPush");

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "page", page.ToString() },
                    { "pageSize", pageSize.ToString() },
                    { "search", search },
                    { "group", group },
                    { "user", user },
                    { "language", language },
                    { "kernelType", kernelType },
                    { "outputType", outputType },
                    { "sortBy", sortBy },
                    { "dataset", dataset },
                    { "competition", competition },
                    { "parentKernel", parentKernel },
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftKernelPush(KernelPushRequest kernelPushRequest)
        {
            //Response is in application/json
            Operation op = Operation.KernelPush;

            if (kernelPushRequest == null)
                throw new ArgumentException(
                    "Missing the required parameter kernelPushRequest when calling KernelPush"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            request.Content = new StringContent(JsonHelper.SerializeObject(kernelPushRequest));
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return request;
        }

        internal HttpRequestMessage CraftKernelPull(string userName = "", string kernelSlug = "")
        {
            //Response is in application/json
            Operation op = Operation.KernelPull;

            if (userName == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter userName when calling KernelPull"
                );
            if (kernelSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter kernelSlug when calling KernelPull"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "userName", userName },
                    { "kernelSlug", kernelSlug },
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftKernelOutput(string userName = "", string kernelSlug = "")
        {
            //Response is in application/json
            Operation op = Operation.KernelOutput;

            if (userName == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter userName when calling KernelOutput"
                );
            if (kernelSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter kernelSlug when calling KernelOutput"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "userName", userName },
                    { "kernelSlug", kernelSlug },
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftKernelStatus(string userName = "", string kernelSlug = "")
        {
            //Response is in application/json
            Operation op = Operation.KernelStatus;

            if (userName == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter userName when calling KernelStatus"
                );
            if (kernelSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter kernelSlug when calling KernelStatus"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op]);

            UpdateQuery(
                url,
                new Dictionary<string, string>()
                {
                    { "userName", userName },
                    { "kernelSlug", kernelSlug },
                }
            );

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftMetadataGet(string ownerSlug = "", string datasetSlug = "")
        {
            //Response is in application/json
            Operation op = Operation.MetadataGet;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling MetadataGet"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling MetadataGet"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("GET", url.Uri);

            return request;
        }

        internal HttpRequestMessage CraftMetadataPost(
            string ownerSlug,
            string datasetSlug,
            DatasetUpdateSettingsRequest datasetUpdateSettingsRequest
        )
        {
            //Response is in application/json
            Operation op = Operation.MetadataPost;

            if (ownerSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter ownerSlug when calling MetadataPost"
                );
            if (datasetSlug == string.Empty)
                throw new ArgumentException(
                    "Missing the required parameter datasetSlug when calling MetadataPost"
                );
            if (datasetUpdateSettingsRequest == null)
                throw new ArgumentException(
                    "Missing the required parameter datasetUpdateSettingsRequest when calling MetadataPost"
                );

            UriBuilder url = new UriBuilder(baseUrl);
            url.Path += string.Format(opToPath[op], ownerSlug, datasetSlug);

            HttpRequestMessage request = CreateKaggleRequestMessage("POST", url.Uri);

            request.Content = new StringContent(
                JsonHelper.SerializeObject(datasetUpdateSettingsRequest)
            );
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            return request;
        }

        /*
* Why does the param category equal to "" instead of "all"?
* Although the docs specify the default value of category as equal to "all",
* there is some API conflicts on the server end of Kaggle,
* which would NOT allow the query "category" as "all" by throwing
* a 400 and "Unrecognized HostSegment enum value" in the response Json
* => Therefore, the appropriate behavior is to leave "category" as "",
* similar to the implementation of the original Kaggle API
*/
        internal async Task<HttpResponseMessage> CompetitionsList(
            string group = "general",
            string category = "",
            string sortBy = "latestDeadline",
            int? page = 1,
            string search = null
        )
        {
            HttpRequestMessage request = CraftCompetitionsList(
                group,
                category,
                sortBy,
                page,
                search
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionsSubmissionsList(
            string id,
            int? page = 1
        )
        {
            HttpRequestMessage request = CraftCompetitionsSubmissionsList(id, page);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionsSubmissionsUrl(
            string fileName,
            string id,
            long contentLength,
            long lastModifiedDateUtc
        )
        {
            HttpRequestMessage request = CraftCompetitionsSubmissionsUrl(
                fileName,
                id,
                contentLength,
                lastModifiedDateUtc
            );

            return await client.SendAsync(request);
        }

        //internal async void CompetitionsSubmissionsUpload(string file, string guid, long contentLength, long lastModifiedDateUtc)
        //{
        //    HttpRequestMessage request = api.CraftCompetitionsSubmissionsUpload(file, guid, contentLength, lastModifiedDateUtc);

        //    HttpResponseMessage response = await api.client.SendAsync(request);
        //    Debug.WriteLine(await response.Content.ReadAsStringAsync());
        //}

        internal async Task<HttpResponseMessage> CompetitionsSubmissionsSubmit(
            string blobFileTokens,
            string submissionDescription,
            string id
        )
        {
            HttpRequestMessage request = CraftCompetitionsSubmissionsSubmit(
                blobFileTokens,
                submissionDescription,
                id
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionsDataListFiles(string id)
        {
            HttpRequestMessage request = CraftCompetitionsDataListFiles(id);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionsDataDownloadFile(
            string id,
            string filename
        )
        {
            HttpRequestMessage request = CraftCompetitionsDataDownloadFile(id, filename);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionsDataDownloadFiles(string id)
        {
            HttpRequestMessage request = CraftCompetitionsDataDownloadFiles(id);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionDownloadLeaderboard(string id)
        {
            HttpRequestMessage request = CraftCompetitionDownloadLeaderboard(id);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> CompetitionViewLeaderboard(string id)
        {
            HttpRequestMessage request = CraftCompetitionViewLeaderboard(id);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsList(
            string group,
            string sortBy,
            string fileType,
            string license,
            string tagIds,
            string search,
            string user,
            int? page,
            long? maxSize,
            long? minSize
        )
        {
            HttpRequestMessage request = CraftDatasetsList(
                group,
                sortBy,
                fileType,
                license,
                tagIds,
                search,
                user,
                page,
                maxSize,
                minSize
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsListFiles(
            string ownerSlug,
            string datasetSlug
        )
        {
            HttpRequestMessage request = CraftDatasetsListFiles(ownerSlug, datasetSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsStatus(
            string ownerSlug,
            string datasetSlug
        )
        {
            HttpRequestMessage request = CraftDatasetsStatus(ownerSlug, datasetSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsDownload(
            string ownerSlug,
            string datasetSlug,
            string datasetVersionNumber = null
        )
        {
            HttpRequestMessage request = CraftDatasetsDownload(
                ownerSlug,
                datasetSlug,
                datasetVersionNumber
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsDownloadFile(
            string ownerSlug,
            string datasetSlug,
            string filename,
            string datasetVersionNumber = null
        )
        {
            HttpRequestMessage request = CraftDatasetsDownloadFile(
                ownerSlug,
                datasetSlug,
                filename,
                datasetVersionNumber
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsView(string ownerSlug, string datasetSlug)
        {
            HttpRequestMessage request = CraftDatasetsView(ownerSlug, datasetSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsUploadFile(
            string fileName,
            long contentLength,
            long lastModifiedDateUtc
        )
        {
            HttpRequestMessage request = CraftDatasetsUploadFile(
                fileName,
                contentLength,
                lastModifiedDateUtc
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsCreateVersionById(
            int? id,
            DatasetNewVersionRequest datasetNewVersionRequest
        )
        {
            HttpRequestMessage request = CraftDatasetsCreateVersionById(
                id,
                datasetNewVersionRequest
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsCreateVersion(
            string ownerSlug,
            string datasetSlug,
            DatasetNewVersionRequest datasetNewVersionRequest
        )
        {
            HttpRequestMessage request = CraftDatasetsCreateVersion(
                ownerSlug,
                datasetSlug,
                datasetNewVersionRequest
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> DatasetsCreateNew(
            DatasetNewRequest datasetNewRequest
        )
        {
            HttpRequestMessage request = CraftDatasetsCreateNew(datasetNewRequest);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> KernelsList(
            int? page = 1,
            int? pageSize = 20,
            string search = null,
            string group = "everyone",
            string user = "",
            string language = "all",
            string kernelType = "all",
            string outputType = "all",
            string sortBy = "hotness",
            string dataset = "",
            string competition = "",
            string parentKernel = ""
        )
        {
            HttpRequestMessage request = CraftKernelsList(
                page,
                pageSize,
                search,
                group,
                user,
                language,
                kernelType,
                outputType,
                sortBy,
                dataset,
                competition,
                parentKernel
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> KernelPush(KernelPushRequest kernelPushRequest)
        {
            HttpRequestMessage request = CraftKernelPush(kernelPushRequest);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> KernelPull(
            string userName = "",
            string kernelSlug = ""
        )
        {
            HttpRequestMessage request = CraftKernelPull(userName, kernelSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> KernelOutput(
            string userName = "",
            string kernelSlug = ""
        )
        {
            HttpRequestMessage request = CraftKernelOutput(userName, kernelSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> KernelStatus(
            string userName = "",
            string kernelSlug = ""
        )
        {
            HttpRequestMessage request = CraftKernelStatus(userName, kernelSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> MetadataGet(
            string ownerSlug = "",
            string datasetSlug = ""
        )
        {
            HttpRequestMessage request = CraftMetadataGet(ownerSlug, datasetSlug);

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> MetadataPost(
            string ownerSlug,
            string datasetSlug,
            DatasetUpdateSettingsRequest datasetUpdateSettingsRequest
        )
        {
            HttpRequestMessage request = CraftMetadataPost(
                ownerSlug,
                datasetSlug,
                datasetUpdateSettingsRequest
            );

            return await client.SendAsync(request);
        }

        internal async Task<HttpResponseMessage> GetRequest(string uri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return await client.SendAsync(request);
        }

        public void Dispose()
        {
            authToken = null;
        }
    }
}
