using ICSharpCode.SharpZipLib.Zip;
using KaggleAPI.Web.Exceptions;
using KaggleAPI.Web.Helpers;
using KaggleAPI.Web.Interfaces;
using KaggleAPI.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static KaggleAPI.Web.KaggleEnum;

namespace KaggleAPI.Web
{
    public static class KaggleEnum
    {
        #region EnumHandling
        internal static Dictionary<int, AuthenticationMethod> AuthenticationMethodNamesPriorityMap =
            new Dictionary<int, AuthenticationMethod>
            {
                { 0, AuthenticationMethod.Direct },
                { 1, AuthenticationMethod.File },
                { 2, AuthenticationMethod.Environment },
                { 3, AuthenticationMethod.User },
                { 4, AuthenticationMethod.Auto },
            };

        public enum AuthenticationMethod
        {
            Direct,
            File,
            Environment,
            User,
            Auto,
        }

        public enum ConfigurationName
        {
            Username,
            Key,
            Competition,
            Path,
            Proxy,
            SSL_CA_CERT
        }

        internal static Dictionary<PushKernelType, string> pushKernelTypesMap = new Dictionary<
            PushKernelType,
            string
        >
        {
            { PushKernelType.Script, "script" },
            { PushKernelType.Notebook, "notebook" },
        };

        public enum PushKernelType
        {
            Script,
            Notebook,
        }

        internal static Dictionary<PushLanguageType, string> pushLanguageTypesMap = new Dictionary<
            PushLanguageType,
            string
        >
        {
            { PushLanguageType.Python, "python" },
            { PushLanguageType.R, "r" },
            { PushLanguageType.RMarkdown, "rmarkdown" },
        };

        public enum PushLanguageType
        {
            Python,
            R,
            RMarkdown,
        }

        internal static Dictionary<PushPinningType, string> pushPinningTypesMap = new Dictionary<
            PushPinningType,
            string
        >
        {
            { PushPinningType.Original, "original" },
            { PushPinningType.Latest, "latest" },
        };

        public enum PushPinningType
        {
            Original,
            Latest,
        }

        internal static Dictionary<ListLanguage, string> listLanguagesMap = new Dictionary<
            ListLanguage,
            string
        >
        {
            { ListLanguage.All, "all" },
            { ListLanguage.Python, "python" },
            { ListLanguage.R, "r" },
            { ListLanguage.SQLite, "sqlite" },
            { ListLanguage.Julia, "julia" },
        };

        public enum ListLanguage
        {
            All,
            Python,
            R,
            SQLite,
            Julia,
        }

        internal static Dictionary<ListKernelType, string> listKernelTypesMap = new Dictionary<
            ListKernelType,
            string
        >
        {
            { ListKernelType.All, "all" },
            { ListKernelType.Script, "script" },
            { ListKernelType.Notebook, "notebook" },
        };

        public enum ListKernelType
        {
            All,
            Script,
            Notebook,
        }

        internal static Dictionary<ListOutputType, string> listOutputTypesMap = new Dictionary<
            ListOutputType,
            string
        >
        {
            { ListOutputType.All, "all" },
            { ListOutputType.Visualization, "visualization" },
            { ListOutputType.Data, "data" },
        };

        public enum ListOutputType
        {
            All,
            Visualization,
            Data,
        }

        internal static Dictionary<ListSortBy, string> listShortBysMap = new Dictionary<
            ListSortBy,
            string
        >
        {
            { ListSortBy.Hotness, "hotness" },
            { ListSortBy.CommentCount, "commentCount" },
            { ListSortBy.DateCreated, "dateCreated" },
            { ListSortBy.DateRun, "dateRun" },
            { ListSortBy.Relevance, "relevance" },
            { ListSortBy.ScoreAscending, "scoreAscending" },
            { ListSortBy.ScoreDescending, "scoreDescending" },
            { ListSortBy.ViewCount, "viewCount" },
            { ListSortBy.VoteCount, "voteCount" },
        };

        public enum ListSortBy
        {
            Hotness,
            CommentCount,
            DateCreated,
            DateRun,
            Relevance,
            ScoreAscending,
            ScoreDescending,
            ViewCount,
            VoteCount,
        }

        internal static Dictionary<CompetitionGroup, string> competitionGroupsMap = new Dictionary<
            CompetitionGroup,
            string
        >
        {
            { CompetitionGroup.General, "general" },
            { CompetitionGroup.Entered, "entered" },
            { CompetitionGroup.InClass, "inClass" },
        };

        public enum CompetitionGroup
        {
            General,
            Entered,
            InClass,
        }

        internal static Dictionary<CompetitionCategory, string> competitionCategoriesMap =
            new Dictionary<CompetitionCategory, string>
            {
                //Refer to the comment on KaggleAPI's CompetitionsList function
                //{ CompetitionCategory.All, "all" },
                { CompetitionCategory.All, "" },
                { CompetitionCategory.Featured, "featured" },
                { CompetitionCategory.Research, "research" },
                { CompetitionCategory.Recruitment, "recruitment" },
                { CompetitionCategory.GettingStarted, "gettingStarted" },
                { CompetitionCategory.Masters, "masters" },
                { CompetitionCategory.Playground, "playground" },
            };

        public enum CompetitionCategory
        {
            All,
            Featured,
            Research,
            Recruitment,
            GettingStarted,
            Masters,
            Playground,
        }

        internal static Dictionary<CompetitionSortBy, string> competitionSortBysMap =
            new Dictionary<CompetitionSortBy, string>
            {
                { CompetitionSortBy.Grouped, "grouped" },
                { CompetitionSortBy.Prize, "prize" },
                { CompetitionSortBy.EarliestDeadline, "earliestDeadline" },
                { CompetitionSortBy.LatestDeadline, "latestDeadline" },
                { CompetitionSortBy.NumberOfTeams, "numberOfTeams" },
                { CompetitionSortBy.RecentlyCreated, "recentlyCreated" },
            };

        public enum CompetitionSortBy
        {
            Grouped,
            Prize,
            EarliestDeadline,
            LatestDeadline,
            NumberOfTeams,
            RecentlyCreated,
        }

        internal static Dictionary<DatasetFileType, string> datasetFileTypesMap = new Dictionary<
            DatasetFileType,
            string
        >
        {
            { DatasetFileType.All, "all" },
            { DatasetFileType.CSV, "csv" },
            { DatasetFileType.SQLite, "sqlite" },
            { DatasetFileType.Json, "json" },
            { DatasetFileType.BigQuery, "bigQuery" },
        };

        public enum DatasetFileType
        {
            All,
            CSV,
            SQLite,
            Json,
            BigQuery,
        }

        internal static Dictionary<DatasetLicenseName, string> datasetLicenseNamesMap =
            new Dictionary<DatasetLicenseName, string>
            {
                { DatasetLicenseName.All, "all" },
                { DatasetLicenseName.CC, "cc" },
                { DatasetLicenseName.GPL, "gpl" },
                { DatasetLicenseName.ODB, "odb" },
                { DatasetLicenseName.Other, "other" },
            };

        public enum DatasetLicenseName
        {
            All,
            CC,
            GPL,
            ODB,
            Other,
        }

        internal static Dictionary<DatasetSortBy, string> datasetSortBysMap = new Dictionary<
            DatasetSortBy,
            string
        >
        {
            { DatasetSortBy.Hottest, "hottest" },
            { DatasetSortBy.Votes, "votes" },
            { DatasetSortBy.Updated, "updated" },
            { DatasetSortBy.Active, "active" },
            { DatasetSortBy.Published, "published" },
        };

        public enum DatasetSortBy
        {
            Hottest,
            Votes,
            Updated,
            Active,
            Published,
        }

        internal static Dictionary<DirMode, string> dirModesMap = new Dictionary<DirMode, string>
        {
            { DirMode.Skip, "skip" },
            { DirMode.Zip, "zip" },
            { DirMode.Tar, "tar" },
        };

        public enum DirMode
        {
            Skip,
            Zip,
            Tar,
        }
        #endregion
    }

    public class KaggleConfiguration
    {
        public string proxy { get; set; }
        public string competition { get; set; }
        public string path { get; set; }
        public string username { get; set; }
        public string key { get; set; }
        public string ssl_ca_cert { get; set; }
    }

    //public class KaggleAPILoggerEventArgs : EventArgs
    //{
    //    public KaggleAPILoggerEventArgs(string message)
    //    {
    //        Message = message;
    //    }

    //    public string Message { get; set; }
    //}

    internal sealed class KaggleAPIExtended : IDisposable
    {
        static readonly string VERSION = "1.5.12";

        static readonly string HEADER_API_VERSION = "X-Kaggle-ApiVersion";
        static readonly string DATASET_METADATA_FILE = "dataset-metadata.json";
        static readonly string OLD_DATASET_METADATA_FILE = "datapackage.json";
        static readonly string KERNEL_METADATA_FILE = "kernel-metadata.json";

        KaggleConfiguration configValues;
        KaggleAPI api;

        //public event EventHandler<KaggleAPILoggerEventArgs> LoggerEvent;
        IKaggleInformationLogger logger;

        bool alreadyPrintedVersionWarning = false;

        public KaggleAPIExtended() { }

        public KaggleAPIExtended(IKaggleInformationLogger logger)
        {
            this.logger = logger;
        }

        internal AuthenticationMethod Authenticate(
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            return Authenticate(new HttpClient(), configuration, filename, method);
        }

        internal AuthenticationMethod Authenticate(
            HttpClientHandler handler,
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            (KaggleConfiguration Configuration, AuthenticationMethod Method) result = ObtainConfig(
                configuration,
                filename,
                method
            );

            //We should already have the Configuration
            LoadConfig(result.Configuration);
            if (configValues.proxy != null)
                handler.Proxy = new WebProxy
                {
                    Address = new Uri(configuration.proxy),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false
                };
            if (configValues.ssl_ca_cert != null)
                handler.ClientCertificates.Add(new X509Certificate2(configuration.ssl_ca_cert));
            api = new KaggleAPI(configValues.username, configValues.key, new HttpClient(handler));
            return result.Method;
        }

