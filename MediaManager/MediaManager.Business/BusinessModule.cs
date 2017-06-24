using JLS.Data.Generic;
using MediaManager.Business.Controllers;
using MediaManager.Business.Scanner;
using MediaManager.Business.ViewModels;
using Ninject.Modules;

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
            Bind<IScanResultViewModel>().To<ScanResultViewModel>();
            Bind<IFolderController>().To<FolderController>().InSingletonScope();
            Bind<IFileController>().To<FileController>().InSingletonScope();
            Bind<IMediaFileController>().To<MediaFileController>();
            Bind<ISettingController>().To<SettingController>();
            Bind<ISettingsViewModel>().To<SettingsViewModel>().InSingletonScope();
            Bind<IMediaFactory>().To<MediaFactory>();
        }
    }
}
