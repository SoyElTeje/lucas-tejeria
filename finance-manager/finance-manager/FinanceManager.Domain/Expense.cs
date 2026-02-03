namespace finance_manager;

public class Expense
{
    public Expense(string name, decimal amount, ExpenseTag tag)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Expense name is required.", nameof(name));

        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));

        Id = Guid.NewGuid().ToString();
        Name = name;
        Amount = amount;
        Tag = tag;
    }
    
    private Expense() { }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public decimal Amount { get; private set; }
    public ExpenseTag Tag { get; private set; }

    public void ChangeTag(ExpenseTag newTag)
    {
        Tag = newTag;
    }

    public void UpdateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
            throw new ArgumentException("Amount must be greater than zero.");

        Amount = newAmount;
    }
}