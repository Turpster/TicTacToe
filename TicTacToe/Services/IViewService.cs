using Autofac;
using GalaSoft.MvvmLight;
using System;

namespace TickTackToe.Services
{
    public interface IViewService
    {
        void RegisterWindow(Type vm, Type window);

        void OpenWindow<T>(params NamedParameter[] parameters) where T : ViewModelBase;

        void OpenDialog<T>(params NamedParameter[] parameters) where T : ViewModelBase;
    }
}
