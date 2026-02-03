namespace finance_manager;

public class Account
{
    public Account()
    {
    }

    public Account(string name, Currency currency, decimal inicialBalance)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        CurrencyId = currency.Id;
        Currency = currency;
        Balance = inicialBalance;
        CreatedDate = DateTime.Now;
    }

    public Account(string name, Currency currency, decimal inicialBalance, string description) : this(name, currency, inicialBalance)
    {
        Description = description;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public string CurrencyId { get; set; }
    public Currency Currency { get; private set; }

    public string Description { get; set; }
    public decimal Balance { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedDate { get; }

    public void Activate()
    {
        IsActive = true;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public List<Purchase> Purchases { get; } = new List<Purchase>();

    public void AddPurchase(Purchase purchase)
    {
        Purchases.Add(purchase);
    }

    public void RemovePurchase(Purchase purchase)
    {
        Purchases.Remove(purchase);
    }
}