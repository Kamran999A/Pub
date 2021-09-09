using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp_Buying_App.Models;

namespace WpfApp_Buying_App.Repo
{
    public class DrinksRepository
    {
        public ObservableCollection<Drink> GetAllDrinks()
        {
            return new ObservableCollection<Drink>
            {
                new Drink
                {
                    Name = "BLACK LABEL VİSKİ ",
                    Volume = 14.5,
                    About = "The perfect  drink!",
                    Price = 35,
                    ImagePath = "/DrinksImages/BLACK LABEL VİSKİ 1.jpg"
                },

                new Drink
                {
                    Name = "CAPTAIN MORGAN JAMAICA ROM 1 LT",
                    Volume = 46.5,
                    About = @"For strong Capitans.",
                    Price = 80,
                    ImagePath = "/DrinksImages/CAPTAIN MORGAN JAMAICA ROM 1 LT.jpg"
                },

                new Drink
                {
                    Name = "CAPTAIN MORGAN SPICED GOLD ROM 1 LT",
                    Volume = 35,
                    About = "You'll be instantly transported to the tropics.",
                    Price = 28,
                    ImagePath = "/DrinksImages/CAPTAIN MORGAN SPICED GOLD ROM 1 LT.jpg"
                },


                new Drink
                {
                    Name = "TULLAMORE DEW VİSKİ 0.7 LT",
                    Volume = 23.5,
                    About = "Every night in fight.",
                    Price = 30,
                    ImagePath = "/DrinksImages/TULLAMORE DEW VİSKİ LT.jpg"
                },

                new Drink
                {
                    Name = "JACK DANIEL'S TENNESSEE VİSKİ 0.7 LT",
                    Volume = 14.5,
                    About = "SUCH a beautiful drink!",
                    Price = 25,
                    ImagePath = "/DrinksImages/JACK DANIEL'S TENNESSEE VİSKİ LT.jpg"
                },

                new Drink
                {
                    Name = "JOHNNIE WALKER RED LABEL VİSKİ 1 LT",
                    Volume = 36.5,
                    About = "It's time to Rest.",
                    Price = 200,
                    ImagePath = "/DrinksImages/JOHNNIE WALKER RED LABEL VİSKİ 1 LT.jpg"
                }

            };
        }
    }
}