using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using WpfApp1_MVVM_YT.MVVM.Model;
using WpfApp1_MVVM_YT.MVVM.View;

namespace WpfApp1_MVVM_YT.MVVM.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public NewItemWindow newItemWindow = null;

        public ObservableCollection<Item> Items { get; set; }

        public RelayCommand NewItemCommand => new RelayCommand(execute => OpenAddWindow());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteItem(), canExecute => SelectedItem != null);
        public RelayCommand ClearCommand => new RelayCommand(execute => Clear(), canExecute => Items.Count != 0);

        public MainWindowViewModel() 
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("bread", "12412asd123", 2));
            Items.Add(new Item
            {
                Name = "Name",
                SerialNumber = "new serial number",
                Quantity = 4
            });
 
        }

        private Item selectedItem;

        public Item SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }


        public void OpenAddWindow()
        {
            newItemWindow = new NewItemWindow(Items);
            newItemWindow.ShowDialog();
        }


        public void DeleteItem()
        {
            Items.Remove(SelectedItem);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool CanSave()
        {
            return true;
        }
    }
}
