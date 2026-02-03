using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceManager.DataAccess.Context;

public class DesignTimeSqlContextFactory: IDesignTimeDbContextFactory<SqlContext>
{
    public SqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=FinanceManager;User Id=sa;Password=Passw1rd;TrustServerCertificate=true;");
        return new SqlContext(optionsBuilder.Options);
    }
}