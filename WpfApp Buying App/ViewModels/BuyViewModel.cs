using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_Buying_App.Models;

namespace WpfApp_Buying_App.ViewModels
{
    public class BuyViewModel
    {
        public Payment Payment { get; set; }
        public string DetailsOfPayment { get; set; }

    }
}