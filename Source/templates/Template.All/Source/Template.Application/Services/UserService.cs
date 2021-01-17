// -----------------------------------------------------------------------
// <copyright file="UserService.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Application.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Template.Contracts.ApiReadModels;
    using Template.Contracts.Services;
    using Template.Github.Contracts.Api;

    public class UserService : IUserService
    {
        private readonly IGitHubApi gitHubApi;

        public UserService(IGitHubApi gitHubApi) => this.gitHubApi = gitHubApi;

        public async Task<UserReadModel> GetUserStatistics(string owner)
        {
            var repos = await this.gitHubApi.GetUserRepositories(owner, owner);

            var reposCount = repos.Count();
            var avgForks = 0;
            var avgSize = 0;
            var avgWatchers = 0;
            var avgStargazers = 0;
            var letters = string.Empty;
            foreach (var repo in repos)
            {
                avgForks += repo.ForksCount;
                avgSize += repo.Size;
                avgWatchers += repo.WatchersCount;
                avgStargazers += repo.StargazersCount;
                avgStargazers += repo.ForksCount;
                letters += repo.Name;
            }

            var dict = letters
                             .Replace(" ", string.Empty)
                             .Replace(".", string.Empty)
                             .Replace("-", string.Empty)
                             .GroupBy(c => c)
                             .ToDictionary(gr => gr.Key, gr => gr.Count());
            return new UserReadModel
            {
                Owner = repos.FirstOrDefault().Owner.Login,
                AvgForks = avgForks / reposCount,
                AvgSize = avgSize / reposCount,
                AvgStargazers = avgStargazers / reposCount,
                AvgWatchers = avgWatchers / reposCount,
                Letters = dict,
            };
        }
    }
}
