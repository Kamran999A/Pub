using WpfApp_Buying_App.Abstract_Classes;

namespace WpfApp_Buying_App.Models
{
    public class Drink : IDGiver
    {
        //
        public string Name { get; set; }
        public double Volume { get; set; }
        public string About { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
    }
}