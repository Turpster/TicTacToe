using Autofac;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TickTackToe.Services
{
    public class ViewService : IViewService
    {
        private Dictionary<Type, Type> registrations;
        private IComponentContext container;
        
        public ViewService(IComponentContext container)
        {
            this.container = container;
            registrations = new Dictionary<Type, Type>();
        }

        public void RegisterWindow(Type vm, Type window)
        {
            if (registrations.ContainsKey(vm)) throw new ArgumentException("ViewModel already registered.");
            registrations.Add(vm, window);
        }

        private Window CreateView<T>(params NamedParameter[] parameters) where T : ViewModelBase
        {
            if (registrations.ContainsKey(typeof(T)))
            {
                var view = registrations[typeof(T)];
                var control = (Window)Activator.CreateInstance(view);
                control.DataContext = container.Resolve<T>(parameters);
                return control;
            }
            else throw new ArgumentException("ViewModel not registered.");
        }

        public void OpenWindow<T>(params NamedParameter[] parameters) where T : ViewModelBase
        {
            var window = CreateView<T>(parameters);
            window.Show();
        }

        public void OpenDialog<T>(params NamedParameter[] parameters) where T : ViewModelBase
        {
            var window = CreateView<T>(parameters);
            window.ShowDialog();
        }
    }
}
