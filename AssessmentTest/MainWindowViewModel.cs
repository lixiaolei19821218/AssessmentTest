using Liquid.AssessmentLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AssessmentTest
{
    /// <summary>
    /// MainWindow ViewModel
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private DataSource dataSource;
        private DataSource.DataCallback callback;
        public FrameworkElement DispatchProvider { get; set; }

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

        private Status status;
        public Status Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public DelegateCommand SwitchCommand { get; set; }

        public MainWindowViewModel()
        {
            dataSource = new DataSource();
            callback = new DataSource.DataCallback(Callback);            

            SwitchCommand = new DelegateCommand(Switch);
        }

        public MainWindowViewModel(FrameworkElement dispatchProvider)
            : this()
        {
            DispatchProvider = dispatchProvider;
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

        private void Switch(object obj)
        {
            if (Status == Status.Paused)
            {
                dataSource.SubscribeWithWPFSynchronization(callback, DispatchProvider);
                Status = Status.Running;
            }
            else
            {
                dataSource.Unsubscribe(Callback);
                Status = Status.Paused;
            }
        }

        private void Run(object obj)
        {
            dataSource.SubscribeWithWPFSynchronization(callback, DispatchProvider);
        }

        private void Pause(object obj)
        {
            dataSource.Unsubscribe(Callback);
        }

        /// <summary>
        /// Call DataSource.Dispose() to shut down the data source.
        /// </summary>
        public void ShutDown()
        {
            dataSource.Dispose();
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
