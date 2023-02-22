/*
 * Copyright 2023 PetterPet
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
using System.ComponentModel;

namespace KaggleAPI.Web.Models
{
    public enum LicenseType
    {
        [Description("CC0 1.0 Universal (CC0 1.0)")]
        CC0_10,

        [Description("Attribution-ShareAlike 4.0 International (CC BY-SA 4.0)")]
        CC_BY_SA_40,

        [Description("GNU General Public License, version 2 (GPLv2)")]
        GPL_20,

        [Description("Open Data Commons Open Database License (ODbL) v1.0")]
        ODbL_10,

        [Description(
            "Attribution-NonCommercial-ShareAlike 4.0 International (CC BY-NC-SA 4.0)\r\n"
        )]
        CC_BY_NC_SA_40,

        [Description("Unknown license")]
        unknown,

        [Description("Database Contents License (DbCL) v1.0")]
        DbCL_10,

        [Description("Attribution-ShareAlike 3.0 Unported (CC BY-SA 3.0)")]
        CC_BY_SA_30,

        [Description("Copyright authors")]
        copyright_authors,

        [Description("Other license")]
        other,

        [Description("Reddit API")]
        reddit_api,

        [Description("World Bank")]
        world_bank
    }

    public class License
    {
        [JsonIgnore]
        public static Dictionary<LicenseType, string> licenseMap = new Dictionary<
            LicenseType,
            string
        >()
        {
            { LicenseType.CC0_10, "CC0-1.0" },
            { LicenseType.CC_BY_SA_40, "CC-BY-SA-4.0" },
            { LicenseType.GPL_20, "GPL-2.0" },
            { LicenseType.ODbL_10, "ODbL-1.0" },
            { LicenseType.CC_BY_NC_SA_40, "CC-BY-NC-SA-4.0" },
            { LicenseType.unknown, "unknown" },
            { LicenseType.DbCL_10, "DbCL-1.0" },
            { LicenseType.CC_BY_SA_30, "CC-BY-SA-3.0" },
            { LicenseType.copyright_authors, "copyright-authors" },
            { LicenseType.other, "other" },
            { LicenseType.reddit_api, "reddit-api" },
            { LicenseType.world_bank, "world-bank" },
        };

        public string name { get; set; }
        public string nameNullable { get; set; }
        public bool hasName { get; set; }

        public License(LicenseType license)
        {
            nameNullable = licenseMap[license];
            name = licenseMap[license];
            hasName = true;
        }
    }
}
