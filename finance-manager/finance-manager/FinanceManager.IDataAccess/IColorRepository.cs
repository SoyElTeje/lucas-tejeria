using finance_manager;

namespace IDataAccess;

public interface IColorRepository
{
    Color? GetById(string colorId);
    Color? GetByHexCode(string hexCode);
    List<Color> GetAll();
    bool Add(Color color);
    bool Update(Color color);
    bool Delete(Color color);
}
