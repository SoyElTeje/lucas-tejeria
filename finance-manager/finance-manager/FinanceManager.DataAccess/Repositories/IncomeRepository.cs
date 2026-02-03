using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class IncomeRepository(SqlContext context) : IIncomeRepository
{
    private readonly SqlContext _context = context;

    public Income? GetById(string incomeId)
    {
        return _context.Incomes
            .Include(i => i.ScheduledIncome)
            .FirstOrDefault(i => i.Id == incomeId);
    }

    public List<Income> GetAll()
    {
        return _context.Incomes
            .Include(i => i.ScheduledIncome)
            .OrderByDescending(i => i.ReceivedAt)
            .ToList();
    }

    public List<Income> GetByScheduledIncomeId(string scheduledIncomeId)
    {
        return _context.Incomes
            .Where(i => EF.Property<string?>(i, "ScheduledIncomeId") == scheduledIncomeId)
            .Include(i => i.ScheduledIncome)
            .OrderByDescending(i => i.ReceivedAt)
            .ToList();
    }

    public bool Add(Income income)
    {
        _context.Incomes.Add(income);
        return true;
    }

    public bool Update(Income income)
    {
        _context.Incomes.Update(income);
        return true;
    }

    public bool Delete(Income income)
    {
        _context.Incomes.Remove(income);
        return true;
    }
}
