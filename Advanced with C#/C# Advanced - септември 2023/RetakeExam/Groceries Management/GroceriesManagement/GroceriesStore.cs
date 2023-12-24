using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        private List<Product> stall;

        public int Capacity { get; private set; }
        public double Turnover { get; private set; }


        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (stall.Count < Capacity && !stall.Exists(p => p.Name == product.Name))
            {
                stall.Add(product);
            }
        }

        public bool RemoveProduct(string name)
        {
            Product productToRemove = stall.Find(p => p.Name == name);
            if (productToRemove != null)
            {
                stall.Remove(productToRemove);
                return true;
            }
            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            Product product = stall.Find(p => p.Name == name);
            if (product != null)
            {
                double totalPrice = product.Price * quantity;
                Turnover += totalPrice;
                return $"{product.Name} - {totalPrice:F2}$";
            }
            return "Product not found";
        }

        public string GetMostExpensive()
        {
            Product mostExpensiveProduct = stall.OrderByDescending(p => p.Price).FirstOrDefault();
            if (mostExpensiveProduct != null)
            {
                return mostExpensiveProduct.ToString();
            }
            return "No products available";
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:F2}$";
        }

        public string PriceList()
        {
            if (stall.Count == 0)
            {
                return "Stall is empty";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");
            sb.AppendLine(string.Join(Environment.NewLine, stall.Select(p => p.ToString())));

            return sb.ToString().Trim();
        }
    }
}
