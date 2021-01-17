// -----------------------------------------------------------------------
// <copyright file="IGitHubApi.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Github.Contracts.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Refit;
    using Template.Github.Contracts.ApiReadModels;

    public interface IGitHubApi
    {
        [Get("/users/{user}/repos")]
        Task<IEnumerable<GitHubRepositoryReadModel>> GetUserRepositories([Header("Authorization")] string authorization, [Header("User-Agent")] string userAgent, string user);

        [Get("/users/{user}/repos")]
        Task<IEnumerable<GitHubRepositoryReadModel>> GetUserRepositories([Header("User-Agent")] string userAgent, string user);
    }
}
