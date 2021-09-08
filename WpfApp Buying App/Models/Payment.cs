using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_Buying_App.Abstract_Classes;

namespace WpfApp_Buying_App.Models
{
    public class Payment : IDGiver
    {
        public Drink Drink { get; set; }
        public int AmountOfDrink { get; set; }
        public int TotalCost { get; set; }
    }
}
