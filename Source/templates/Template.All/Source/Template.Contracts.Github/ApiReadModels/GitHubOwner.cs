// -----------------------------------------------------------------------
// <copyright file="GitHubOwner.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Github.Contracts.ApiReadModels
{
    using Newtonsoft.Json;

    public class GitHubOwner
    {
        [JsonProperty("login")]
        public string Login { get; set; }
    }
}