using Prism.Ioc;
using PrismWPFLearn.Views;
using System.Windows;

namespace PrismWPFLearn
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PrismUserControl1>();
            containerRegistry.RegisterForNavigation<PrismUserControl2>();

        }
    }
}
