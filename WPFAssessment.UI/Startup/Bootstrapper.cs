using Autofac;
using WPFAssessment.DataAccess;
using WPFAssessment.UI.Data;
using WPFAssessment.UI.ViewModel;

namespace WPFAssessment.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserLoginDbContext>().AsSelf();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<UserDataService>().As<IUserDataService>();
            return builder.Build();
        }
    }
}