        internal AuthenticationMethod Authenticate(
            HttpClient client,
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            (KaggleConfiguration Configuration, AuthenticationMethod Method) result = ObtainConfig(
                configuration,
                filename,
                method
            );
            //We should already have the Configuration
            LoadConfig(result.Configuration);
            api = new KaggleAPI(configValues.username, configValues.key, client);
            return result.Method;
        }

        (KaggleConfiguration Configuration, AuthenticationMethod Method) ObtainConfig(
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            switch (method)
            {
                case AuthenticationMethod.Direct:
                    {
                        break;
                    }
                case AuthenticationMethod.File:
                    {
                        configuration = ReadConfigSpecifiedFile(filename, configuration);
                        break;
                    }
                case AuthenticationMethod.Environment:
                    {
                        configuration = ReadConfigEnvironment(configuration);
                        break;
                    }
                case AuthenticationMethod.User:
                    {
                        configuration = ReadConfigFile(configuration);
                        break;
                    }
                case AuthenticationMethod.Auto:
                    {
                        //Authenticate from first to last in the order: Direct -> File -> Environment -> User
                        int order = 0;
                        string exceptionMessage = Environment.NewLine;
                        while (true)
                        {
                            method = AuthenticationMethodNamesPriorityMap[order];
                            try
                            {
                                return ObtainConfig(configuration, filename, method);
                            }
                            catch (Exception exception)
                            {
                                exceptionMessage += exception.Message + Environment.NewLine;
                                order++;
                                if (order > (AuthenticationMethodNamesPriorityMap.Count - 1))
                                    break;
                            }
                        }
                        throw new ArgumentException(
                            $"KaggleAPIExtended: Could not authenticate automatically with the given parameters {exceptionMessage}"
                        );
                    }
            }
            //Will throw an exception if configuration fails to load
            AssertConfigValid(configuration);
            return (
                new KaggleConfiguration
                {
                    proxy = configuration.proxy,
                    competition = configuration.competition,
                    path = configuration.path,
                    username = configuration.username,
                    key = configuration.key,
                    ssl_ca_cert = configuration.ssl_ca_cert
                },
                method
            );
        }

        void AssertConfigValid(KaggleConfiguration configData)
        {
            if (configData == null)
                throw new ArgumentNullException(
                    "KaggleAPIExtended: Unauthorized: you must download an API key or export credentials to the environment. Please see https://github.com/Kaggle/kaggle-api#api-credentials for instructions."
                );
            if (configData.username == null || configData.username == string.Empty)
                throw new ArgumentException("KaggleAPIExtended: Missing username in configuration");
            if (configData.key == null || configData.key == string.Empty)
                throw new ArgumentException("KaggleAPIExtended: Missing key in configuration");
        }

        KaggleConfiguration ReadConfigSpecifiedFile(
            string filename,
            KaggleConfiguration configData = null
        )
        {
            if (configData == null)
                configData = new KaggleConfiguration();

            if (filename == null)
                return null;

            using (var reader = new StreamReader(filename))
            {
                var json = reader.ReadToEnd();
                JsonHelper.TryParseJson(json, out configData);
            }
            return configData;
        }

        KaggleConfiguration ReadConfigEnvironment(KaggleConfiguration configData = null)
        {
            if (configData == null)
                configData = new KaggleConfiguration();

            configData.username = System.Environment.GetEnvironmentVariable("KAGGLE_USERNAME");
            configData.key = System.Environment.GetEnvironmentVariable("KAGGLE_KEY");
            configData.competition = System.Environment.GetEnvironmentVariable(
                "KAGGLE_COMPETITION"
            );
            configData.path = System.Environment.GetEnvironmentVariable("KAGGLE_PATH");
            configData.proxy = System.Environment.GetEnvironmentVariable("KAGGLE_PROXY");
            configData.ssl_ca_cert = System.Environment.GetEnvironmentVariable(
                "KAGGLE_SSL_CA_CERT"
            );

            return configData;
        }

        string UserConfigFilePath(bool createDirIfMissing = false)
        {
            string config_dir = System.Environment.GetEnvironmentVariable("KAGGLE_CONFIG_DIR");
            if (config_dir == null)
                config_dir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    ".kaggle"
                );
            if (createDirIfMissing)
                Directory.CreateDirectory(config_dir);
            return Path.Combine(config_dir, "kaggle.json");
        }

        KaggleConfiguration ReadConfigFile(KaggleConfiguration configData = null)
        {
            if (configData == null)
                configData = new KaggleConfiguration();

            //string config_dir = UserConfigFilePath(true);

            //string config = Path.Combine(config_dir, "kaggle.json");
            string config = UserConfigFilePath(true);
            if (!File.Exists(config))
                return null;

            configData = ReadConfigSpecifiedFile(config, configData);

            return configData;
        }

        void LoadConfig(KaggleConfiguration configData)
        {
            AssertConfigValid(configData);
            configValues = configData;
        }

        void InternalSetConfigValue(ConfigurationName name, string value)
        {
            KaggleConfiguration configData = ReadConfigFile();
            if (configData == null)
                configData = new KaggleConfiguration();

            switch (name)
            {
                case ConfigurationName.Username:
                    {
                        configData.username = value;
                        configValues.username = value;
                        break;
                    }
                case ConfigurationName.Key:
                    {
                        configData.key = value;
                        configValues.key = value;
                        break;
                    }
                case ConfigurationName.Path:
                    {
                        configData.path = value;
                        configValues.path = value;
                        break;
                    }
                case ConfigurationName.Proxy:
                    {
                        configData.proxy = value;
                        configValues.proxy = value;
                        break;
                    }
                case ConfigurationName.SSL_CA_CERT:
                    {
                        configData.ssl_ca_cert = value;
                        configValues.ssl_ca_cert = value;
                        break;
                    }
            }
            string json = JsonHelper.SerializeObject(configData);
            File.WriteAllText(UserConfigFilePath(), json);
        }

        internal void SetConfigValue(ConfigurationName name, string value)
        {
            if (value != null)
                InternalSetConfigValue(name, value);
        }

        internal void UnsetConfigValue(ConfigurationName name)
        {
            //Setting any JSON property to null results in the removal thereof
            InternalSetConfigValue(name, null);
        }

        //void Log(string message)
        //{
        //    // Make a temporary copy of the event to avoid possibility of
        //    // a race condition if the last subscriber unsubscribes
        //    // immediately after the null check and before the event is raised.
        //    EventHandler<KaggleAPILoggerEventArgs> raiseEvent = LoggerEvent;

        //    // Event will be null if there are no subscribers
        //    if (raiseEvent != null)
        //    {
        //        // Call to raise the event.
        //        raiseEvent(this, new KaggleAPILoggerEventArgs(message));
        //    }
        //}

        void Log(string message)
        {
            if (logger != null)
                logger.OnLog(message);
        }

        internal async Task<List<CompetitionInquiry>> CompetitionsList(
            CompetitionGroup? group = null,
            CompetitionCategory? category = null,
            CompetitionSortBy? sortBy = null,
            int? page = 1,
            string search = null
        )
        {
            string groupStr = group == null ? null : competitionGroupsMap[(CompetitionGroup)group];
            string categoryStr =
                group == null ? null : competitionCategoriesMap[(CompetitionCategory)group];
            string sortByStr =
                group == null ? null : competitionSortBysMap[(CompetitionSortBy)group];
            return await ProcessResponse<List<CompetitionInquiry>>(
                await api.CompetitionsList(groupStr, categoryStr, sortByStr, page, search)
            );
        }

        internal async Task<List<CompetitionInquiry>> CompetitionsListWrapped(
            CompetitionGroup? group = null,
            CompetitionCategory? category = null,
            CompetitionSortBy? sortBy = null,
            int? page = 1,
            string search = null,
            bool quiet = false
        )
        {
            List<CompetitionInquiry> result = await CompetitionsList(
                group,
                category,
                sortBy,
                page,
                search
            );

            if (result == null)
                this.Log("No competitions found");

            return result;
        }

