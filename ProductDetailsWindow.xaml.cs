using System.Windows;

namespace ExampleSmakoteria
{
    /// <summary>
    /// Логика взаимодействия для ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        private MainWindow mainWindow;
        private Product product;

        public ProductDetailsWindow(MainWindow mainWindow, Product product)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.product = product;
            DataContext = product;

            AddToBasketButton.Click -= AddToBasketButton_Click;
            AddToBasketButton.Click += AddToBasketButton_Click;
        }

        private void AddToBasketButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.AddToBasket(product); // Додаємо продукт у кошик головного вікна
            Close(); // Закриваємо поточне вікно
        }
    }
}
