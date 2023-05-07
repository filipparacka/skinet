using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastracture.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext storeContext)
        {
            if (!storeContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastracture/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                storeContext.ProductBrands.AddRange(brands);
            }

            if (!storeContext.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastracture/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                storeContext.ProductTypes.AddRange(types);
            }

            if (!storeContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastracture/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                storeContext.Products.AddRange(products);
            }

            if (storeContext.ChangeTracker.HasChanges())
            {
                await storeContext.SaveChangesAsync();
            }
        }
    }
}
