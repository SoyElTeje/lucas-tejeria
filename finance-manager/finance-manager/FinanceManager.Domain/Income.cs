namespace finance_manager;

public class Income
{
    public string Id { get; private set; }
    public decimal Amount { get; set; }
    public string CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public string Description { get; set; }
    public DateTime ReceivedAt { get; set; }
    public ScheduledIncome? ScheduledIncome { get; set; } = null;

    private Income()
    {
    }

    public Income(decimal amount, Currency currency, DateTime receivedAt, string description)
    {
        Id = Guid.NewGuid().ToString();
        Amount = amount;
        CurrencyId = currency.Id;
        Currency = currency;
        ReceivedAt = receivedAt;
        Description = description;
    }

    public Income(decimal amount, Currency currency, DateTime receivedAt, string description, ScheduledIncome scheduledIncome) : this(amount, currency, receivedAt, description)
    {
        ScheduledIncome = scheduledIncome;
    }
}