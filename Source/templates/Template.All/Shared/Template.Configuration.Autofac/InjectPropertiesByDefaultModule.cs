// -----------------------------------------------------------------------
// <copyright file="InjectPropertiesByDefaultModule.cs" company="Piotr Xeinaemm Czech">
// Copyright (c) Piotr Xeinaemm Czech. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------

namespace Template.Configuration.Autofac
{
    using global::Autofac;
    using global::Autofac.Core;
    using global::Autofac.Core.Registration;

    internal class InjectPropertiesByDefaultModule : Module
    {
        protected override void AttachToComponentRegistration(
            IComponentRegistryBuilder componentRegistry,
            IComponentRegistration registration) => registration.Activating += (s, e) => e.Context.InjectProperties(e.Instance);
    }
}
