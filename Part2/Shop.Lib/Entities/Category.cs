namespace Shop.Lib.Entities
{
    public class Category
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}