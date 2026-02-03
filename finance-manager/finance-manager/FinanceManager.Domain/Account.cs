using Shared;

namespace finance_manager;

public class Account
{
    public Account()
    {
    }

    public Account(string name, CurrencyType currencyType, decimal inicialBalance)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        CurrencyType = currencyType;
        Balance = inicialBalance;
        CreatedDate = DateTime.Now;
    }

    public Account(string name, CurrencyType currencyType, decimal inicialBalance, string description) : this(name, currencyType, inicialBalance)
    {
        Description = description;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public CurrencyType CurrencyType { get; private set; }

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