// -----------------------------------------------------------------------
// <copyright file="InitializeContainer.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Application.Setup.ContainerTasks
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using Autofac;
    using Microsoft.Extensions.DependencyInjection;
    using Refit;
    using Template.Application.Services;
    using Template.Configuration.Autofac;
    using Template.Contracts.Api;
    using Template.Github.Contracts.Api;

    public static class InitializeContainer
    {
        private static ContainerConfiguration Container { get; } = new ContainerConfiguration
        {
            RegisterAssemblies = new Assembly[] { typeof(UserService).Assembly },
        };

        public static IServiceProvider InitializeWeb(this IServiceCollection services, Action<ContainerBuilder> extendedSetupAction = null) =>
            services.InitializeWeb(Container, setupAction =>
            {
                setupAction.CommonSetup();
                extendedSetupAction?.Invoke(setupAction);
            });

        public static IServiceProvider InitializeApi(this IServiceCollection services, Action<ContainerBuilder> extendedSetupAction = null) =>
            services.InitializeApi(Container, setupAction =>
            {
                setupAction.CommonSetup();
                extendedSetupAction?.Invoke(setupAction);
            });

        public static IServiceProvider InitializeReadApi(this IServiceCollection services, Action<ContainerBuilder> extendedSetupAction = null) =>
            services.InitializeReadApi(Container, setupAction =>
            {
                setupAction.CommonSetup();
                extendedSetupAction?.Invoke(setupAction);
            });

        public static IContainer InitializeTests(HttpClient client) =>
            AutofacConfiguration.InitializeTests(Container, setupAction =>
            {
                setupAction.Register(c => RestService.For<IUserApi>(client)).As<IUserApi>();
                setupAction.CommonSetup();
            });

        public static IContainer InitializeTests() =>
            AutofacConfiguration.InitializeTests(Container, setupAction => setupAction.CommonSetup());

        private static void CommonSetup(this ContainerBuilder builder) =>
            builder.Register(c => RestService.For<IGitHubApi>("https://api.github.com/")).As<IGitHubApi>();
    }
}
