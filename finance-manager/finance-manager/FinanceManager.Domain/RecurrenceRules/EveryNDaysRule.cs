namespace finance_manager;

public class EveryNDaysRule : RecurrenceRuleBase
{
    private EveryNDaysRule() { }

    public EveryNDaysRule(User creator, int numberOfDays, string ruleName)
    {
        if (numberOfDays <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfDays), "NumberOfDays must be greater than 0.");
        }

        Creator = creator;
        NumberOfDays = numberOfDays;
        RuleName = ruleName;
    }

    public int NumberOfDays { get; set; }

    public override int GetOcurrencesBetween(DateTime start, DateTime end)
    {
        DateTime startDate = start.Date;
        DateTime endDate = end.Date;

        if (endDate < startDate)
        {
            return 0;
        }

        int totalDays = (int)(endDate - startDate).TotalDays;
        int occurrences = (totalDays / NumberOfDays) + 1;

        return occurrences;
    }
}