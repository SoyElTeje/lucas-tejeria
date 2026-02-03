namespace finance_manager;

public class ScheduledIncome
{
    public string Id {get; private set;}
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RecurrenceRule RecurrenceRule { get; set; }

    public ScheduledIncome(DateTime startDate, DateTime endDate, RecurrenceRule recurrenceRule)
    {
        this.Id = Guid.NewGuid().ToString();
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.RecurrenceRule = recurrenceRule;
    }
}