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
 */

using Newtonsoft.Json;
using System.Collections.Generic;

namespace KaggleAPI.Web.Models
{
    public class DatasetNewVersionRequest
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "version_notes", "str" },
            { "subtitle", "str" },
            { "description", "str" },
            { "files", "list[DatasetUploadFile]" },
            { "convert_to_csv", "bool" },
            { "category_ids", "list[str]" },
            { "delete_old_versions", "bool" }
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "version_notes", "versionNotes" },
            { "subtitle", "subtitle" },
            { "description", "description" },
            { "files", "files" },
            { "convert_to_csv", "convertToCsv" },
            { "category_ids", "categoryIds" },
            { "delete_old_versions", "deleteOldVersions" }
        };

        [JsonProperty(Required = Required.Always)]
        public string versionNotes { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string subtitle { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<DatasetUploadFile> files { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool convertToCsv { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> categoryIds { get; set; }

        [JsonProperty(Required = Required.Always)]
        public bool deleteOldVersions { get; set; }
    }
}
