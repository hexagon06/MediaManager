using JLS.Data.Generic;
using MediaManager.Business.Scanner;
using MediaManager.Business.ViewModels;
using MediaManager.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Business
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepository<>)).To(typeof(DbContextRepository<>));
            Bind<IFolderScanner>().To<FolderScanner>();
            Bind<IExplorerViewModel>().To<ExplorerViewModel>();
            Bind<IScanResultFactory>().To<ScanResultFactory>();
        }
    }
}
