using Shared;

namespace finance_manager;

public class Income
{
    public string Id { get; private set; }
    public decimal Amount { get; set; }
    public CurrencyType Currency { get; set; }
    public string Description { get; set; }
    public DateTime ReceivedAt { get; set; }
    public ScheduledIncome? ScheduledIncome { get; set; } = null;

    private Income()
    {
    }

    public Income(decimal amount, CurrencyType currency, DateTime receivedAt, string description)
    {
        this.Id = Guid.NewGuid().ToString();
        this.Amount = amount;
        this.Currency = currency;
        this.ReceivedAt = receivedAt;
        this.Description = description;
    }

    public Income(decimal amount, CurrencyType currency, DateTime receivedAt, string description, ScheduledIncome scheduledIncome) : this(amount, currency, receivedAt, description)
    {
        ScheduledIncome = scheduledIncome;
    }   
}