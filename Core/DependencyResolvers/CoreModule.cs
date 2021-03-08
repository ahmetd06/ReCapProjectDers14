﻿using System;
//using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//using Core.CrossCuttingConcerns.Caching;
using System.Diagnostics;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        

        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
          //serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); 
          //serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
