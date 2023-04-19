namespace csharp_simple_webapi.Main.Models
{
    public static class ProductSeed
    {
        public static void InitializeData(ProductContext context)
        {
            var rnd = new Random();

            var sizes = new[] { "Tiny", "Extra Small","Large", "Small", "Extra Large"};
            var colors = new[] { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
            var names = new[] { "Trousers", "Jeans", "T Shirt", "Stool", "Shoes" };
            var departments = new[] { "Outdoors", "Sports", "Clubbing","Formal", "Gardening" };

            context.Products.AddRange(900.Times(x =>
            {
                var adjective = sizes[rnd.Next(0, 5)];
                var material = colors[rnd.Next(0, 6)];
                var name = names[rnd.Next(0, 5)];
                var department = departments[rnd.Next(0, 5)];
                var productId = $"{x,-3:000}";

                return new Product
                {
                    ProductNumber = $"{department.First()}{name.First()}{productId}",
                    Name = $"{adjective} {material} {name}",
                    Price = (double)rnd.Next(0, 10000) / 100,
                    Department = department
                };
            }));

            context.SaveChanges();
        }
    }
}
