using Bestiary.DataAccess;
using Bestiary.Shared;
using Bestiary.ViewModels;
using Bestiary.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Windows;

namespace Bestiary
{
    partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IBestiary>(() => new APIBestiary("https://www.dnd5eapi.co/api/monsters"));

            containerRegistry.Register<MainWindowViewModel>();
            containerRegistry.Register<MonsterSelectionViewModel>();
            containerRegistry.Register<MonsterDetailsViewModel>();

            containerRegistry.RegisterDialog<MessageDialog, MessageDialogModel>();

            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.SelectionRegion, typeof(MonsterSelectionView));
            regionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, typeof(MonsterDetailsView));
        }
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}