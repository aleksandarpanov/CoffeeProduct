namespace CoffeeProduct.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Image { get; set; }

        public string SubTitle { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public decimal Price { get; set; }
    }
}
