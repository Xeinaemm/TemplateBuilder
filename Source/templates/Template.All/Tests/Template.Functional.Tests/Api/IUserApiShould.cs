namespace Template.FunctionalTests.Api
{
    using System.Threading.Tasks;
    using Template.Api;
    using Template.Application.Setup.ContainerTasks;
    using Template.Contracts.Api;
    using Template.Contracts.ApiReadModels;
    using Template.Tests.Common.Attributes;
    using Template.Web.Http;
    using Autofac;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc.Testing;
    using Xunit;

    public class IUserApiShould : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IUserApi userApi;

        public IUserApiShould(WebApplicationFactory<Startup> factory)
        {
            using var scope = InitializeContainer.InitializeTests(factory.CreateClient()).BeginLifetimeScope();
            this.userApi = scope.Resolve<IUserApi>();
        }

        [Theory]
        [InlineData("Xeinaemm")]
        public async Task ReturnsCorrectUser(string user)
        {
            var usr = await this.userApi.GetUserStatistics(user); // ~1sec
            Assert.Equal(user, usr.Owner);
        }

        [Theory]
        [AutoMoqData]
        public async Task ReturnsCorrectUserMock(string user)
        {
            var expected = UserReadModel.MockContract();
            var actual = await this.userApi.GetUserStatistics(user, TemplateMediaType.MockOutputFormatterJson); // ~38ms

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
