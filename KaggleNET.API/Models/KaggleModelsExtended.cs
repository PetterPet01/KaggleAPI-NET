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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace KaggleAPI.Web.Models
{
    public class KaggleServerException
    {
        [JsonProperty(Required = Required.Always)]
        public int? code { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string message { get; set; }
    }

    //public class KaggleStatus
    //{
    //    //public KaggleServerException Exception { get; set; }
    //    public List<string> InternalMessage { get; set; }
    //}

    public class CompetitionInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string titleNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string organizationNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string organizationRefNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string categoryNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string rewardNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string userRankNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int maxTeamSizeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string evaluationMetricNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string organizationName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOrganizationName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string organizationRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOrganizationRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string category { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCategory { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string reward { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasReward { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Tag> tags { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime deadline { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int kernelCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int teamCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool userHasEntered { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int userRank { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUserRank { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime mergerDeadline { get; set; }

        //Changed Required.Always to Required.AllowNull after testing
        [JsonProperty(Required = Required.AllowNull)]
        public DateTime? newEntrantDeadline { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime enabledDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int maxDailySubmissions { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int maxTeamSize { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasMaxTeamSize { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string evaluationMetric { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasEvaluationMetric { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool awardsPoints { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isKernelsSubmissionsOnly { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool submissionsDisabled { get; set; }
    }

    public class CompetitionSubmitStatus
    {
        [JsonProperty(Required = Required.Always)]
        public string message { get; set; }
    }

    public class CompetitionSubmissionInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public int totalBytesNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string errorDescriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string fileNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string publicScoreNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string privateScoreNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string submittedByNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string submittedByRefNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string teamNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalBytes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTotalBytes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime date { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string errorDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasErrorDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string fileName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasFileName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string publicScore { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasPublicScore { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string privateScore { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasPrivateScore { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string submittedBy { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSubmittedBy { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string submittedByRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSubmittedByRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string teamName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTeamName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }
    }

    public class CompetitionDataFileInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string nameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalBytes { get; set; }

        [JsonIgnore]
        public string size { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime creationDate { get; set; }

        public static string get_size(long size, int precision = 0)
        {
            string[] suffix = new string[] { "B", "KB", "MB", "GB", "TB" };
            int suffix_index = 0;
            decimal sizeD = size;
            while (sizeD >= 1024 && suffix_index < 4)
            {
                suffix_index += 1;
                sizeD /= 1024;
            }
            //return Math.Round(sizeD, precision).ToString() + suffix[suffix_index];
            return sizeD.ToString("F" + precision) + suffix[suffix_index];
        }
    }

    public class CompetitionLeaderboardSubmission
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string teamNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string scoreNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int teamId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string teamName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTeamName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime submissionDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string score { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasScore { get; set; }
    }

    public class CompetitionLeaderboardInquiry
    {
        [JsonProperty(Required = Required.Always)]
        public List<CompetitionLeaderboardSubmission> submissions { get; set; }
    }

    public class DatasetInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string subtitleNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string creatorNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string creatorUrlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public long totalBytesNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string licenseNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string ownerNameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string ownerRefNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string titleNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public int currentVersionNumberNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public double usabilityRatingNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string subtitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSubtitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string creatorName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCreatorName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string creatorUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCreatorUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public long totalBytes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTotalBytes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime lastUpdated { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int downloadCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isFeatured { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string licenseName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasLicenseName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ownerName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOwnerName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ownerRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOwnerRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int kernelCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int topicCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int viewCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int voteCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int currentVersionNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCurrentVersionNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public double usabilityRating { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUsabilityRating { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Tag> tags { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DatasetFile> files { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DatasetVersion> versions { get; set; }
    }

    public class DatasetVersion
    {
        [JsonProperty(Required = Required.Always)]
        public string creatorNameNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string creatorRefNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string versionNotesNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string statusNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int versionNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime creationDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string creatorName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCreatorName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string creatorRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasCreatorRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string versionNotes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasVersionNotes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasStatus { get; set; }
    }

    public class DatasetDataFilesInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string errorMessageNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DatasetFile> datasetFiles { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string errorMessage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasErrorMessage { get; set; }
    }

    public class DatasetFile
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string datasetRefNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string ownerRefNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string nameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string fileTypeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string datasetRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDatasetRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ownerRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOwnerRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime creationDate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string fileType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasFileType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalBytes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DatasetColumn> columns { get; set; }
    }

    public class DatasetColumn
    {
        [JsonProperty(Required = Required.AllowNull)]
        public int orderNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string nameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string typeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string originalTypeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int order { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOrder { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string type { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string originalType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOriginalType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }
    }

    public class DatasetMetadataLocal
    {
        [JsonProperty(Required = Required.Default)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string subtitle { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Default)]
        //https://github.com/Kaggle/kaggle-api/blob/49057db362903d158b1e71a43d888b981dd27159/kaggle/api/kaggle_api_extended.py#L1021
        public bool isPrivate { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string id { get; set; }

        [JsonProperty(Required = Required.Default)]
        public int? id_no { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<License> licenses { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<DatasetMetadataResourceLocal> resources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> keywords { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<Collaborator> collaborators { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<object> data { get; set; }
    }

    public class DatasetMetadataFieldLocal
    {
        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string type { get; set; }
    }

    public class DatasetMetadataSchemaLocal
    {
        [JsonProperty(Required = Required.Always)]
        public List<DatasetMetadataFieldLocal> fields { get; set; }
    }

    public class DatasetMetadataResourceLocal
    {
        [JsonProperty(Required = Required.Always)]
        public string path { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DatasetMetadataSchemaLocal schema { get; set; }
    }

    public class DatasetMetadataUpdateError
    {
        [JsonProperty(Required = Required.Always)]
        public string message { get; set; }
    }

    public class DatasetMetadataUpdateStatus
    {
        [JsonProperty(Required = Required.Always)]
        public List<DatasetMetadataUpdateError> errors { get; set; }
    }

    public class DatasetMetadataInquiryInfo
    {
        //[JsonProperty(Required = Required.Always)]
        //public string id { get; set; }
        //[JsonProperty(Required = Required.Always)]
        //public int id_no { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string datasetSlugNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string ownerUserNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public double usabilityRatingNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string titleNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string subtitleNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int datasetId { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string datasetSlug { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDatasetSlug { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string ownerUser { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasOwnerUser { get; set; }

        [JsonProperty(Required = Required.Always)]
        public double usabilityRating { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUsabilityRating { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalViews { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalVotes { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalDownloads { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasTitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string subtitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSubtitle { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> keywords { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<License> licenses { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<Collaborator> collaborators { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<object> data { get; set; }
    }

    public class DatasetMetadataInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string errorMessageNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DatasetMetadataInquiryInfo info { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string errorMessage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasErrorMessage { get; set; }
    }

    public class DatasetCreateVersionStatus
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string refNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string statusNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string errorNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasStatus { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string error { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasError { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidTags { get; set; }
    }

    public class DatasetCreateNewStatus
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string refNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string statusNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string errorNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasRef { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasStatus { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string error { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasError { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidTags { get; set; }
    }

    public class KernelInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string languageNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string kernelTypeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? isPrivateNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? enableGpuNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? enableInternetNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string author { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string slug { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string lastRunTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string language { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasLanguage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string kernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasKernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasIsPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool enableGpu { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasEnableGpu { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool enableInternet { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasEnableInternet { get; set; }

        //I'm not too sure of what type these four lists should consist, my best bet is data type string (https://github.com/Kaggle/kaggle-api/wiki/Kernel-Metadata)
        [JsonProperty(Required = Required.Always)]
        public List<string> categoryIds { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> datasetDataSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> kernelDataSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> competitionDataSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalVotes { get; set; }
    }

    public class KernelMetadataLocal
    {
        //https://github.com/Kaggle/kaggle-api/wiki/Kernel-Metadata
        [JsonProperty(Required = Required.Default)]
        public string id { get; set; }

        [JsonProperty(Required = Required.Default)]
        public int? id_no { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string code_file { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string language { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string kernel_type { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? is_private { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? enable_gpu { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? enable_internet { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> dataset_sources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> competition_sources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> kernel_sources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> keywords { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string docker_image_pinning_type { get; set; }
    }

    public class KernelPushStatus
    {
        [JsonProperty(Required = Required.AllowNull)]
        public int? versionNumberNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string errorNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int versionNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasVersionNumber { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string error { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasError { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidTags { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidDatasetSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidCompetitionSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<string> invalidKernelSources { get; set; }
    }

    public class KernelPullInquiry
    {
        [JsonProperty(Required = Required.Always)]
        public KernelPullMetadata metadata { get; set; }

        [JsonProperty(Required = Required.Always)]
        public KernelPullBlob blob { get; set; }
    }

    public class KernelPullMetadata
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string languageNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string kernelTypeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? isPrivateNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? enableGpuNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public bool? enableInternetNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int id { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string author { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string slug { get; set; }

        [JsonProperty(Required = Required.Always)]
        public DateTime lastRunTime { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string language { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasLanguage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string kernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasKernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool isPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasIsPrivate { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool enableGpu { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasEnableGpu { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool enableInternet { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasEnableInternet { get; set; }

        //https://github.com/Kaggle/kaggle-api/blob/master/kaggle/api/kaggle_api_extended.py#L2057
        [JsonProperty(Required = Required.Default)]
        public List<string> categoryIds { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> datasetDataSources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> kernelDataSources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> competitionDataSources { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalVotes { get; set; }
    }

    public class KernelPullBlob
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string sourceNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string languageNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string kernelTypeNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string slugNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string source { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSource { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string language { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasLanguage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string kernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasKernelType { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string slug { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasSlug { get; set; }
    }

    public class KernelOutputFile
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string urlNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string fileNameNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string url { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasUrl { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string fileName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasFileName { get; set; }
    }

    public class KernelOutputInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string logNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public object nextPageTokenNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<KernelOutputFile> files { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string log { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasLog { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string nextPageToken { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasNextPageToken { get; set; }
    }

    public class KernelStatusInquiry
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string failureMessageNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string status { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string failureMessage { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasFailureMessage { get; set; }
    }

    //Json response type of upload requests in Competitions, Datasets
    public class UploadPostResponse
    {
        [JsonProperty(Required = Required.Always)]
        public string token { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string createUrl { get; set; }
    }

    public class Tag
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string nameNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string descriptionNullable { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string fullPathNullable { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string @ref { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string name { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasName { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasDescription { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string fullPath { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool hasFullPath { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int competitionCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int datasetCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int scriptCount { get; set; }

        [JsonProperty(Required = Required.Always)]
        public int totalCount { get; set; }
    }
}
