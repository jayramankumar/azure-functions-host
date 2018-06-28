// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Script.WebHost.DependencyInjection
{
    public class FunctionsServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        private FunctionsServiceProvider _provider;

        public IServiceCollection CreateBuilder(IServiceCollection services)
        {
            return services;
        }

        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            if (_provider == null)
            {
                _provider = new FunctionsServiceProvider(containerBuilder);
            }
            else
            {
                _provider.AddServices(containerBuilder);
            }

            return _provider;
        }
    }
}
