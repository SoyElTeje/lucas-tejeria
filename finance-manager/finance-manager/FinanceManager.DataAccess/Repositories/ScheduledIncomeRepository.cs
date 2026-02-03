using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class ScheduledIncomeRepository(SqlContext context) : IScheduledIncomeRepository
{
    private readonly SqlContext _context = context;

    public ScheduledIncome? GetById(string scheduledIncomeId)
    {
        return _context.ScheduledIncomes
            .Include(s => s.RecurrenceRule)
            .FirstOrDefault(s => s.Id == scheduledIncomeId);
    }

    public List<ScheduledIncome> GetAll()
    {
        return _context.ScheduledIncomes
            .Include(s => s.RecurrenceRule)
            .ToList();
    }

    public bool Add(ScheduledIncome scheduledIncome)
    {
        _context.ScheduledIncomes.Add(scheduledIncome);
        return true;
    }

    public bool Update(ScheduledIncome scheduledIncome)
    {
        _context.ScheduledIncomes.Update(scheduledIncome);
        return true;
    }

    public bool Delete(ScheduledIncome scheduledIncome)
    {
        _context.ScheduledIncomes.Remove(scheduledIncome);
        return true;
    }
}
