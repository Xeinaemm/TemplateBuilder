// -----------------------------------------------------------------------
// <copyright file="IUserApi.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Contracts.Api
{
    using System.Net.Mime;
    using System.Threading.Tasks;
    using Refit;
    using Template.Contracts.ApiReadModels;

    public interface IUserApi
    {
        [Get("/repositories/{owner}")]
        Task<UserReadModel> GetUserStatistics(string owner, [Header("Accept")] string mediaType = MediaTypeNames.Application.Json);
    }
}
