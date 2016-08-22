using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Linq;
using System.Collections.ObjectModel;
using TickTackToe.Model;
using TickTackToe.Views;
using TickTackToe.Services;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using GalaSoft.MvvmLight.Messaging;

namespace TickTackToe.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IViewService viewService;
        IDialogCoordinator coordinator;
        GameSizeDialog dialog;

        public MainViewModel(IViewService viewService, IDialogCoordinator coordinator)
        {
            this.viewService = viewService;
            this.coordinator = coordinator;
            dialog = new GameSizeDialog();
            dialog.DataContext = new GameSizeViewModel();
            Messenger.Default.Register<int>(this, SizeChecked);
        }

        private ICommand startGame;

        public ICommand StartGame
        {
            get
            {
                if(startGame == null)
                    startGame = new RelayCommand<Window>(StartGameMethod, (i) => { return true; });
                return startGame;
            }
        }

        private ICommand exitApp;

        public ICommand ExitApp
        {
            get
            {
                if (exitApp == null)
                    exitApp = new RelayCommand(() => { Environment.Exit(1); });
                return exitApp;

            }
        }

        private async void StartGameMethod(Window window)
        {        
            await coordinator.ShowMetroDialogAsync(this, dialog);
        }

        private async void SizeChecked(int obj)
        {
            await coordinator.HideMetroDialogAsync(this, dialog);
            viewService.OpenDialog<GameViewModel>(new Autofac.NamedParameter("gameSize", obj));
        }
    }
}