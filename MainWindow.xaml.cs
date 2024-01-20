using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ExampleSmakoteria
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Product> Basket { get; set; }

        private string _totalPrice;
        public string TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            Basket = new ObservableCollection<Product>();
            Basket.CollectionChanged += Basket_CollectionChanged;
            sandwichesShow();

            // Встановлення DataContext
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Basket_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateTotalPrice();
            Console.WriteLine(TotalPrice);
        }

        private void UpdateTotalPrice()
        {
            double total = Basket.Sum(product => product.Price);
            TotalPrice = total.ToString();
            OnPropertyChanged(nameof(TotalPrice));
        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Console.WriteLine($"{propertyName} changed");
        }
        public void AddToBasket(Product product)
        {
            Basket.Add(product);
            UpdateTotalPrice();
        }

        public void sandwichesShow()
        {
            Products.Clear();

            for (int i = 0; i < 16; i++)
            {
                Products.Add(new Product($"/images/sandwiches/{i + 1}.png", "З яловичиною гриль", 139, "круасан, яловичина гриль, салат айсберг, помідор, маринована цибуля, соус сацебелі, соус класичний"));
            }

            DataContext = this;
        }

        public void sweetCroissantsShow()
        {
            Products.Clear();
            for (int i = 0; i < 5; i++)
            {
                Products.Add(new Product($"/images/sweet/{i + 1}.png", "З шоколадом та бананом", 85, "круасан, шоколад, банан, цукрова пудра"));
            }

            DataContext = this;
        }

        private void SweetCroissantsButton_Click(object sender, RoutedEventArgs e)
        {
            sweetCroissantsShow();
        }

        private void SandwichesButton_Click(object sender, RoutedEventArgs e)
        {
            sandwichesShow();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = ((FrameworkElement)sender).DataContext as Product;
            if (selectedProduct != null)
            {
                ProductDetailsWindow productDetailsWindow = new ProductDetailsWindow(this, selectedProduct);
                productDetailsWindow.Owner = this;
                productDetailsWindow.ShowDialog();
            }
        }
    }
}
