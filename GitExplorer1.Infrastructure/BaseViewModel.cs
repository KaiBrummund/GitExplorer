using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitExplorer1.Infrastructure
{
    abstract public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isDownloading = false;

        public bool IsDownloading
        {
            get { return _isDownloading; }
            set
            {
                if(value != _isDownloading)
                {
                    _isDownloading = value;
                    RaisePropertyChanged(nameof(IsDownloading));
                }
            }
        }



        //  INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
