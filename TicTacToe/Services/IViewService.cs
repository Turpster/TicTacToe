using Autofac;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TickTackToe.Services
{
    public interface IViewService
    {
        void RegisterWindow(Type vm, Type window);

        void OpenWindow<T>(params NamedParameter[] parameters) where T : ViewModelBase;

        void OpenDialog<T>(params NamedParameter[] parameters) where T : ViewModelBase;
    }
}
