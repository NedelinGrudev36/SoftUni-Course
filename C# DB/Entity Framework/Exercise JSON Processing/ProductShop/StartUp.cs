using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //01
            string userText = File.ReadAllText("../../../Datasets/users.json");
            Console.WriteLine(ImportUsers(context, userText));

            //02
            string productsText = File.ReadAllText("../../../Datasets/products.json");
            Console.WriteLine(ImportUsers(context, productsText));

            //03
            string categoryText = File.ReadAllText("../../../Datasets/categories.json");
            Console.WriteLine(ImportUsers(context, categoryText));

            //04
            string categoryProducts = File.ReadAllText("../../../Datasets/categories-products.json");
            Console.WriteLine(ImportCategoryProducts(context, categoryProducts));

            //05
            Console.WriteLine(GetSoldProducts(context));

            //06

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
                context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);
            categories.RemoveAll(x => x.Name == null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ExportProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToList();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(productInRange, settings);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(x => new
                {
                    Name = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new
                    {
                        p.Name,
                        p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName

                    })
                })
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .ToList();

            return SerializeObjectWithJsonSettings(soldProducts);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new
                {
                    Category = x.Name,
                    ProductCount = x.CategoriesProducts.Count(),
                    AveragePrice = x.CategoriesProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    TotalRevenue = x.CategoriesProducts.Sum(x => x.Product.Price).ToString("f2")
                })
                .OrderByDescending(x => x.ProductCount)
                .ToList();

            return SerializeObjectWithJsonSettings(categories);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                    .Select(p => new
                    {
                        p.Name,
                        p.Price
                    })
                    .ToArray()
                })
                .OrderByDescending(u => u.SoldProducts.Length)
                .ToArray();

            return SerializeObjectWithJsonSettings(users);       
        }



        private static string SerializeObjectWithJsonSettings(string obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}