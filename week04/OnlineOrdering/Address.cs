namespace OnlineOrdering
{
    public class Address(string strAddress, string city, string provinceOrState, string country)
    {
        private readonly string _strAddress = strAddress;
        private readonly string _city = city;
        private readonly string _provinceOrState = provinceOrState;
        private readonly string _country = country;

        public bool IsInUSA()
        {
            string norm = _country.Trim().ToUpperInvariant();
            bool inUSA = false;
            if (norm == "USA")
                inUSA = true;
            else if (norm == "US")
                inUSA = true;
            else if (norm == "UNITED STATES")
                inUSA = true;
            else if (norm == "UNITED STATES OF AMERICA")
                inUSA = true;
            return inUSA;
        }

        public string GetFullAddress()
        {
            return $"{_strAddress}\n{_city}, {_provinceOrState}\n{_country}";
        }
    }
}