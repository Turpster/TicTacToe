using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TickTackToe.ViewModel
{
    public class GameSizeViewModel : ViewModelBase
    {
        public GameSizeViewModel()
        {
            this.Enabled = true;
        }
        private ICommand selectSize;
        public ICommand SelectSize
        {
            get
            {
                if (selectSize == null)
                    selectSize = new RelayCommand<string>(SelectSizeMethod);
                return selectSize;
            }
        }

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                RaisePropertyChanged();
            }
        }

        private void SelectSizeMethod(string size)
        {
            Messenger.Default.Send<int>(Convert.ToInt32(size));
        }
    }
}
