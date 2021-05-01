using Autofac;
using System.Windows;
using WPFAssessment.UI.Startup;

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
