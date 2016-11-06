using Autofac;
using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;
using System.Linq;
using System.Reflection;
using TickTackToe.Services;
using TickTackToe.ViewModel;
using TickTackToe.Views;

namespace TickTackToe
{
    public static class Bootstrapper
    {
        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ViewService>().As<IViewService>().SingleInstance();
            builder.RegisterType<DialogCoordinator>().As<IDialogCoordinator>();
            builder.RegisterTypes(Assembly.GetExecutingAssembly().GetTypes().Where(z => z.BaseType == typeof(ViewModelBase) && z.Name != "GameViewModel").ToArray());
            builder.RegisterType<GameViewModel>().WithParameter(new NamedParameter("gameSize","size"));
            
            var container =  builder.Build();

            var viewService = container.Resolve<IViewService>();
            viewService.RegisterWindow(typeof(MainViewModel), typeof(MainWindow));
            viewService.RegisterWindow(typeof(GameViewModel), typeof(GameWindow));

            return container;
        }
    }
}