        internal async Task<CompetitionSubmitStatus> CompetitionSubmit(
            string path,
            string message,
            string competition,
            bool quiet = false
        )
        {
            long size = GetFileSize(path);
            switch (size)
            {
                case -1:
                    throw new ArgumentException(
                        "KaggleAPIExtended: The given path is permission-restricted."
                    );
                case 0:
                    throw new ArgumentException(
                        "KaggleAPIExtended: The given path does not point to an existing file."
                    );
            }
            string fileName = Path.GetFileName(path);
            long lastModifiedDateUTC = GetMTime(path);

            HttpResponseMessage response = await api.CompetitionsSubmissionsUrl(
                fileName,
                competition,
                size,
                lastModifiedDateUTC
            );
            UploadPostResponse result = await ProcessResponse<UploadPostResponse>(response);

            if (!((int)response.StatusCode >= 200 & (int)response.StatusCode <= 299))
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    this.Log(
                        "Could not find competition - please verify that you "
                            + "entered the correct competition ID and that the "
                            + "competition is still accepting submissions."
                    );
                }
                else
                    this.Log(GetStatusCodeDescription(response.StatusCode));
                return null;
            }

            bool success = await UploadComplete(path, result.createUrl, quiet);
            if (!success)
            {
                this.Log("Could not submit to competition");
                return null;
            }

            return await ProcessResponse<CompetitionSubmitStatus>(
                await api.CompetitionsSubmissionsSubmit(result.token, message, competition)
            );
        }

        internal async Task<CompetitionSubmitStatus> CompetitionSubmitWrapped(
            string path,
            string message,
            string competition,
            bool quiet = false
        )
        {
            if (competition == null)
            {
                competition = configValues.competition;
                if (competition != null & !quiet)
                    this.Log($"Using competition: {competition}");
            }

            if (competition == null)
                throw new ArgumentException("KaggleAPIExtended: No competition specified");

            CompetitionSubmitStatus result = await CompetitionSubmit(path, message, competition);
            return result;
        }

        internal async Task<List<CompetitionSubmissionInquiry>> CompetitionSubmissions(
            string competition,
            int? page = 1
        )
        {
            return await ProcessResponse<List<CompetitionSubmissionInquiry>>(
                await api.CompetitionsSubmissionsList(competition, page)
            );
        }

        internal async Task<List<CompetitionSubmissionInquiry>> CompetitionSubmissionsWrapped(
            string competition = null,
            int? page = 1,
            bool quiet = false
        )
        {
            if (competition == null)
            {
                competition = configValues.competition;
                if (competition != null & !quiet)
                    this.Log($"Using competition: {competition}");
            }

            if (competition == null)
                throw new ArgumentException("KaggleAPIExtended: No competition specified");

            List<CompetitionSubmissionInquiry> result = await CompetitionSubmissions(
                competition,
                page
            );
            if (result == null || result.Count == 0)
                this.Log("No submissions found");

            return result;
        }

        internal async Task<List<CompetitionDataFileInquiry>> CompetitionListFiles(
            string competition
        )
        {
            return await ProcessResponse<List<CompetitionDataFileInquiry>>(
                await api.CompetitionsDataListFiles(competition)
            );
        }

        internal async Task<List<CompetitionDataFileInquiry>> CompetitionListFilesWrapped(
            string competition,
            bool quiet = false
        )
        {
            if (competition == null)
            {
                competition = configValues.competition;
                if (competition != null & !quiet)
                    this.Log($"Using competition: {competition}");
            }

            if (competition == null)
                throw new ArgumentException("KaggleAPIExtended: No competition specified");

            List<CompetitionDataFileInquiry> result = await CompetitionListFiles(competition);
            if (result == null || result.Count == 0)
                this.Log("No files found");

            return result;
        }

        internal async Task<bool> CompetitionDownloadFile(
            string competition,
            string filename,
            string path = null,
            bool force = false,
            bool quiet = false
        )
        {
            Debug.WriteLine($"Downloading file: {filename}");

            HttpResponseMessage response = await api.CompetitionsDataDownloadFile(
                competition,
                filename
            );

            string effectivePath = CreateEffectivePath(path, "competitions", competition);
            string outfile = Path.Combine(effectivePath, filename);

            return await SmartDownloadFile(response, outfile, force, quiet);
        }

        internal async Task<bool> CompetitionDownloadFiles(
            string competition,
            string path = null,
            bool force = false,
            bool quiet = true
        )
        {
            string effectivePath = CreateEffectivePath(path, "competitions", competition);

            HttpResponseMessage response = await api.CompetitionsDataDownloadFiles(competition);

            return await SmartDownloadFile(response, effectivePath, force, quiet);
        }

        internal async Task CompetitionDownloadWrapped(
            string competition,
            string filename = null,
            string path = null,
            bool force = false,
            bool quiet = false
        )
        {
            if (competition == null)
            {
                competition = configValues.competition;
                if (competition != null & !quiet)
                    this.Log($"Using competition: {competition}");
            }

            if (competition == null)
                throw new ArgumentException("KaggleAPIExtended: No competition specified");

            if (filename == null)
                await CompetitionDownloadFiles(competition, path, force, quiet);
            else
                await CompetitionDownloadFile(competition, filename, path, force, quiet);
        }

        internal async Task<bool> CompetitionLeaderboardDownload(
            string competition,
            string path = null,
            bool quiet = true
        )
        {
            string effectivePath = CreateEffectivePath(path, "competitions", competition);

            HttpResponseMessage response = await api.CompetitionDownloadLeaderboard(competition);

            string fileName = competition + ".zip";
            string outfile = Path.Combine(effectivePath, fileName);

            return await SmartDownloadFile(response, outfile, true, quiet);
        }

        internal async Task<CompetitionLeaderboardInquiry> CompetitionLeaderboardView(
            string competition
        )
        {
            return await ProcessResponse<CompetitionLeaderboardInquiry>(
                await api.CompetitionViewLeaderboard(competition)
            );
        }

        internal async Task<CompetitionLeaderboardInquiry> CompetitionLeaderboardWrapped(
            string competition,
            string path,
            bool view = false,
            bool download = false,
            bool quiet = false
        )
        {
            if (!view & !download)
                throw new ArgumentException(
                    "KaggleAPIExtended: Either view or download must be true"
                );

            if (competition == null)
            {
                competition = configValues.competition;
                if (competition != null & !quiet)
                    this.Log($"Using competition: {competition}");
            }

            if (competition == null)
                throw new ArgumentException("KaggleAPIExtended: No competition specified");

            CompetitionLeaderboardInquiry viewResult = null;
            if (download)
                await CompetitionLeaderboardDownload(competition, path, quiet);
            if (view)
            {
                viewResult = await CompetitionLeaderboardView(competition);
                if (
                    viewResult == null
                    || viewResult.submissions == null
                    || viewResult.submissions.Count == 0
                )
                    this.Log("No results found");
            }

            return viewResult;
        }

        internal async Task<List<DatasetInquiry>> DatasetList(
            DatasetSortBy? sortBy = null,
            DatasetFileType? fileType = null,
            DatasetLicenseName? licenseName = null,
            string[] tagIds = null,
            string search = null,
            string user = null,
            bool mine = false,
            int page = 1,
            long? maxSize = null,
            long? minSize = null
        )
        {
            string sortByStr = sortBy == null ? null : datasetSortBysMap[(DatasetSortBy)sortBy];
            string fileTypeStr =
                fileType == null ? null : datasetFileTypesMap[(DatasetFileType)fileType];
            string licenseNameStr =
                licenseName == null
                    ? null
                    : datasetLicenseNamesMap[(DatasetLicenseName)licenseName];

            if (page <= 0)
                throw new ArgumentException("KaggleAPIExtended: Page number must be >= 1");

            if (maxSize != null & minSize != null)
                if (maxSize < minSize)
                    throw new ArgumentException(
                        "KaggleAPIExtended: Max Size must be max_size >= min_size"
                    );
            if (maxSize != null && maxSize <= 0)
                throw new ArgumentException("KaggleAPIExtended: Max Size must be > 0");
            if (minSize != null && minSize < 0)
                throw new ArgumentException("KaggleAPIExtended: Min Size must be >= 0");

            string groupStr = "public";
            if (mine)
            {
                groupStr = "my";
                if (user != null)
                    throw new ArgumentException(
                        "KaggleAPIExtended: Cannot specify both mine and a user"
                    );
            }
            if (user != null)
                groupStr = "user";

            return await ProcessResponse<List<DatasetInquiry>>(
                await api.DatasetsList(
                    groupStr,
                    sortByStr,
                    fileTypeStr,
                    licenseNameStr,
                    tagIds == null ? "" : string.Join(",", tagIds),
                    search,
                    user,
                    page,
                    maxSize,
                    minSize
                )
            );
        }

        internal async Task<List<DatasetInquiry>> DatasetListWrapped(
            DatasetSortBy? sortBy = null,
            DatasetFileType? fileType = null,
            DatasetLicenseName? licenseName = null,
            string[] tagIds = null,
            string search = null,
            string user = null,
            bool mine = false,
            int page = 1,
            long? maxSize = null,
            long? minSize = null
        )
        {
            List<DatasetInquiry> result = await DatasetList(
                sortBy,
                fileType,
                licenseName,
                tagIds,
                search,
                user,
                mine,
                page,
                maxSize,
                minSize
            );
            if (result == null || result.Count == 0)
                this.Log("No files found");

            return result;
        }

        internal async Task<DatasetInquiry> DatasetView(string dataset)
        {
            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);

            return await ProcessResponse<DatasetInquiry>(
                await api.DatasetsView(ownerSlug, datasetSlug)
            );
        }

        (string ownerSlug, string datasetSlug) RetrieveDataset(string dataset)
        {
            if (dataset == null)
                throw new ArgumentException("KaggleAPIExtended: A dataset must be specified");

            string ownerSlug;
            string datasetSlug;
            if (dataset.Contains('/'))
            {
                ValidateDatasetString(dataset);
                string[] datasetUrls = dataset.Split('/');
                ownerSlug = datasetUrls[0];
                datasetSlug = datasetUrls[1];
            }
            else
            {
                if (configValues.username == null)
                    throw new ArgumentException(
                        "KaggleAPIExtended: No username / ownerSlug specified"
                    );
                ownerSlug = configValues.username;
                datasetSlug = dataset;
            }

            return (ownerSlug, datasetSlug);
        }

        (string ownerSlug, string datasetSlug, string effectivePath) DatasetMetadataPrep(
            string dataset,
            string path
        )
        {
            if (dataset == null)
                throw new ArgumentException("KaggleAPIExtended: A dataset must be specified");

            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);
            string effectivePath = CreateEffectivePath(path, "datasets", ownerSlug, datasetSlug);

            return (ownerSlug, datasetSlug, effectivePath);
        }

        internal async Task DatasetMetadataUpdate(string dataset, string path)
        {
            (string ownerSlug, string datasetSlug, string effectivePath) = DatasetMetadataPrep(
                dataset,
                path
            );
            string metaFile = GetDatasetMetadataFile(effectivePath);

            //read json
            DatasetMetadataLocal metadata = JsonHelper.ParseJson<DatasetMetadataLocal>(
                File.ReadAllText(metaFile)
            );

            if (metadata == null)
                throw new NullReferenceException(
                    "KaggleAPIExtended: Deserialized Metadata is null"
                );
            DatasetUpdateSettingsRequest updateSettingsRequest = new DatasetUpdateSettingsRequest()
            {
                title = metadata.title,
                subtitle = metadata.subtitle,
                description = metadata.description,
                isPrivate = metadata.isPrivate,
                licenses = metadata.licenses,
                keywords = metadata.keywords,
                collaborators = metadata.collaborators,
                data = metadata.data
            };

            HttpResponseMessage response = await api.MetadataPost(
                ownerSlug,
                datasetSlug,
                updateSettingsRequest
            );
            DatasetMetadataUpdateStatus result = await ProcessResponse<DatasetMetadataUpdateStatus>(
                response
            );

            if (result.errors.Count > 0)
            {
                foreach (string message in result.errors.Select(er => er.message))
                    this.Log(message);
                throw new KaggleAPIException(
                    response,
                    "Update dataset metadata failed. Please view the logs for further info."
                );
            }
        }

        internal async Task<string> DatasetMetadata(string dataset, string path)
        {
            (string ownerSlug, string datasetSlug, string effectivePath) = DatasetMetadataPrep(
                dataset,
                path
            );

            HttpResponseMessage responseMessage = await api.MetadataGet(ownerSlug, datasetSlug);
            DatasetMetadataInquiry result = await ProcessResponse<DatasetMetadataInquiry>(
                responseMessage
            );

            if (result == null)
                return null;

            if (result.errorMessage != string.Empty)
            {
                throw new KaggleAPIException(responseMessage, result.errorMessage);
            }

            DatasetMetadataInquiryInfo metadata = result.info;

            string metaFile = Path.Combine(effectivePath, DATASET_METADATA_FILE);
            File.WriteAllText(metaFile, JsonHelper.SerializeObject(metadata));

            return metaFile;
        }

        internal async Task<string> DatasetMetadataWrapped(string dataset, string path, bool update)
        {
            if (update)
            {
                this.Log("updating dataset metadata");
                await DatasetMetadataUpdate(dataset, path);
                this.Log("successfully updated dataset metadata");
                return null;
            }
            else
            {
                string savedPath = await DatasetMetadata(dataset, path);
                this.Log($"Downloaded metadata to {savedPath}");
                return savedPath;
            }
        }

        internal async Task<DatasetDataFilesInquiry> DatasetListFiles(string dataset)
        {
            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);

            return await ProcessResponse<DatasetDataFilesInquiry>(
                await api.DatasetsListFiles(ownerSlug, datasetSlug)
            );
        }

        internal async Task<DatasetDataFilesInquiry> DatasetListFilesWrapped(string dataset)
        {
            DatasetDataFilesInquiry result = await DatasetListFiles(dataset);
            if (result == null || result.datasetFiles == null || result.datasetFiles.Count == 0)
                this.Log("No files found");

            return result;
        }

        internal async Task<string> DatasetStatus(string dataset)
        {
            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);

            return await ProcessResponse<string>(await api.DatasetsStatus(ownerSlug, datasetSlug));
        }

        internal async Task<string> DatasetStatusWrapped(string dataset)
        {
            return await DatasetStatus(dataset);
        }

        internal async Task<bool> DatasetDownloadFile(
            string dataset,
            string fileName,
            string path = null,
            bool force = false,
            bool quiet = true
        )
        {
            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);

            HttpResponseMessage response = await api.DatasetsDownloadFile(
                ownerSlug,
                datasetSlug,
                fileName
            );

            string effectivePath = CreateEffectivePath(path, "datasets", ownerSlug, datasetSlug);
            string outfile = Path.Combine(effectivePath, fileName);

            return await SmartDownloadFile(response, outfile, force, quiet);
        }

        internal async Task<bool> DatasetDownloadFiles(
            string dataset,
            string path = null,
            bool force = false,
            bool unzip = false,
            bool quiet = true
        )
        {
            (string ownerSlug, string datasetSlug) = RetrieveDataset(dataset);
            string effectivePath = CreateEffectivePath(path, "datasets", ownerSlug, datasetSlug);

            HttpResponseMessage response = await api.DatasetsDownload(ownerSlug, datasetSlug);

            string outfile = Path.Combine(effectivePath, datasetSlug + ".zip");
            bool downloaded = await SmartDownloadFile(response, outfile, force, quiet);

            if (downloaded)
                if (unzip)
                {
                    try
                    {
                        FastZip z = new FastZip();
                        z.ExtractZip(outfile, effectivePath, null);
                    }
                    catch (Exception exception)
                    {
                        throw new ArgumentException(
                            $"Bad zip file, please report on www.github.com/kaggle/kaggle-api {exception.Message}"
                        );
                    }

                    try
                    {
                        File.Delete(outfile);
                    }
                    catch (Exception exception)
                    {
                        this.Log($"Could not delete zip file, got {exception.Message}");
                    }
                }

            return downloaded;
        }

        internal async Task<bool> DatasetDownloadWrapped(
            string dataset,
            string filename = null,
            string path = null,
            bool force = false,
            bool unzip = false,
            bool quiet = false
        )
        {
            if (filename == null)
                return await DatasetDownloadFiles(dataset, path, force, unzip, quiet);
            else
                return await DatasetDownloadFile(dataset, filename, path, force, quiet);
        }

        internal async Task<string> DatasetUploadFile(string path, bool quiet)
        {
            long contentLength = GetFileSize(path);
            switch (contentLength)
            {
                case -1:
                    throw new ArgumentException(
                        "KaggleAPIExtended: The given path is permission-restricted."
                    );
                case 0:
                    throw new ArgumentException(
                        "KaggleAPIExtended: The given path does not point to an existing file."
                    );
            }
            string fileName = Path.GetFileName(path);
            long lastModifiedDateUTC = GetMTime(path);

            UploadPostResponse upReqResult = await ProcessResponse<UploadPostResponse>(
                await api.DatasetsUploadFile(fileName, contentLength, lastModifiedDateUTC)
            );

            if (upReqResult == null)
                return null;

            bool success = await UploadComplete(path, upReqResult.createUrl, quiet);

            if (success)
                return upReqResult.token;
            return null;
        }

        internal async Task<DatasetCreateVersionStatus> DatasetCreateVersion(
            string folder,
            string versionNotes,
            bool quiet = false,
            bool convertToCsv = true,
            bool deleteOldVersions = false,
            DirMode dirMode = DirMode.Skip
        )
        {
            if (!Directory.Exists(folder))
                throw new DirectoryNotFoundException(
                    "KaggleAPIExtended: Invalid folder: " + folder
                );

            string metaFile = GetDatasetMetadataFile(folder);

            //read json
            DatasetMetadataLocal metadata = JsonHelper.ParseJson<DatasetMetadataLocal>(
                File.ReadAllText(metaFile)
            );

            if (metadata == null)
                throw new NullReferenceException(
                    "KaggleAPIExtended: Deserialized Metadata is null"
                );
            string @ref = metadata.id;
            int? id_no = metadata.id_no;
            if (@ref == null & id_no == null)
                throw new ArgumentException(
                    "KaggleAPIExtended: ID or slug must be specified in the metadata"
                );

            string subtitle = metadata.subtitle;
            if (subtitle != null && (subtitle.Length < 20 | subtitle.Length > 80))
                throw new ArgumentException("Subtitle length must be between 20 and 80 characters");
            List<DatasetMetadataResourceLocal> resources = metadata.resources;
            if (resources != null)
                ValidateResources(folder, resources);
            string description = metadata.description;
            List<string> keywords = defaultIfNull(metadata.keywords, new List<string>());

            DatasetNewVersionRequest request = new DatasetNewVersionRequest()
            {
                versionNotes = versionNotes,
                subtitle = subtitle,
                description = description,
                files = new List<DatasetUploadFile>(),
                convertToCsv = convertToCsv,
                categoryIds = keywords,
                deleteOldVersions = deleteOldVersions
            };
            await UploadFiles(request.files, resources, folder, quiet, dirMode);

            DatasetCreateVersionStatus result;
            if (id_no != null)
                result = await ProcessResponse<DatasetCreateVersionStatus>(
                    await api.DatasetsCreateVersionById(id_no, request)
                );
            else
            {
                if (@ref == configValues.username + "/INSERT_SLUG_HERE")
                    throw new ArgumentException(
                        "KaggleAPIExtended: Default slug detected, please change values before uploading"
                    );
                ValidateDatasetString(@ref);
                string[] refList = @ref.Split('/');
                string ownerSlug = refList[0];
                string datasetSlug = refList[1];
                result = await ProcessResponse<DatasetCreateVersionStatus>(
                    await api.DatasetsCreateVersion(ownerSlug, datasetSlug, request)
                );
            }

            return result;
        }

        internal async Task<DatasetCreateVersionStatus> DatasetCreateVersionWrapped(
            string folder,
            string versionNotes,
            bool quiet = false,
            bool convertToCsv = true,
            bool deleteOldVersions = false,
            DirMode dirMode = DirMode.Skip
        )
        {
            if (folder == null)
                folder = Directory.GetCurrentDirectory();
            DatasetCreateVersionStatus result = await DatasetCreateVersion(
                folder,
                versionNotes,
                quiet,
                convertToCsv,
                deleteOldVersions,
                dirMode
            );

            if (result == null)
            {
                this.Log("Dataset version creation error: See previous output");
                return (null);
            }
            if (!(result.invalidTags == null || result.invalidTags.Count == 0))
                this.Log(
                    $"The following are not valid tags and could not be added to the dataset: {result.invalidTags.Stringify()}"
                );
            if (result.status.ToLower() == "ok")
                this.Log(
                    $"Dataset version is being created. Please check progress at {result.url}"
                );
            else
                this.Log($"Dataset version creation error: {result.error}");

            return result;
        }

        internal async Task<string> DatasetInitialize(string folder)
        {
            // get the file attributes for file or directory
            FileAttributes attr = File.GetAttributes(@"c:\Temp");

            //detect whether its a directory or file
            if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                //Invalid directory
                throw new DirectoryNotFoundException(
                    "KaggleAPIExtended: Dataset directory not found."
                );

            string @ref = configValues.username = "/INSERT_SLUG_HERE";
            List<License> licenses = new List<License>() { new License(LicenseType.CC0_10) };

            DatasetMetadataLocal metadata = new DatasetMetadataLocal()
            {
                title = "INSERT_TITLE_HERE",
                id = @ref,
                licenses = licenses
            };
            string metaFile = Path.Combine(folder, DATASET_METADATA_FILE);
            File.WriteAllText(metaFile, JsonHelper.SerializeObject(metadata));

            return metaFile;
        }

        internal async Task<string> DatasetInitializeWrapped(string folder = null)
        {
            if (folder == null)
                folder = Directory.GetCurrentDirectory();
            return await DatasetInitialize(folder);
        }

        internal async Task<DatasetCreateNewStatus> DatasetCreateNew(
            string folder,
            bool @internal = false,
            bool quiet = false,
            bool convertToCsv = true,
            DirMode dirMode = DirMode.Skip
        )
        {
            if (!Directory.Exists(folder))
                throw new DirectoryNotFoundException("Invalid folder: " + folder);

            string metaFile = GetDatasetMetadataFile(folder);

            //read json
            DatasetMetadataLocal metadata = JsonHelper.ParseJson<DatasetMetadataLocal>(
                File.ReadAllText(metaFile)
            );

            if (metadata == null)
                throw new NullReferenceException(
                    "KaggleAPIExtended: Deserialized Metadata is null"
                );
            string @ref = failIfNull(metadata.id);
            string title = failIfNull(metadata.title);
            List<License> licenses = failIfNull(metadata.licenses);
            string[] refList = @ref.Split('/');
            string ownerSlug = refList[0];
            string datasetSlug = refList[1];

            //validations
            if (@ref == configValues.username + "/INSERT_SLUG_HERE")
                throw new ArgumentException(
                    "KaggleAPIExtended: Default slug detected, please change values before uploading"
                );
            if (title == "INSERT_SLUG_HERE")
                throw new ArgumentException(
                    "KaggleAPIExtended: Default title detected, please change values before uploading"
                );
            if (licenses.Count != 1)
                throw new ArgumentException(
                    "KaggleAPIExtended: Please specify exactly one license"
                );
            if (datasetSlug.Length < 6 | datasetSlug.Length > 50)
                throw new ArgumentException(
                    "KaggleAPIExtended: The dataset slug must be between 6 and 50 characters"
                );
            if (title.Length < 6 | title.Length > 50)
                throw new ArgumentException(
                    "KaggleAPIExtended: The dataset title must be between 6 and 50 characters"
                );
            List<DatasetMetadataResourceLocal> resources = metadata.resources;
            if (resources != null)
                ValidateResources(folder, resources);

            string licenseName = failIfNull(licenses[0].name);
            string description = metadata.description;
            List<string> keywords = defaultIfNull(metadata.keywords, new List<string>());

            string subtitle = metadata.subtitle;
            if (subtitle != null && (subtitle.Length < 20 | subtitle.Length > 80))
                throw new ArgumentException("Subtitle length must be between 20 and 80 characters");

            DatasetNewRequest request = new DatasetNewRequest()
            {
                title = title,
                slug = datasetSlug,
                ownerSlug = ownerSlug,
                licenseName = licenseName,
                subtitle = subtitle,
                description = description,
                files = new List<DatasetUploadFile>(),
                isPrivate = !@internal,
                convertToCsv = convertToCsv,
                categoryIds = keywords
            };

            await UploadFiles(request.files, resources, folder, quiet, dirMode);
            return await ProcessResponse<DatasetCreateNewStatus>(
                await api.DatasetsCreateNew(request)
            );
        }

        internal async Task<DatasetCreateNewStatus> DatasetCreateNewWrapped(
            string folder = null,
            bool @internal = false,
            bool quiet = false,
            bool convertToCsv = true,
            DirMode dirMode = DirMode.Skip
        )
        {
            if (folder == null)
                folder = Directory.GetCurrentDirectory();
            DatasetCreateNewStatus result = await DatasetCreateNew(
                folder,
                @internal,
                quiet,
                convertToCsv,
                dirMode
            );

            if (result == null)
                return null;

            if (!(result.invalidTags == null || result.invalidTags.Count == 0))
                this.Log(
                    $"The following are not valid tags and could not be added to the dataset: {result.invalidTags.Stringify()}"
                );
            if (result.status.ToLower() == "ok")
            {
                if (@internal)
                    this.Log(
                        $"Your internal Dataset is being created. Please check progress at {result.url}"
                    );
                else
                    this.Log(
                        $"Your private Dataset is being created. Please check progress at {result.url}"
                    );
            }
            else
                this.Log($"Dataset creation error: {result.error}");

            return result;
        }

        async Task DownloadFile(HttpResponseMessage response, string outfile, bool quiet = true)
        {
            string outpath = Path.GetDirectoryName(outfile);
            if (outpath == null)
                throw new NullReferenceException("Could not find the directory of outfile");
            Directory.CreateDirectory(outpath);
            if (!quiet)
                this.Log($"Downloading {Path.GetFileName(outfile)} to {outfile}");

            //By default, Httpapi.client automatically redirects on code 302
            //However, in cases when the user disables automatic redirect, this handles it
            if (response.StatusCode == HttpStatusCode.Redirect)
            {
                if (response.Headers.Location == null)
                    throw new NullReferenceException(
                        "KaggleAPIExtended: Location header is null when attempting redirect."
                    );

                HttpRequestMessage downloadRequest = api.CreateKaggleRequestMessage(
                    "GET",
                    response.Headers.Location,
                    ""
                );
                HttpResponseMessage downloadResponse = await api.client.SendAsync(downloadRequest);

                await DownloadFile(downloadResponse, outfile);
            }
            //Handles server errors
            else if (response.StatusCode != HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();

                if (
                    !JsonHelper.ParseJsonWithException(
                        json,
                        out KaggleServerException exception,
                        out Exception e1
                    )
                )
                    throw new KaggleAPIException(
                        response,
                        "KaggleAPIExtended: Unknown server response data."
                            + Environment.NewLine
                            + $"First attempt: {e1.Message}"
                            + Environment.NewLine
                            + $"Status code: {GetStatusCodeDescription(response.StatusCode)}"
                    );
                else
                    throw new KaggleAPIException(
                        response,
                        exception.message + Environment.NewLine + $"Status code: {exception.code}"
                    );
            }

            //detect whether its a directory or file
            if (IsDirectory(outfile))
            {
                //Directory
                string cpString = response.Content.Headers.GetValues("Content-Disposition").First();
                ContentDisposition contentDisposition = new ContentDisposition(cpString);

                string fn = contentDisposition.FileName;
                if (fn == null)
                    throw new NullReferenceException(
                        "KaggleAPIExtended: Suggested file name is null."
                    );

                string directory =
                    outfile.TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
                using (FileStream fs = File.OpenWrite(directory + fn))
                    await response.Content.CopyToAsync(fs);
            }
            else
                //File
                using (FileStream fs = File.OpenWrite(outfile))
                    await response.Content.CopyToAsync(fs);
        }

        async Task<bool> SmartDownloadFile(
            HttpResponseMessage response,
            string effectivePath,
            bool force,
            bool quiet = false
        )
        {
            List<string> internalMessages = new List<string>();

            if (force || DownloadNeeded(response, effectivePath, internalMessages, quiet))
            {
                await DownloadFile(response, effectivePath, quiet);
                return true;
            }

            //Did not find the need to download
            return false;
        }

        internal async Task<List<KernelInquiry>> KernelsList(
            int? page = 1,
            int? pageSize = 20,
            string dataset = null,
            string competition = null,
            string parentKernel = null,
            string search = null,
            bool mine = false,
            string user = null,
            ListLanguage? language = null,
            ListKernelType? kernelType = null,
            ListOutputType? outputType = null,
            ListSortBy? sortBy = null
        )
        {
            if (page != null && page <= 0)
                throw new ArgumentException("Page number must be >= 1");

            if (pageSize != null)
                if (pageSize <= 0)
                    throw new ArgumentException("Page size must be >= 1");
                else if (pageSize > 100)
                    pageSize = 100;

            if (sortBy == ListSortBy.Relevance & (search == null || search == ""))
                throw new ArgumentException("Cannot sort by relevance without a search term.");

            ValidateDatasetString(dataset);
            ValidateKernelString(parentKernel);

            string group = "everyone";
            if (mine)
                group = "profile";

            string languageStr = language == null ? null : listLanguagesMap[(ListLanguage)language];
            string kernelTypeStr =
                kernelType == null ? null : listKernelTypesMap[(ListKernelType)kernelType];
            string outputTypeStr =
                outputType == null ? null : listOutputTypesMap[(ListOutputType)outputType];
            string sortByStr = sortBy == null ? null : listShortBysMap[(ListSortBy)sortBy];
            return await ProcessResponse<List<KernelInquiry>>(
                await api.KernelsList(
                    page,
                    pageSize,
                    search,
                    group,
                    user,
                    languageStr,
                    kernelTypeStr,
                    outputTypeStr,
                    sortByStr,
                    dataset,
                    competition,
                    parentKernel
                )
            );
        }

        internal async Task<List<KernelInquiry>> KernelsListWrapped(
            bool mine = false,
            int? page = 1,
            int? pageSize = 20,
            string search = null,
            string parent = null,
            string competition = null,
            string dataset = null,
            string user = null,
            ListLanguage? language = null,
            ListKernelType? kernelType = null,
            ListOutputType? outputType = null,
            ListSortBy? sortBy = null
        )
        {
            return await KernelsList(
                page,
                pageSize,
                dataset,
                competition,
                parent,
                search,
                mine,
                user,
                language,
                kernelType
            );
        }

        internal string KernelsInitialize(string folder)
        {
            if (!Directory.Exists(folder))
                throw new ArgumentException($"Invalid folder: {folder}");

            List<DatasetMetadataResourceLocal> resources = new List<DatasetMetadataResourceLocal>
            {
                new DatasetMetadataResourceLocal { path = "INSERT_SCRIPT_PATH_HERE" }
            };

            if (configValues.username == null)
                throw new ArgumentException("KaggleAPIExtended: No username / ownerSlug specified");
            string username = configValues.username;
            KernelMetadataLocal metadata = new KernelMetadataLocal
            {
                id = $"{username}/INSERT_KERNEL_SLUG_HERE",
                title = "INSERT_TITLE_HERE",
                code_file = "INSERT_CODE_FILE_PATH_HERE",
                language = "Pick one of: {" + string.Join(",", pushLanguageTypesMap.Values) + "}",
                kernel_type = "Pick one of: {" + string.Join(",", pushKernelTypesMap.Values) + "}",
                is_private = true,
                enable_gpu = false,
                dataset_sources = new List<string>(),
                competition_sources = new List<string>(),
                kernel_sources = new List<string>()
            };
            string metaFile = Path.Combine(folder, KERNEL_METADATA_FILE);
            File.WriteAllText(metaFile, JsonHelper.SerializeObject(metadata));

            return metaFile;
        }

        internal string KernelsInitializeWrapped(string folder = null)
        {
            if (folder == null)
                folder = Directory.GetCurrentDirectory();
            string metaFile = KernelsInitialize(folder);
            this.Log($"Kernel metadata template written to: {metaFile}");
            return metaFile;
        }

        internal async Task<KernelPushStatus> KernelsPush(string folder)
        {
            List<string> internelMessages = new List<string>();

            if (!Directory.Exists(folder))
                throw new ArgumentException($"Invalid folder: {folder}");

            string metaFile = Path.Combine(folder, KERNEL_METADATA_FILE);
            if (!File.Exists(metaFile))
                throw new ArgumentException($"Metadata file not found: {KERNEL_METADATA_FILE}");

            if (
                !JsonHelper.TryParseJson(
                    File.ReadAllText(metaFile),
                    out KernelMetadataLocal metadata
                )
            )
                throw new IOException("KaggleAPIExtended: Could not read kernel metadata");
            if (metadata == null)
                throw new NullReferenceException("KaggleAPIExtended: Kernel metadata is null");

            string title = metadata.title;
            if (title != null && title.Length < 5)
                throw new ArgumentException("Title must be at least five characters");

            string codePath = metadata.code_file;
            if (codePath == null)
                throw new ArgumentException("A source file must be specified in the metadata");

            string codeFile = Path.Combine(folder, codePath);
            if (!File.Exists(codeFile))
                throw new ArgumentException($"Source file not found: {codeFile}");

            string slug = metadata.id;
            int? id_no = metadata.id_no;
            if (slug == null & id_no == null)
                throw new ArgumentException("ID or slug must be specified in the metadata");

            if (slug != null)
            {
                ValidateKernelString(slug);
                string kernelSlug;
                if (slug.Contains('/'))
                    kernelSlug = slug.Split('/')[1];
                else
                    kernelSlug = slug;
                if (title != null)
                {
                    string asSlug = Helper.URLFriendly(title);
                    if (kernelSlug.ToLower() != asSlug)
                        internelMessages.Add(
                            "Your kernel title does not resolve to the specified "
                                + "id. This may result in surprising behavior. We "
                                + "suggest making your title something that resolves to "
                                + "the specified id. See https://en.wikipedia.org/wiki/Clean_URL#Slug for more information on "
                                + "how slugs are determined."
                        );
                }
            }

            string language = defaultIfNull(metadata.language, "");
            if (!pushLanguageTypesMap.ContainsValue(language))
                throw new ArgumentException(
                    $"A valid language must be specified in the metadata. Valid options are {pushLanguageTypesMap.Values.Stringify()}"
                );

            string kernelType = defaultIfNull(metadata.kernel_type, "");
            if (!pushKernelTypesMap.ContainsValue(kernelType))
                throw new ArgumentException(
                    "A valid kernel type must be specified in the metadata. Valid options are "
                        + $"['{string.Join("', '", pushKernelTypesMap.Values)}']"
                );

            if (kernelType == "notebook" & language == "rmarkdown")
                language = "r";

            List<string> datasetSources = defaultIfNull(
                metadata.dataset_sources,
                new List<string>()
            );
            foreach (string source in datasetSources)
                ValidateDatasetString(source);

            List<string> kernelSources = defaultIfNull(metadata.kernel_sources, new List<string>());
            foreach (string source in kernelSources)
                ValidateDatasetString(source);

            string dockerPinningType = metadata.docker_image_pinning_type;
            if (dockerPinningType != null && !pushPinningTypesMap.ContainsValue(dockerPinningType))
                throw new ArgumentException(
                    $"If specified, the docker_image_pinning_type must be one of {pushPinningTypesMap.Values.Stringify()}"
                );

            string scriptBody = File.ReadAllText(codeFile);

            if (kernelType == "notebook")
            {
                JObject jsonBody = JsonConvert.DeserializeObject(scriptBody) as JObject;
                if (jsonBody != null && jsonBody.ContainsKey("cells"))
                {
                    foreach (JObject cell in jsonBody["cells"])
                        if (
                            cell != null
                            && (cell.ContainsKey("outputs") & ((string)cell["cell_type"]) == "code")
                        )
                            cell["outputs"] = JToken.FromObject(new List<object>());
                    scriptBody = JsonHelper.SerializeObject(jsonBody);
                }
            }

            KernelPushRequest kernelPushRequest = new KernelPushRequest
            {
                id = id_no,
                slug = slug,
                newTitle = metadata.title,
                text = scriptBody,
                language = language,
                kernelType = kernelType,
                isPrivate = metadata.is_private,
                enableGpu = metadata.enable_gpu,
                enableInternet = metadata.enable_internet,
                datasetDataSources = datasetSources,
                competitionDataSources = metadata.competition_sources,
                kernelDataSources = kernelSources,
                categoryIds = metadata.keywords,
                dockerImagePinningType = dockerPinningType
            };

            return await ProcessResponse<KernelPushStatus>(await api.KernelPush(kernelPushRequest));
        }

        internal async Task<KernelPushStatus> KernelsPushWrapped(string folder)
        {
            if (folder == null)
                folder = Directory.GetCurrentDirectory();
            KernelPushStatus result = await KernelsPush(folder);
            if (result == null)
                this.Log("Kernel push error: see previous output");
            else if (result.errorNullable != null)
            {
                if (!(result.invalidTags == null || result.invalidTags.Count == 0))
                    this.Log(
                        $"The following are not valid tags and could not be added to the kernel: {result.invalidTags.Stringify()}"
                    );
                if (
                    !(
                        result.invalidDatasetSources == null
                        || result.invalidDatasetSources.Count == 0
                    )
                )
                    this.Log(
                        $"The following are not valid dataset sources and could not be added to the kernel: {result.invalidDatasetSources.Stringify()}"
                    );
                if (
                    !(
                        result.invalidCompetitionSources == null
                        || result.invalidCompetitionSources.Count == 0
                    )
                )
                    this.Log(
                        $"The following are not valid competition sources and could not be added to the kernel: {result.invalidCompetitionSources.Stringify()}"
                    );
                if (
                    !(result.invalidKernelSources == null || result.invalidKernelSources.Count == 0)
                )
                    this.Log(
                        $"The following are not valid kernel sources and could not be added to the kernel: {result.invalidKernelSources.Stringify()}"
                    );

                if (result.versionNumberNullable != null)
                    this.Log(
                        $"Kernel version {result.versionNumber} successfully pushed.  Please check progress at {result.url}"
                    );
                else
                    this.Log(
                        $"Kernel version successfully pushed.  Please check progress at {result.url}"
                    );
            }
            else
                this.Log($"Kernel push error: {result.error}");

            return result;
        }

        internal async Task<string> KernelsPull(
            string kernel,
            string path,
            bool metadata = false,
            bool quiet = true
        )
        {
            KernelMetadataLocal existingMetadata = null;
            if (kernel == null)
            {
                string existingMetadataPath;
                if (path == null)
                    existingMetadataPath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        KERNEL_METADATA_FILE
                    );
                else
                    existingMetadataPath = Path.Combine(path, KERNEL_METADATA_FILE);

                if (File.Exists(existingMetadataPath))
                {
                    existingMetadata = JsonHelper.ParseJson<KernelMetadataLocal>(
                        File.ReadAllText(existingMetadataPath)
                    );
                    if (existingMetadata == null)
                        throw new NullReferenceException(
                            "KaggleAPIExtended: Failed to read existing metadata - metadata is null"
                        );
                    kernel = existingMetadata.id;

                    if (kernel == null)
                        throw new ArgumentException(
                            "KaggleAPIExtended: Existing metadata does not specify kernel"
                        );

                    if (kernel.Contains("INSERT_KERNEL_SLUG_HERE"))
                        throw new ArgumentException("A kernel must be specified");
                    else
                        this.Log($"Using kernel {kernel}");
                }
            }

            if (kernel == null)
                throw new ArgumentException("KaggleAPIExtended: Kernel is not specified");

            string ownerSlug,
                kernelSlug;
            if (kernel.Contains('/'))
            {
                ValidateKernelString(kernel);
                string[] kernelUrlList = kernel.Split('/');
                ownerSlug = kernelUrlList[0];
                kernelSlug = kernelUrlList[1];
            }
            else
            {
                if (configValues.username == null)
                    throw new ArgumentException(
                        "KaggleAPIExtended: No username / ownerSlug specified"
                    );
                ownerSlug = configValues.username;
                kernelSlug = kernel;
            }

            string effectivePath = CreateEffectivePath(path, "kernels", ownerSlug, kernelSlug);

            KernelPullInquiry result = await ProcessResponse<KernelPullInquiry>(
                await api.KernelPull(ownerSlug, kernelSlug)
            );
            KernelPullBlob blob = result.blob;

            string effectiveDir;
            if (File.Exists(effectivePath))
                effectiveDir = defaultIfNull(Path.GetDirectoryName(effectivePath), "");
            else
                effectiveDir = effectivePath;
            string metadataPath = Path.Combine(effectiveDir, KERNEL_METADATA_FILE);

            string fileName = null;
            string scriptPath;
            if (!File.Exists(effectivePath))
            {
                string language = blob.language;
                string kernelType = blob.kernelType;

                if (existingMetadata != null)
                    fileName = existingMetadata.code_file;
                else if (File.Exists(metadataPath))
                    fileName = defaultIfNull(
                        JsonHelper.ParseJson<KernelMetadataLocal>(File.ReadAllText(metadataPath)),
                        new KernelMetadataLocal()
                    ).code_file;

                if (fileName == null || fileName == "INSERT_CODE_FILE_PATH_HERE")
                {
                    string extension = null;
                    if (kernelType == "script")
                        switch (language)
                        {
                            case "python":
                                extension = ".py";
                                break;
                            case "r":
                                extension = ".R";
                                break;
                            case "rmarkdown":
                                extension = ".Rmd";
                                break;
                            case "sqlite":
                                extension = ".sql";
                                break;
                            case "julia":
                                extension = ".jl";
                                break;
                        }
                    else if (kernelType == "notebook")
                        switch (language)
                        {
                            case "python":
                                extension = ".ipynb";
                                break;
                            case "r":
                                extension = ".irnb";
                                break;
                            case "julia":
                                extension = "ijlnb";
                                break;
                        }
                    fileName = blob.slug + extension;
                }
                if (fileName == null)
                {
                    this.Log(
                        $"Unknown language {language} + kernel type {kernelType} - please report this on the kaggle-api github issues"
                    );
                    this.Log(
                        "Saving as a python file, even though this may not be the correct language"
                    );
                    fileName = "script.py";
                }
                scriptPath = Path.Combine(effectivePath, fileName);
            }
            else
            {
                scriptPath = effectivePath;
                fileName = Path.GetFileName(effectivePath);
            }

            File.WriteAllText(scriptPath, blob.source);

            if (metadata)
            {
                KernelPullMetadata serverMetadata = result.metadata;
                KernelMetadataLocal data = new KernelMetadataLocal
                {
                    id = serverMetadata.@ref,
                    id_no = serverMetadata.id,
                    title = serverMetadata.title,
                    code_file = fileName,
                    language = serverMetadata.language,
                    kernel_type = serverMetadata.kernelType,
                    is_private = serverMetadata.isPrivateNullable,
                    enable_gpu = serverMetadata.enableGpuNullable,
                    enable_internet = serverMetadata.enableInternetNullable,
                    keywords = serverMetadata.categoryIds,
                    dataset_sources = serverMetadata.datasetDataSources,
                    kernel_sources = serverMetadata.kernelDataSources,
                    competition_sources = serverMetadata.competitionDataSources
                };
                File.WriteAllText(metadataPath, JsonHelper.SerializeObject(data));

                return effectiveDir;
            }
            else
                return scriptPath;
        }

        //Original implementation ommited the parameter "bool quiet", I don't get why
        internal async Task<string> KernelsPullWrapped(
            string kernel,
            string path,
            bool metadata = false
        )
        {
            string result = await KernelsPull(kernel, path, metadata);

            if (metadata)
                this.Log($"Source code and metadata downloaded to {result}");
            else
                this.Log($"Source code downloaded to {result}");

            return result;
        }

        internal async Task<List<string>> KernelsOutput(
            string kernel,
            string path,
            bool force = false,
            bool quiet = true
        )
        {
            if (kernel == null)
                throw new ArgumentException("A kernel must be specified");
            string ownerSlug,
                kernelSlug;
            if (kernel.Contains('/'))
            {
                ValidateKernelString(kernel);
                string[] kernelUrlList = kernel.Split('/');
                ownerSlug = kernelUrlList[0];
                kernelSlug = kernelUrlList[1];
            }
            else
            {
                if (configValues.username == null)
                    throw new ArgumentException(
                        "KaggleAPIExtended: No username / ownerSlug specified"
                    );
                ownerSlug = configValues.username;
                kernelSlug = kernel;
            }

            string targetDir = CreateEffectivePath(
                path,
                "kernels",
                ownerSlug,
                kernelSlug,
                "output"
            );

            if (!Directory.Exists(targetDir))
                throw new ArgumentException("You must specify a directory for the kernels output");

            KernelOutputInquiry result = await ProcessResponse<KernelOutputInquiry>(
                await api.KernelOutput(ownerSlug, kernelSlug)
            );
            List<string> outfiles = new List<string>();
            foreach (KernelOutputFile file in result.files)
            {
                string outfile = Path.Combine(targetDir, file.fileName);
                outfiles.Add(outfile);
                HttpResponseMessage downloadResponse = await api.GetRequest(file.url);
                bool downloaded = await SmartDownloadFile(downloadResponse, outfile, force, quiet);
                if (downloaded && !quiet)
                    this.Log($"Output file downloaded to {outfile}");
            }

            string log = result.log;
            if (log != string.Empty)
            {
                string outfile = Path.Combine(targetDir, kernelSlug + ".log");
                outfiles.Add(outfile);
                File.WriteAllText(outfile, log);
                if (!quiet)
                    this.Log($"Kernel log downloaded to {outfile}");
            }

            return outfiles;
        }

        internal async Task<List<string>> KernelsOutputWrapped(
            string kernel,
            string path,
            bool force = false,
            bool quiet = true
        )
        {
            return await KernelsOutput(kernel, path, force, quiet);
        }

        internal async Task<KernelStatusInquiry> KernelsStatus(string kernel)
        {
            string ownerSlug,
                kernelSlug;

            if (kernel == null)
                throw new ArgumentException("A kernel must be specified");
            if (kernel.Contains('/'))
            {
                ValidateKernelString(kernel);
                string[] kernelUrlList = kernel.Split('/');
                ownerSlug = kernelUrlList[0];
                kernelSlug = kernelUrlList[1];
            }
            else
            {
                if (configValues.username == null)
                    throw new ArgumentException(
                        "KaggleAPIExtended: No username / ownerSlug specified"
                    );
                ownerSlug = configValues.username;
                kernelSlug = kernel;
            }
            return await ProcessResponse<KernelStatusInquiry>(
                await api.KernelStatus(ownerSlug, kernelSlug)
            );
        }

        internal async Task<KernelStatusInquiry> KernelsStatusWrapped(string kernel)
        {
            KernelStatusInquiry result = await KernelsStatus(kernel);
            if (result == null)
                throw new NullReferenceException("KaggleAPIExtended: KernelStatusResponse is null");
            string status = result.status;
            string message = result.failureMessageNullable;
            this.Log($"{kernel} has status {status}");
            if (message != null)
            {
                this.Log($"Failure message: {message}");
            }

            return result;
        }

        bool DownloadNeeded(
            HttpResponseMessage response,
            string outfile,
            List<string> internalMessages = null,
            bool quiet = false
        )
        {
            try
            {
                long remoteDate = GetRTime(response.Headers.GetValues("Last-Modified").First());

                if (!File.Exists(outfile))
                    return true;

                long localDate = GetMTime(outfile);
                if (remoteDate >= localDate)
                    return true;

                if (!quiet && internalMessages != null)
                    internalMessages.Add(
                        $"{Path.GetFileName(outfile)}: Skipping, found more recently modified local copy (use --force to force download)"
                    );
                return false;
            }
            catch (Exception) { }
            return true;
        }

        T failIfNull<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException("KaggleAPIExtended: object was null");
            return obj;
        }

        T defaultIfNull<T>(T obj, T @default)
        {
            if (obj == null)
                return @default;
            return obj;
        }

        static string GetDatasetMetadataFile(string folder)
        {
            string metaFile = Path.Combine(folder, DATASET_METADATA_FILE);
            if (!File.Exists(metaFile))
            {
                metaFile = Path.Combine(folder, OLD_DATASET_METADATA_FILE);
                if (!File.Exists(metaFile))
                    throw new FileNotFoundException(
                        "Metadata file not found: " + DATASET_METADATA_FILE
                    );
            }
            return metaFile;
        }

        async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();

            T result;
            KaggleServerException exception = null;

            if (!JsonHelper.ParseJsonWithException(json, out result, out Exception e1))
                if (!JsonHelper.ParseJsonWithException(json, out exception, out Exception e2))
                {
                    throw new KaggleAPIException(
                        response,
                        "KaggleAPIExtended: Unknown server response data."
                            + Environment.NewLine
                            + $"First attempt: {e1.Message}"
                            + Environment.NewLine
                            + $"Second attempt: {e2.Message}"
                            + Environment.NewLine
                            + $"Status code: {GetStatusCodeDescription(response.StatusCode)}"
                    );
                }
                else if (exception == null)
                    exception = new KaggleServerException
                    {
                        code = (int)response.StatusCode,
                        message = json
                    };

            if (exception != null)
                throw new KaggleAPIException(
                    response,
                    exception.message
                        + Environment.NewLine
                        + $"Status code: {GetStatusCodeDescription(response.StatusCode)}"
                );

            if (response.Headers.Contains(HEADER_API_VERSION))
            {
                string apiVersion = response.Headers.GetValues(HEADER_API_VERSION).First();
                if (!alreadyPrintedVersionWarning & !IsUpToDate(apiVersion))
                    this.Log(
                        "Warning: Looks like you're using an outdated API Version, "
                            + "please consider updating (server "
                            + apiVersion
                            + " client "
                            + VERSION
                            + ")"
                    );
            }
            return (result);
        }

        bool IsUpToDate(string serverVersion)
        {
            List<string> clientSplit = VERSION.Split('.').ToList();
            int clientLen = clientSplit.Count;
            List<string> serverSplit = serverVersion.Split('.').ToList();
            int serverLen = clientSplit.Count;

            for (int i = clientLen; i < serverLen; i++)
                clientSplit.Add("0");
            for (int i = serverLen; i < clientLen; i++)
                serverSplit.Add("0");

            for (int i = 0; i < clientLen; i++)
            {
                if (clientSplit[i].Contains('b'))
                    return true;
                int client = int.Parse(clientSplit[i]);
                int server = int.Parse(serverSplit[i]);
                if (client < server)
                    return false;
                else if (server < client)
                    return true;
            }

            return true;
        }

        async Task<IEnumerable<string>> UploadFiles(
            List<DatasetUploadFile> files,
            List<DatasetMetadataResourceLocal> resources,
            string folder,
            bool quiet = false,
            DirMode dirMode = DirMode.Skip
        )
        {
            foreach (string fileName in Directory.GetFiles(folder).Select(Path.GetFileName))
            {
                if (
                    fileName == DATASET_METADATA_FILE
                    | fileName == OLD_DATASET_METADATA_FILE
                    | fileName == KERNEL_METADATA_FILE
                )
                    continue;
                string fullPath = Path.Combine(folder, fileName);

                bool exitCode = await UploadFile(fileName, fullPath, quiet, files, resources);
                if (exitCode)
                    return null;
            }

            foreach (
                string dirName in Directory.GetDirectories(folder).Select(Path.GetDirectoryName)
            )
            {
                if (dirMode == DirMode.Zip | dirMode == DirMode.Tar)
                {
                    string fullPath = Path.Combine(folder, dirName);
                    bool exitcode = false;
                    string tempDir = MakeTempDirectory();
                    try
                    {
                        string archiveName = dirName + $".{dirMode}";
                        string archivePath = Path.Combine(tempDir, archiveName);
                        if (dirMode == DirMode.Zip)
                            CompressionHelper.CreateZip(fullPath, archivePath);
                        else
                            CompressionHelper.CreateTarGZ(fullPath, archivePath);
                        exitcode = await UploadFile(
                            archiveName,
                            archivePath,
                            quiet,
                            files,
                            resources
                        );
                    }
                    finally
                    {
                        Directory.Delete(tempDir, true);
                    }
                    if (exitcode)
                        return null;
                }
                else if (!quiet)
                    return new string[]
                    {
                        $"Skipping folder: {dirName} ; use 'dirMode' to upload folders"
                    };
            }

            return null;
        }

        //return true: Upload unsuccessful ; return false: Upload successful
        async Task<bool> UploadFile(
            string filename,
            string fullPath,
            bool quiet,
            List<DatasetUploadFile> files,
            List<DatasetMetadataResourceLocal> resources
        )
        {
            long contentLength = GetFileSize(fullPath);
            string token = await DatasetUploadFile(fullPath, quiet);
            if (token == null)
                return true;

            DatasetUploadFile uploadFile = new DatasetUploadFile() { token = token };

            if (resources != null)
                foreach (DatasetMetadataResourceLocal item in resources)
                    if (filename == item.path)
                    {
                        uploadFile.description = item.description;
                        if (item.schema != null)
                        {
                            List<DatasetMetadataFieldLocal> fields = defaultIfNull(
                                item.schema.fields,
                                new List<DatasetMetadataFieldLocal>()
                            );

                            List<DatasetUploadColumn> processed = new List<DatasetUploadColumn>();
                            int count = 0;
                            foreach (DatasetMetadataFieldLocal field in fields)
                            {
                                processed.Add(ProcessColumn(field));
                                processed[count].order = count;
                                count++;
                            }
                            uploadFile.columns = processed;
                        }
                    }
            files.Add(uploadFile);
            return false;
        }

        DatasetUploadColumn ProcessColumn(DatasetMetadataFieldLocal column)
        {
            DatasetUploadColumn processedColumn = new DatasetUploadColumn()
            {
                name = failIfNull(column.name),
                description = defaultIfNull(column.description, "")
            };

            if (column.type != null)
            {
                string originalType = column.type.ToLower();
                processedColumn.originalType = originalType;
                if (
                    originalType == "string"
                    | originalType == "date"
                    | originalType == "time"
                    | originalType == "yearmonth"
                    | originalType == "duration"
                    | originalType == "geopoint"
                    | originalType == "geojson"
                )
                    processedColumn.type = "string";
                else if (
                    originalType == "numeric" | originalType == "number" | originalType == "year"
                )
                    processedColumn.type = "numeric";
                else if (originalType == "boolean")
                    processedColumn.type = "boolean";
                else if (originalType == "datetime")
                    processedColumn.type = "datetime";
                else
                    /* Possibly extended data type -not going to try to track those
                    here. Will set the type and let the server handle it.*/
                    processedColumn.type = originalType;
            }
            return processedColumn;
        }

        internal HttpRequestMessage CraftUploadComplete(string path, string url)
        {
            HttpRequestMessage request = api.CreateKaggleRequestMessage("PUT", new Uri(url), "");
            //var multipartContent = new MultipartFormDataContent();

            var file1 = new ByteArrayContent(File.ReadAllBytes(path));
            //file1.Headers.Add("Content-Type", MimeTypeMap.GetMimeType(Path.GetExtension(path)));
            //multipartContent.Add(file1, "file", Path.GetFileName(path));

            request.Content = file1;

            return request;
        }

        internal async Task<bool> UploadComplete(string path, string url, bool quiet)
        {
            HttpRequestMessage request = CraftUploadComplete(path, url);

            HttpResponseMessage response = await api.client.SendAsync(request);
            string json = await response.Content.ReadAsStringAsync();
            //SubmitUploadResult? uploadResult = JsonConvert.DeserializeObject<SubmitUploadResult>(json);

            Debug.WriteLine(json);

            return response.StatusCode == HttpStatusCode.OK
                | response.StatusCode == HttpStatusCode.Created;
        }

        static void ValidateDatasetString(string dataset)
        {
            if (dataset != null)
            {
                if (!dataset.Contains("/"))
                    throw new ArgumentException(
                        "Dataset must be specified in the form of {username}/{dataset-slug}"
                    );

                string[] split = dataset.Split('/');
                if (split.Length != 2)
                    throw new ArgumentException("Invalid dataset specification" + dataset);
            }
        }

        static void ValidateKernelString(string kernel)
        {
            if (kernel != null)
            {
                if (!kernel.Contains('/'))
                    throw new ArgumentException(
                        "Kernel must be specified in the form of {username}/{kernel-slug}"
                    );

                string[] split = kernel.Split('/');
                if (split.Length != 2)
                    throw new ArgumentException(
                        "Kernel must be specified in the form of {username}/{kernel-slug}"
                    );

                if (split[0].Length < 5)
                    throw new ArgumentException("Kernel slug must be at least five characters");
            }
        }

        static void ValidateResources(string folder, List<DatasetMetadataResourceLocal> resources)
        {
            ValidateFileExists(folder, resources);
            ValidateNoDuplicatePaths(resources);
        }

        static void ValidateFileExists(string folder, List<DatasetMetadataResourceLocal> resources)
        {
            foreach (DatasetMetadataResourceLocal item in resources)
            {
                string fileName = item.path;
                if (fileName == null)
                    throw new ArgumentException("A resource was missing its file name");
                string fullPath = Path.Combine(folder, fileName);
                if (!File.Exists(fullPath))
                    throw new ArgumentException($"{fullPath} does not exist");
            }
        }

        static void ValidateNoDuplicatePaths(List<DatasetMetadataResourceLocal> resources)
        {
            HashSet<string> paths = new HashSet<string>();
            foreach (DatasetMetadataResourceLocal item in resources)
            {
                string fileName = item.path;
                if (fileName == null)
                    throw new ArgumentException("A resource was missing its file name");
                if (paths.Contains(fileName))
                    throw new ArgumentException(
                        $"{fileName} path was specified more than once in the metadata"
                    );
                paths.Add(fileName);
            }
        }

        //Get the last modified time (Universal) of a file, in long format
        static long GetMTime(string filename)
        {
            System.TimeSpan timeDifference =
                File.GetLastWriteTime(filename).ToUniversalTime()
                - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixEpochTime = System.Convert.ToInt64(timeDifference.TotalSeconds);

            return unixEpochTime;
        }

        //Convert a date, in string format, to time (Universal), in long format
        static long GetRTime(string date)
        {
            System.TimeSpan timeDifference =
                Convert.ToDateTime(date).ToUniversalTime()
                - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long unixEpochTime = System.Convert.ToInt64(timeDifference.TotalSeconds);

            return unixEpochTime;
        }

        static long GetFileSize(string FilePath)
        {
            //if you don't have permission to the folder, Directory.Exists will return False
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
            {
                //if you land here, it means you don't have permission to the folder
                Debug.Write("Permission denied");
                return -1;
            }
            else if (File.Exists(FilePath))
            {
                return new FileInfo(FilePath).Length;
            }
            return 0;
        }

        static string MakeTempDirectory()
        {
            string tmpDirectory;

            do
            {
                tmpDirectory = Path.Combine(
                    Path.GetTempPath(),
                    Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
                );
            } while (Directory.Exists(tmpDirectory));

            Directory.CreateDirectory(tmpDirectory);
            return tmpDirectory;
        }

        static bool IsDirectory(string path)
        {
            return string.IsNullOrEmpty(Path.GetFileName(path)) || Directory.Exists(path);
        }

        string GetDefaultDir(params string[] subdirs)
        {
            string path = configValues.path;

            if (path == null)
                path = Directory.GetCurrentDirectory();

            string[] workingPath = new string[subdirs.Length + 1];
            workingPath[0] = path;
            Array.Copy(subdirs, 0, workingPath, 1, subdirs.Length);

            return Path.Combine(workingPath);
        }

        string CreateEffectivePath(string path, params string[] subdirs)
        {
            string effectivePath;
            if (path == null)
                effectivePath = GetDefaultDir(subdirs);
            else
                effectivePath = path;

            Directory.CreateDirectory(effectivePath);
            return effectivePath;
        }

        string GetStatusCodeDescription(HttpStatusCode statusCode)
        {
            return (int)statusCode
                + " "
                + Regex.Replace(
                    statusCode.ToString(),
                    "(?<=[a-z])([A-Z])",
                    " $1",
                    RegexOptions.Compiled
                );
        }

        public void Dispose()
        {
            configValues.proxy = null;
            configValues.competition = null;
            configValues.path = null;
            configValues.username = null;
            configValues.key = null;
            configValues.ssl_ca_cert = null;
            configValues.path = null;
            api.Dispose();
        }
    }
}
