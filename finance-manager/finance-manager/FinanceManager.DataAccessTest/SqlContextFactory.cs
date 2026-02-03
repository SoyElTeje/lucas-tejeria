using FinanceManager.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

public class SqlContextFactory
{
    public SqlContext CreateMemoryContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();

        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());

        return new SqlContext(optionsBuilder.Options);
    }
}