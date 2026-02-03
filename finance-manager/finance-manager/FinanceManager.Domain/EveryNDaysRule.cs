using Microsoft.VisualBasic.CompilerServices;

namespace finance_manager;

public class EveryNDaysRule : RecurrenceRule
{
    public int NumberOfDays { get; set; }

    public EveryNDaysRule(int numberOfDays)
    {
        if (numberOfDays <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfDays), "NumberOfDays must be greater than 0.");
        }

        NumberOfDays = numberOfDays;
    }

    public int GetOcurrencesBetween(DateTime start, DateTime end)
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