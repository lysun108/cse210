using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public string Street { get => _street; set => _street = value; }
    public string City { get => _city; set => _city = value; }
    public string StateOrProvince { get => _stateOrProvince; set => _stateOrProvince = value; }
    public string Country { get => _country; set => _country = value; }

    public bool IsInUSA()
    {
        return string.Equals(_country?.Trim(), "USA", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_country?.Trim(), "United States", StringComparison.OrdinalIgnoreCase) ||
               string.Equals(_country?.Trim(), "United States of America", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFormatted()
    {
        // Multiline for shipping label
        return $"{_street}\n{_city}, { _stateOrProvince }\n{_country}";
    }
}
