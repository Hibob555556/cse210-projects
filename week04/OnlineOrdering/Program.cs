using System;

namespace OnlineOrdering
{
    class Program
    {
        static void Main()
        {
            Address custOneAddr = new Address(
                "123 Maple Street",
                "Logan",
                "UT",
                "USA"
            );

            Customer customerOne = new("Cayden Lunt", custOneAddr);

            Order orderOne = new(customerOne);
            orderOne.AddProduct(new Product("Water Bottle", "WB-1001", 12.99m, 2));
            orderOne.AddProduct(new Product("Trail Mix", "TM-2040", 4.50m, 3));

            DisplayOrder(orderOne);

            Address custTwoAddr = new Address(
                "55 Rue de Rivoli",
                "Paris",
                "Île-de-France",
                "France"
            );

            Customer customerTwo = new("Ada Lovelace", custTwoAddr);

            Order orderTwo = new(customerTwo);
            orderTwo.AddProduct(new Product("Notebook", "NB-3300", 6.25m, 4));
            orderTwo.AddProduct(new Product("Pen Set", "PS-7788", 9.99m, 1));
            orderTwo.AddProduct(new Product("Sticker Pack", "SP-1111", 2.00m, 5));

            DisplayOrder(orderTwo);
        }

        static void DisplayOrder(Order order)
        {
            Console.WriteLine("-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order.GetTotalCost():0.00}");
            Console.WriteLine("-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-~-\n");
        }
    }
}