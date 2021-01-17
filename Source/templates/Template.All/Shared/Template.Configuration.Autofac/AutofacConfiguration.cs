// -----------------------------------------------------------------------
// <copyright file="AutofacConfiguration.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Configuration.Autofac
{
    using System;
    using global::Autofac;
    using global::Autofac.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;

    public static class AutofacConfiguration
    {
        public static IServiceProvider InitializeWeb(this IServiceCollection services, ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null) =>
            new AutofacServiceProvider(BaseAutofacSetup(config, setupAction =>
            {
                setupAction.Populate(services);
                extendedSetupAction?.Invoke(setupAction);
            }));

        public static IServiceProvider InitializeApi(this IServiceCollection services, ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null) =>
            new AutofacServiceProvider(BaseAutofacSetup(config, setupAction =>
            {
                setupAction.Populate(services);
                extendedSetupAction?.Invoke(setupAction);
            }));

        public static IServiceProvider InitializeReadApi(this IServiceCollection services, ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null) =>
            new AutofacServiceProvider(BaseAutofacSetup(config, setupAction =>
            {
                setupAction.Populate(services);
                extendedSetupAction?.Invoke(setupAction);
            }));

        public static IContainer InitializeWeb(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        public static IContainer InitializeServiceBus(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        public static IContainer InitializeApi(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        public static IContainer InitializeReadApi(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        public static IContainer InitializeWindowsService(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        public static IContainer InitializeTests(ContainerConfiguration config, Action<ContainerBuilder> extendedSetupAction = null)
            => BaseAutofacSetup(config, extendedSetupAction);

        private static IContainer BaseAutofacSetup(ContainerConfiguration config, Action<ContainerBuilder> setupAction = null)
        {
            var builder = new ContainerBuilder();
            setupAction?.Invoke(builder);
            builder.RegisterAssemblyTypes(config.RegisterAssemblies).AsImplementedInterfaces();
            builder.RegisterModule<InjectPropertiesByDefaultModule>();

            // Modules for Consul, Serilog, elasticsearch, kibana etc.
            return builder.Build();
        }
    }
}
