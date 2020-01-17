namespace Shop.Lib.Entities
{
    public class Product
    {
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, Category category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Price}\t\t{Category}\t{Name}";
        }
    }
}
