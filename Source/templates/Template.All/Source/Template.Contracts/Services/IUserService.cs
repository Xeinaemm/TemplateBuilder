// -----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Contracts.Services
{
    using System.Threading.Tasks;
    using Template.Contracts.ApiReadModels;

    public interface IUserService
    {
        Task<UserReadModel> GetUserStatistics(string owner);
    }
}
