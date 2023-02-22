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
    public class DatasetNewRequest
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "title", "str" },
            { "slug", "str" },
            { "owner_slug", "str" },
            { "license_name", "str" },
            { "subtitle", "str" },
            { "description", "str" },
            { "files", "list[DatasetUploadFile]" },
            { "is_private", "bool" },
            { "convert_to_csv", "bool" },
            { "category_ids", "list[str]" }
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "title", "title" },
            { "slug", "slug" },
            { "owner_slug", "ownerSlug" },
            { "license_name", "licenseName" },
            { "subtitle", "subtitle" },
            { "description", "description" },
            { "files", "files" },
            { "is_private", "isPrivate" },
            { "convert_to_csv", "convertToCsv" },
            { "category_ids", "categoryIds" }
        };

        public string title { get; set; }
        public string slug { get; set; }
        public string ownerSlug { get; set; }
        public string licenseName { get; set; }
        public string subtitle { get; set; }
        public string description { get; set; }
        public List<DatasetUploadFile> files { get; set; }
        public bool isPrivate { get; set; }
        public bool convertToCsv { get; set; }
        public List<string> categoryIds { get; set; }
    }
}
