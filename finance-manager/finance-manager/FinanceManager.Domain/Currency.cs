namespace finance_manager;

public class Currency
{
    public Currency()
    {
    }

    public Currency(string code, string fullName, string symbol)
    {
        Id = Guid.NewGuid().ToString();
        Code = code;
        FullName = fullName;
        Symbol = symbol;
    }

    public string Id { get; set; }
    public string Code { get; set; }
    public string FullName { get; set; }
    public string Symbol { get; set; }
}
