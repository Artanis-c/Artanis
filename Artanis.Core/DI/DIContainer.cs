using System;
using System.Collections.Generic;
using System.Text;

namespace Artanis.Core.DI
{
    public static class DIContainer
    {
        public static IServiceProvider serviceProvider { get; set; }

        public static T GetService<T>() where T : class
        {
            return serviceProvider.GetService(typeof(T)) as T;
        }
    }
}
