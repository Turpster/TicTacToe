using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TickTackToe.Services;
using TickTackToe.ViewModel;

namespace TickTackToe
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IContainer Container { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Container = Bootstrapper.Bootstrap();

            Container.Resolve<IViewService>().OpenWindow<MainViewModel>();
        }
    }
}
