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
    public class Collaborator
    {
        [JsonIgnore]
        public static Dictionary<string, string> swagger_types = new Dictionary<string, string>()
        {
            { "username", "str" },
            { "role", "str" },
        };

        [JsonIgnore]
        public static Dictionary<string, string> attribute_map = new Dictionary<string, string>()
        {
            { "username", "username" },
            { "role", "role" },
        };

        public string username { get; set; }
        public string role { get; set; }
    }
}
