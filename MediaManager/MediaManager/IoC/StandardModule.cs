using MediaManager.Business;
using MediaManager.Entity;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.IoC
{
    class StandardModule : NinjectModule
    {
        private string ConnectionStringName { get; set; }

        public StandardModule(string connectionstringName)
        {
            ConnectionStringName = connectionstringName;
        }

        public override void Load()
        {
            Bind<DbContext>().To<EntityContext>().WithConstructorArgument(ConnectionStringName);
            Bind<IUserInput>().To<UserInput>().InSingletonScope();
        }
    }
}
