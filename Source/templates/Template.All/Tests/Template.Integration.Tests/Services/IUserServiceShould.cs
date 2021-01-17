// -----------------------------------------------------------------------
// <copyright file="IUserServiceShould.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.IntegrationTests.Services
{
    using System.Threading.Tasks;
    using Autofac;
    using Template.Application.Setup.ContainerTasks;
    using Template.Contracts.Services;
    using Xunit;

    public class IUserServiceShould
    {
        private readonly IUserService userService;

        public IUserServiceShould()
        {
            using var scope = InitializeContainer.InitializeTests().BeginLifetimeScope();
            this.userService = scope.Resolve<IUserService>();
        }

        [Theory]
        [InlineData("Xeinaemm")]
        public async Task ReturnsCorrectUser(string user)
        {
            var usr = await this.userService.GetUserStatistics(user);
            Assert.Equal(user, usr.Owner);
        }
    }
}
