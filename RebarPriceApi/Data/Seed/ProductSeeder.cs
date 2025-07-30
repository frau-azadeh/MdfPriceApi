using System.Globalization;
using RebarPriceApi.Models;

namespace RebarPriceApi.Data.Seed
{
    public static class ProductSeeder
    {
        public static void SeedProducts(RebarDbContext context)
        {
            if (context.Products.Any()) return; 

            var csvPath = Path.Combine(Directory.GetCurrentDirectory(), "productTypes.csv");
            if (!File.Exists(csvPath))
                throw new FileNotFoundException("فایل CSV پیدا نشد", csvPath);

            var lines = File.ReadAllLines(csvPath);

            foreach (var line in lines.Skip(1)) 
            {
                var values = line.Split(',');

                if (values.Length < 3) continue;

                var product = new Product
                {
                    Name = values[1],
                    Type = values[2],
                    Size = values[3],
                    Form = values[4],
                    Standard = values[5],
                    Warehouse = values[6],
                    Unit = values[7],
                    Price = !string.IsNullOrWhiteSpace(values[8])
         ? decimal.Parse(values[8].Replace(",", ""), CultureInfo.InvariantCulture)
         : 0,
                    LastPriceDate = !string.IsNullOrWhiteSpace(values[9])
         ? DateTime.Parse(values[9], CultureInfo.InvariantCulture)
         : DateTime.MinValue
                };



                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}

