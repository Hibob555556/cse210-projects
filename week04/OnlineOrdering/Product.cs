namespace OnlineOrdering
{
    public class Product(string prodName, string prodID, decimal pricePer, int quantity)
    {
        private readonly string _productName = prodName;
        private readonly string _productID = prodID;
        private readonly decimal _ppUnit = pricePer;
        private readonly int _quantity = quantity;

        public string GetProdName() { return _productName; }
        public string GetProdID() { return _productID; }
        public decimal GetTotCost() { return _quantity * _ppUnit; }
    }
}