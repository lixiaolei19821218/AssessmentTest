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

            MainWindowViewModel vm = new MainWindowViewModel();
            vm.SubscribeWithWPFSynchronization(this);
            DataContext = vm;
        }      
    }
}
