namespace WpfApp1_MVVM_YT.MVVM.Model
{
    public class Item
    {
        public Item() { }
        public Item(string name, string serialNumber, int quantity)
        {
            this.Name = name;
            this.SerialNumber = serialNumber;
            this.Quantity = quantity;
        }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int Quantity { get; set; }
    }
}
