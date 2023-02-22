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
    public class DatasetUploadFile
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "token", "str" },
            { "description", "str" },
            { "columns", "list[DatasetColumn]" }
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "token", "token" },
            { "description", "description" },
            { "columns", "columns" }
        };

        [JsonProperty(Required = Required.Always)]
        public string token { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string description { get; set; }

        [JsonProperty(Required = Required.Always)]
        public List<DatasetUploadColumn> columns { get; set; }
    }
}
