using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WpfApp_Buying_App.Command;
using WpfApp_Buying_App.Models;
using WpfApp_Buying_App.Repo;
using WpfApp_Buying_App.Views;

namespace WpfApp_Buying_App.ViewModels
{
    public class StartViewModel : Screen , INotifyPropertyChanged
    {
        private Drink _selected;

        public Drink Selected
        {
            get { return _selected; }
            set {
                NotifyOfPropertyChange(() => Selected);
                _selected = value; 
                }
        }
        public BindableCollection<DrinksRepository>  Drinkss { get; set; }

        private Drink _Drink;
        public event PropertyChangedEventHandler PropertyChanged;
        private int _currentIndex;
        private int _amountOfDrink;
        private string _page;
        private int _fullPrice;
        private string _previousButtonVisibilityState;
        private string _nextButtonVisibilityState;


        public StartViewModel()
        {
         //   DataAccess data = new DataAccess();


            Drinks = DrinksRepository.GetAllDrinks();
            Drink = Drinks[_currentIndex];

            AmountOfDrink = _currentIndex + 1;
            Page = $"{_currentIndex + 1} of {Drinks.Count}";
            FullPrice = Drink.Price;

            PreviousButtonVisibilityState = Visibility.Collapsed.ToString();
            NextButtonVisibilityState = Visibility.Visible.ToString();


            ClickedCommand = new RelayCommand(GoWhere, (p) => _currentIndex  >= 0);
            PreviousCommand = new RelayCommand(GoPrevious, (p) => _currentIndex - 1 >= 0);
            NextCommand = new RelayCommand(GoNext, (p) => _currentIndex + 1 >= 0 && _currentIndex + 1 < Drinks.Count);

            DownCommand = new RelayCommand(GoDown, (p) => _amountOfDrink - 1 >= 1);
            UpCommand = new RelayCommand(GoUp);

            BuyCommand = new RelayCommand(Buy);
            ResetCommand = new RelayCommand(Reset);
            ShowHistoryCommand = new RelayCommand(ShowHistory);
        }


        #region ActionsExecute
        public void GoWhere(object data = null)
        {
            for (int i = 0; i < Drinks.Count; i++)
            {
                if (Drink.Name == Drinks[i].Name)
                {
                    _currentIndex = i; 
                 ProcessDataWhenProductChanges();
                
                }

            }


            NextButtonVisibilityState = Visibility.Visible.ToString();

            if (_currentIndex - 1 == -1)
            {
                PreviousButtonVisibilityState = Visibility.Collapsed.ToString();
            }
        }
        public void GoPrevious(object data = null)
        {
            --_currentIndex;
            ProcessDataWhenProductChanges();

            NextButtonVisibilityState = Visibility.Visible.ToString();

            if (_currentIndex - 1 == -1)
            {
                PreviousButtonVisibilityState = Visibility.Collapsed.ToString();
            }
        }
        public void GoNext(object data = null)
        {
            ++_currentIndex;
            ProcessDataWhenProductChanges();

            PreviousButtonVisibilityState = Visibility.Visible.ToString();

            if (_currentIndex + 1 == Drinks.Count)
            {
                NextButtonVisibilityState = Visibility.Collapsed.ToString();
            }
        }
        public void GoDown(object data = null)
        {
            --AmountOfDrink;
            FullPrice = Drink.Price * AmountOfDrink;
        }
        public void GoUp(object data = null)
        {
            ++AmountOfDrink;
            FullPrice = Drink.Price * AmountOfDrink;
        }

        public void Buy(object data = null)
        {
            Payment payment = new Payment { Drink = this.Drink, AmountOfDrink = this.AmountOfDrink, TotalCost = FullPrice };
            Payments.Add(payment);

            BuyWindow window = new BuyWindow();

            BuyViewModel buyViewModel = new BuyViewModel
            {
                Payment = payment,
                DetailsOfPayment = $"Drink Name : {payment.Drink.Name}, Amount : {payment.AmountOfDrink},  Total Cost : {payment.TotalCost} $"
            };

            window.DataContext = buyViewModel;
            window.ShowDialog();
        }

        public void Reset(object data = null)
        {            
            _currentIndex = 0;
            Drink = Drinks[_currentIndex];

            Page = $"{_currentIndex + 1} of {Drinks.Count}";

            AmountOfDrink = 1;
            FullPrice = Drink.Price * AmountOfDrink;
        }

        public void ShowHistory(object data = null)
        {
            ShowHistoryWindow window = new ShowHistoryWindow();

            ShowHistoryViewModel showHistoryViewModel = new ShowHistoryViewModel
            {
                Payments = this.Payments
            };

            window.DataContext = showHistoryViewModel;

            window.ShowDialog();
        }

        public void ProcessDataWhenProductChanges()
        {
            Drink = Drinks[_currentIndex];
            Page = $"{_currentIndex + 1} of {Drinks.Count}";
            FullPrice = Drink.Price * AmountOfDrink;
        }

        #endregion


        public List<Payment> Payments { get; set; } = new List<Payment>();
        public DrinksRepository DrinksRepository { get; set; } = new DrinksRepository();
        public ObservableCollection<Drink> Drinks { get; set; }


        public Drink Drink
        {
            get { return _Drink; }
            set { _Drink = value; OnPropertyChanged(); }
        }

        public string Page
        {
            get { return _page; }
            set { _page = value; OnPropertyChanged(); }
        }
        public int AmountOfDrink
        {
            get { return _amountOfDrink; }
            set { _amountOfDrink = value; OnPropertyChanged(); }
        }

        public int FullPrice
        {
            get { return _fullPrice; }
            set { _fullPrice = value; OnPropertyChanged(); }
        }

        public string PreviousButtonVisibilityState
        {
            get { return _previousButtonVisibilityState; }
            set { _previousButtonVisibilityState = value; OnPropertyChanged(); }
        }

        public string NextButtonVisibilityState
        {
            get { return _nextButtonVisibilityState; }
            set { _nextButtonVisibilityState = value; OnPropertyChanged(); }
        }

        #region Commands

        public RelayCommand ClickedCommand { get; set; }
        public RelayCommand PreviousCommand { get; set; }
        public RelayCommand NextCommand { get; set; }        

        public RelayCommand DownCommand { get; set; }
        public RelayCommand UpCommand { get; set; }

        public RelayCommand BuyCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand ShowHistoryCommand { get; set; }

        #endregion
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}