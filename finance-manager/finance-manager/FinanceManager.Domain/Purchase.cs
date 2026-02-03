namespace finance_manager;

public class Purchase
{
    private Purchase() { }
    
    public string Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Notes { get; set; }
    public List<Expense> Expenses { get; private set; }

    public Purchase(DateTime date, string notes)
    {
        Id = Guid.NewGuid().ToString();
        Date = date;
        Notes = notes;
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
    }

    public void RemoveExpense(Expense expense)
    {
        Expenses.Remove(expense);
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (Expense expense in Expenses)
        {
            total += expense.Amount;
        }
        return total;
    }
}