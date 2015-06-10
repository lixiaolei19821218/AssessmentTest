using Liquid.AssessmentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AssessmentTest
{
    /// <summary>
    /// MainWindow ViewModel
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private DataSource dataSource;
        private DataSource.DataCallback callback;
        private FinancialData data;
        public FinancialData Data 
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }

        //To store 'Pricing Spec' ComboBox selection status.  
        private int lastSelectedPricingSpecIndex;
        private int currentPricingSpecIndex;
        public int CurrentPricingSpecIndex 
        {
            get
            {
                return currentPricingSpecIndex;
            }
            set
            {
                currentPricingSpecIndex = value;
                OnPropertyChanged("CurrentPricingSpecIndex");
                //Store ComboBox selection status if DataContext unchanged. 
                if (value != -1)
                {
                    lastSelectedPricingSpecIndex = value;
                }
                
            }
        }

        public DelegateCommand PauseCommand { get; set; }

        public MainWindowViewModel()
        {
            dataSource = new DataSource();
            callback = new DataSource.DataCallback(Callback);

            PauseCommand = new DelegateCommand(Pause);
        }

        /// <summary>
        /// To Subscribe With WPF Container Synchronization
        /// </summary>
        /// <param name="dispatchProvider">WPF Container</param>
        public void SubscribeWithWPFSynchronization(System.Windows.FrameworkElement dispatchProvider)
        {            
            dataSource.SubscribeWithWPFSynchronization(callback, dispatchProvider);
        }

        private void Callback(FinancialData data)
        {            
            Data = data;
            //DataContext changed, restore ComboBox selection status.
            CurrentPricingSpecIndex = lastSelectedPricingSpecIndex;
        }

        private void Pause(object obj)
        {
            dataSource.Unsubscribe(Callback);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }
}
