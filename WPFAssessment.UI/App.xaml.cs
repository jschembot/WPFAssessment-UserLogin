using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFAssessment.UI.Data;
using WPFAssessment.UI.Startup;
using WPFAssessment.UI.ViewModel;

namespace WPFAssessment.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Adding DI library, this is for the case when we need to add in unit testing. 
            // Going to use Autofac for this because, can resolve the main window instance with any created dependencies. 

            //var mainWindow = new MainWindow(
            //    new MainViewModel(
            //        new UserDataService()));

            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}
