namespace Shared;

public class CurrencyType
{
    public CurrencyType()
    {
    }

    public CurrencyType(string code, string fullName)
    {
        Code = code;
        FullName = fullName;
    }

    public string Code { get; set; }
    public string FullName { get; set; }
}