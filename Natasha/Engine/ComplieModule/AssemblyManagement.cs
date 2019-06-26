using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Natasha.Engine.ComplieModule
{
    public class AssemblyManagement:AssemblyLoadContext
    {
        public AssemblyManagement(string pluginPath) : base()
        {
            //_resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            throw new NotImplementedException();
        }
    }
}
