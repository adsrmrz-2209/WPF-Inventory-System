using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp1_MVVM_YT.MVVM.View;
using WpfApp1_MVVM_YT.MVVM.ViewModel;

namespace WpfApp1_MVVM_YT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainWindowViewModel mvm = null;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel mvm = new MainWindowViewModel();
            DataContext = mvm;
        }

        private void editQuantity_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void editQuantity_PreviewExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
