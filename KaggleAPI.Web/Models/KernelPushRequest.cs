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
    public class KernelPushRequest
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "id", "int" },
            { "slug", "str" },
            { "new_title", "str" },
            { "text", "str" },
            { "language", "str" },
            { "kernel_type", "str" },
            { "is_private", "bool" },
            { "enable_gpu", "bool" },
            { "enable_internet", "bool" },
            { "dataset_data_sources", "list[str]" },
            { "competition_data_sources", "list[str]" },
            { "kernel_data_sources", "list[str]" },
            { "category_ids", "list[str]" },
            { "docker_image_pinning_type", "str" }
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "id", "id" },
            { "slug", "slug" },
            { "new_title", "newTitle" },
            { "text", "text" },
            { "language", "language" },
            { "kernel_type", "kernelType" },
            { "is_private", "isPrivate" },
            { "enable_gpu", "enableGpu" },
            { "enable_internet", "enableInternet" },
            { "dataset_data_sources", "datasetDataSources" },
            { "competition_data_sources", "competitionDataSources" },
            { "kernel_data_sources", "kernelDataSources" },
            { "category_ids", "categoryIds" },
            { "docker_image_pinning_type", "dockerImagePinningType" }
        };

        [JsonProperty(Required = Required.Default)]
        public int? id { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string slug { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string newTitle { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string text { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string language { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string kernelType { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? isPrivate { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? enableGpu { get; set; }

        [JsonProperty(Required = Required.Default)]
        public bool? enableInternet { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> datasetDataSources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> competitionDataSources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> kernelDataSources { get; set; }

        [JsonProperty(Required = Required.Default)]
        public List<string> categoryIds { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string dockerImagePinningType { get; set; }
    }
}
