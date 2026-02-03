using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Repositories;

public class RecurrenceRuleRepository(SqlContext context) : IRecurrenceRuleRepository
{
    private readonly SqlContext _context = context;

    public RecurrenceRuleBase? GetById(string ruleId)
    {
        return _context.RecurrenceRules
            .Include(r => r.Creator)
            .FirstOrDefault(r => r.Id == ruleId);
    }

    public List<RecurrenceRuleBase> GetByCreatorId(string userId)
    {
        return _context.RecurrenceRules
            .Where(r => EF.Property<string>(r, "CreatorId") == userId)
            .Include(r => r.Creator)
            .ToList();
    }

    public bool Add(RecurrenceRuleBase rule)
    {
        _context.RecurrenceRules.Add(rule);
        return true;
    }

    public bool Update(RecurrenceRuleBase rule)
    {
        _context.RecurrenceRules.Update(rule);
        return true;
    }

    public bool Delete(RecurrenceRuleBase rule)
    {
        _context.RecurrenceRules.Remove(rule);
        return true;
    }
}
