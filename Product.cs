namespace ExampleSmakoteria
{
    public class Product
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }

        public Product()
        {

        }

        public Product(string imagePath, string name, int price, string description)
        {
            ImagePath = imagePath;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
