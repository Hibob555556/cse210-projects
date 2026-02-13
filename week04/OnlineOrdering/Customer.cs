namespace OnlineOrdering
{
    public class Customer(string name, Address address)
    {
        private readonly string _custName = name;
        private readonly Address _custAddress = address;

        public string GetName() => _custName;
        public Address GetAddress() => _custAddress;

        public bool LivesInUSA()
        {
            return _custAddress.IsInUSA();
        }
    }
}