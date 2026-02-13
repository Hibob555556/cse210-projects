using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order(Customer customer)
    {
        private readonly List<Product> _prods = [];
        private readonly Customer _customer = customer;

        public void AddProduct(Product product)
        {
            _prods.Add(product);
        }

        public decimal GetTotalCost()
        {
            decimal subtotal = 0m;

            foreach (Product product in _prods)
                subtotal += product.GetTotCost();

            decimal shipping = _customer.LivesInUSA() ? 5m : 35m;
            return subtotal + shipping;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new();
            sb.AppendLine("Packing Label");

            foreach (Product product in _prods)
                sb.AppendLine($"{product.GetProdName()} (ID: {product.GetProdID()})");

            return sb.ToString();
        }

        public string GetShippingLabel()
        {
            StringBuilder sb = new();
            sb.AppendLine("Shipping Label");
            sb.AppendLine(_customer.GetName());
            sb.AppendLine(_customer.GetAddress().GetFullAddress());
            return sb.ToString();
        }
    }
}