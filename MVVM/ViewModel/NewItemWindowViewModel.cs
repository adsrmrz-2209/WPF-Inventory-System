using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1_MVVM_YT.MVVM.Model;

namespace WpfApp1_MVVM_YT.MVVM.ViewModel
{
    public class NewItemWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Item> Items { get; set; }
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());
        public NewItemWindowViewModel() 
        {
            //constructor
        }

        private string newName;
        private string newSerialNumber;
        private int newQuantity;

        public string NewName
        {
            get { return newName; }
            set { newName = value; OnPropertyChanged(); }
        }

        public string NewSerialNumber
        {
            get { return newSerialNumber; }
            set { newSerialNumber = value; OnPropertyChanged(); }
        }

        public int NewQuantity
        {
            get { return newQuantity; }
            set 
            {
                int num;
                bool res = Int32.TryParse(value.ToString(), out num);
                if (res)
                {
                    newQuantity = num;
                }
                else
                {
                    MessageBox.Show("NUMERIC VALUES ONLY");
                }
                
                OnPropertyChanged(); 
            }
        }

        public void AddItem()
        {
            if(!string.IsNullOrEmpty(NewName) && !string.IsNullOrEmpty(NewSerialNumber))
            {
                Items.Add(new Item(NewName, NewSerialNumber, NewQuantity));
                NewName = string.Empty;
                NewSerialNumber = string.Empty;
                NewQuantity = 0;
            }
            else
            {
                MessageBox.Show("Name and Serial Number must not be empty!","Error!",MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            

            //Items.Add(new Item
            //{
            //    Name = "Name",
            //    SerialNumber = "asdasd",
            //    Quantity = 4
            //});
        }
    }
}
