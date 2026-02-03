using finance_manager;
using FinanceManager.DataAccess.Context;
using IDataAccess;

namespace FinanceManager.DataAccess.Repositories;

public class ColorRepository(SqlContext context) : IColorRepository
{
    private readonly SqlContext _context = context;

    public Color? GetById(string colorId)
    {
        return _context.Colors.FirstOrDefault(c => c.Id == colorId);
    }

    public Color? GetByHexCode(string hexCode)
    {
        var normalized = hexCode.Trim().StartsWith("#") ? hexCode.Trim() : "#" + hexCode.Trim();
        return _context.Colors.FirstOrDefault(c => c.HexCode == normalized);
    }

    public List<Color> GetAll()
    {
        return _context.Colors.OrderBy(c => c.HexCode).ToList();
    }

    public bool Add(Color color)
    {
        _context.Colors.Add(color);
        return true;
    }

    public bool Update(Color color)
    {
        _context.Colors.Update(color);
        return true;
    }

    public bool Delete(Color color)
    {
        _context.Colors.Remove(color);
        return true;
    }
}
