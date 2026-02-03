namespace finance_manager;

public abstract class RecurrenceRuleBase : RecurrenceRule
{
    protected RecurrenceRuleBase()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
    public string RuleName { get; set; }
    public User Creator { get; protected set; }

    public abstract int GetOcurrencesBetween(DateTime start, DateTime end);
}
