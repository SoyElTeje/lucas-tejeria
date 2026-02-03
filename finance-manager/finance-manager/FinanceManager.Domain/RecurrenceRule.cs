namespace finance_manager;

public interface RecurrenceRule
{
    public int GetOcurrencesBetween(DateTime start, DateTime end);
}