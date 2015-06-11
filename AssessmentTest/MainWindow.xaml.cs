using System.Windows;

namespace AssessmentTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            

            MainWindowViewModel vm = new MainWindowViewModel(this);            
            DataContext = vm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (DataContext as MainWindowViewModel).ShutDown();
        }      
    }
}
