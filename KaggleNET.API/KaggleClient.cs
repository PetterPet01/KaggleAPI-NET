using KaggleAPI.Web.Interfaces;
using KaggleAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static KaggleAPI.Web.KaggleEnum;

namespace KaggleAPI.Web
{
    public class KaggleClient : IDisposable
    {
        KaggleAPIExtended api;

        public KaggleClient()
        {
            api = new KaggleAPIExtended();
        }

        public KaggleClient(IKaggleInformationLogger logger)
        {
            api = new KaggleAPIExtended(logger);
        }

        public AuthenticationMethod Authenticate(
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            return api.Authenticate(configuration, filename, method);
        }

        public AuthenticationMethod Authenticate(
            HttpClientHandler handler,
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            return api.Authenticate(handler, configuration, filename, method);
        }

        public AuthenticationMethod Authenticate(
            HttpClient client,
            KaggleConfiguration configuration = null,
            string filename = null,
            AuthenticationMethod method = AuthenticationMethod.Auto
        )
        {
            return api.Authenticate(client, configuration, filename, method);
        }

        public async Task<List<CompetitionInquiry>> CompetitionsList(
            CompetitionGroup? group = null,
            CompetitionCategory? category = null,
            CompetitionSortBy? sortBy = null,
            int? page = 1,
            string search = null,
            bool quiet = false
        )
        {
            return await api.CompetitionsList(group, category, sortBy, page, search);
        }

        public async Task<CompetitionSubmitStatus> CompetitionSubmit(
            string path,
            string message,
            string competition,
            bool quiet = false
        )
        {
            return await api.CompetitionSubmitWrapped(path, message, competition, quiet);
        }

        public async Task<List<CompetitionSubmissionInquiry>> CompetitionSubmissions(
            string competition = null,
            int? page = 1,
            bool quiet = false
        )
        {
            return await api.CompetitionSubmissionsWrapped(competition, page, quiet);
        }

        public async Task<List<CompetitionDataFileInquiry>> CompetitionListFiles(
            string competition,
            bool quiet = false
        )
        {
            return await api.CompetitionListFilesWrapped(competition, quiet);
        }

        public async Task CompetitionDownload(
            string competition,
            string filename = null,
            string path = null,
            bool force = false,
            bool quiet = false
        )
        {
            await api.CompetitionDownloadWrapped(competition, filename, path, force, quiet);
        }

        public async Task<CompetitionLeaderboardInquiry> CompetitionLeaderboard(
            string competition,
            string path,
            bool view = false,
            bool download = false,
            bool quiet = false
        )
        {
            return await api.CompetitionLeaderboardWrapped(
                competition,
                path,
                view,
                download,
                quiet
            );
        }

        public async Task<List<DatasetInquiry>> DatasetList(
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
            return await api.DatasetListWrapped(
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
        }

        public async Task<DatasetInquiry> DatasetView(string dataset)
        {
            return await api.DatasetView(dataset);
        }

        public async Task<string> DatasetMetadata(string dataset, string path, bool update)
        {
            return await api.DatasetMetadataWrapped(dataset, path, update);
        }

        public async Task<DatasetDataFilesInquiry> DatasetListFiles(string dataset)
        {
            return await api.DatasetListFilesWrapped(dataset);
        }

        public async Task<string> DatasetStatus(string dataset)
        {
            return await api.DatasetStatusWrapped(dataset);
        }

        public async Task<bool> DatasetDownload(
            string dataset,
            string filename = null,
            string path = null,
            bool force = false,
            bool unzip = false,
            bool quiet = false
        )
        {
            return await api.DatasetDownloadWrapped(dataset, filename, path, force, unzip, quiet);
        }

        public async Task<DatasetCreateVersionStatus> DatasetCreateVersion(
            string folder,
            string versionNotes,
            bool quiet = false,
            bool convertToCsv = true,
            bool deleteOldVersions = false,
            DirMode dirMode = DirMode.Skip
        )
        {
            return await api.DatasetCreateVersionWrapped(
                folder,
                versionNotes,
                quiet,
                convertToCsv,
                deleteOldVersions,
                dirMode
            );
        }

        public async Task<string> DatasetInitialize(string folder = null)
        {
            return await api.DatasetInitializeWrapped(folder);
        }

        public async Task<DatasetCreateNewStatus> DatasetCreateNew(
            string folder = null,
            bool @public = false,
            bool quiet = false,
            bool convertToCsv = true,
            DirMode dirMode = DirMode.Skip
        )
        {
            return await api.DatasetCreateNewWrapped(folder, @public, quiet, convertToCsv, dirMode);
        }

        public async Task<List<KernelInquiry>> KernelsList(
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
            return await api.KernelsListWrapped(
                mine,
                page,
                pageSize,
                search,
                parent,
                competition,
                dataset,
                user,
                language,
                kernelType,
                outputType,
                sortBy
            );
        }

        public string KernelsInitialize(string folder = null)
        {
            return api.KernelsInitializeWrapped(folder);
        }

        public async Task<KernelPushStatus> KernelsPush(string folder)
        {
            return await api.KernelsPushWrapped(folder);
        }

        public async Task<string> KernelsPull(string kernel, string path, bool metadata = false)
        {
            return await api.KernelsPullWrapped(kernel, path, metadata);
        }

        public async Task<List<string>> KernelsOutput(
            string kernel,
            string path,
            bool force = false,
            bool quiet = true
        )
        {
            return await api.KernelsOutputWrapped(kernel, path, force, quiet);
        }

        public async Task<KernelStatusInquiry> KernelsStatus(string kernel)
        {
            return await api.KernelsStatusWrapped(kernel);
        }

        public void Dispose()
        {
            api.Dispose();
        }
    }
}
