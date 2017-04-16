using MediaManager.Business;
using MediaManager.IoC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace MediaManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _dbContextString;

        private static string DbContextString
        {
            get
            {
                if (string.IsNullOrEmpty(_dbContextString))
                {
                    _dbContextString = ConfigurationManager.AppSettings["DbContextString"];
                }
                return _dbContextString;
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IoCKernel.Initialize(
                new StandardModule(DbContextString),
                new BusinessModule());

            string folderName = ConfigurationManager.AppSettings["applicationDataDirectoryName"];
            if (folderName == null) throw new ConfigurationErrorsException("Missing appsetting applicationDataDirectoryName");
            var completePath = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                folderName);
            if (Directory.Exists(completePath) == false) Directory.CreateDirectory(completePath);

            AppDomain.CurrentDomain.SetData("DataDirectory", completePath);

            base.OnStartup(e);
        }
    }
}
