namespace finance_manager;

public class ScheduledIncome
{
    public string Id { get; private set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public RecurrenceRuleBase RecurrenceRule { get; set; }

    private ScheduledIncome() { }

    public ScheduledIncome(DateTime startDate, DateTime endDate, RecurrenceRule recurrenceRule)
    {
        Id = Guid.NewGuid().ToString();
        StartDate = startDate;
        EndDate = endDate;
        RecurrenceRule = (RecurrenceRuleBase)recurrenceRule;
    }
}