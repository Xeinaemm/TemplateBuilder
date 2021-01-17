// -----------------------------------------------------------------------
// <copyright file="UserReadModel.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Contracts.ApiReadModels
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class UserReadModel
    {
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("letters")]
        public Dictionary<char, int> Letters { get; set; }

        [JsonProperty("avgStargazers")]
        public long AvgStargazers { get; set; }

        [JsonProperty("avgWatchers")]
        public long AvgWatchers { get; set; }

        [JsonProperty("avgForks")]
        public long AvgForks { get; set; }

        [JsonProperty("avgSize")]
        public long AvgSize { get; set; }

        public static UserReadModel MockContract() => new UserReadModel
        {
            Owner = "Xeinaemm",
            Letters = new Dictionary<char, int>
            {
                { 'a', 0 },
                { 'b', 0 },
            },
            AvgStargazers = 0,
            AvgForks = 1,
            AvgSize = 2,
            AvgWatchers = 3,
        };
    }
}
