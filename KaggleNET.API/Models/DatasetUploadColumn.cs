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
    public class DatasetUploadColumn
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "order", "float" },
            { "name", "str" },
            { "type", "str" },
            { "original_type", "str" },
            { "description", "str" }
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "order", "order" },
            { "name", "name" },
            { "type", "type" },
            { "original_type", "originalType" },
            { "description", "description" }
        };

        public float order { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string originalType { get; set; }
        public string description { get; set; }
    }
}
