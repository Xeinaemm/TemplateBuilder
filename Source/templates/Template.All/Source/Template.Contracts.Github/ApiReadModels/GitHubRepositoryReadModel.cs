// -----------------------------------------------------------------------
// <copyright file="GitHubRepositoryReadModel.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Github.Contracts.ApiReadModels
{
    using Newtonsoft.Json;

    public class GitHubRepositoryReadModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public GitHubOwner Owner { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonProperty("watchers_count")]
        public int WatchersCount { get; set; }

        [JsonProperty("forks_count")]
        public int ForksCount { get; set; }
    }
}
