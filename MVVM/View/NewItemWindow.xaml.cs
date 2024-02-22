using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApp1_MVVM_YT.MVVM.Model;
using WpfApp1_MVVM_YT.MVVM.ViewModel;

namespace WpfApp1_MVVM_YT.MVVM.View
{
    /// <summary>
    /// Interaction logic for NewItemWindow.xaml
    /// </summary>

    public partial class NewItemWindow : Window
    {
        public NewItemWindow(ObservableCollection<Item> items)
        {
            InitializeComponent();
            NewItemWindowViewModel ViewModel = new NewItemWindowViewModel();
            ViewModel.Items = items;
            DataContext = ViewModel;
        }

        //restricts string and char input, only numeric(int) value is allowed
        private void quantityInput_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //restricts copy, paste and cut
        private void quantityInput_PreviewExecuted(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
