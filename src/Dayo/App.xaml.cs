using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;

namespace Dayo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container InitilizeContainer() 
        {
            Container container = new Container();

            container.Register<Store>(Lifestyle.Singleton);
            container.Register<MainWindowViewModel>();
            container.Register<MainWindow>();

            container.Verify();

            return container;
        }

        private void Application_Startup(object sender, StartupEventArgs e)
		{
            
            Container container = InitilizeContainer();
            MainWindow mainWindow = container.GetInstance<MainWindow>();
            mainWindow.Show();
		}
    }
}
