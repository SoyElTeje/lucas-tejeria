namespace finance_manager;

public interface RecurrenceRule
{
    public string RuleName { get; set; }
    public int GetOcurrencesBetween(DateTime start, DateTime end);
    public User Creator { get; }
}