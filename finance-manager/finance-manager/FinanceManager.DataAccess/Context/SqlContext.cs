using finance_manager;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.DataAccess.Context;

public class SqlContext : DbContext
{
    public SqlContext()
    {
    }

    public SqlContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Color> Colors { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<ExpenseTag> ExpenseTags { get; set; }
    public virtual DbSet<Income> Incomes { get; set; }
    public virtual DbSet<Purchase> Purchases { get; set; }
    public virtual DbSet<RecurrenceRuleBase> RecurrenceRules { get; set; }
    public virtual DbSet<ScheduledIncome> ScheduledIncomes { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ----- 1. User -----
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Surname).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Password).HasMaxLength(256);
        });

        // ----- 2. Color -----
        modelBuilder.Entity<Color>(entity =>
        {
            entity.ToTable("Colors");
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.HexCode).IsUnique();

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.HexCode).HasMaxLength(7);
        });

        // ----- 3. Currency -----
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currencies");
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Code).IsUnique();

            entity.Property(e => e.Code).HasMaxLength(3);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Symbol).HasMaxLength(10);
        });

        // ----- 4. Account (FK User vía shadow, FK Currency) -----
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Balance).HasPrecision(18, 2);

            entity.HasOne<User>()
                .WithMany(u => u.Accounts)
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 5. ExpenseTag (FK User, FK Color) -----
        modelBuilder.Entity<ExpenseTag>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IconUrl).HasMaxLength(500);

            entity.HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey("CreatorId")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Color)
                .WithMany()
                .HasForeignKey(e => e.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 6. Purchase (FK Account vía shadow) -----
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne<Account>()
                .WithMany(a => a.Purchases)
                .HasForeignKey("AccountId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 7. Expense (FK ExpenseTag y Purchase vía shadow) -----
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Amount).HasPrecision(18, 2);

            entity.HasOne(e => e.Tag)
                .WithMany()
                .HasForeignKey("TagId")
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<Purchase>()
                .WithMany(p => p.Expenses)
                .HasForeignKey("PurchaseId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 8. RecurrenceRuleBase (TPH) y EveryNDaysRule -----
        modelBuilder.Entity<RecurrenceRuleBase>(entity =>
        {
            entity.ToTable("RecurrenceRules");
            entity.HasKey(e => e.Id);

            entity.HasDiscriminator<string>("RuleType")
                .HasValue<EveryNDaysRule>("EveryNDays");

            entity.Property("RuleName").HasMaxLength(200);

            entity.HasOne(e => e.Creator)
                .WithMany()
                .HasForeignKey("CreatorId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 9. ScheduledIncome (FK RecurrenceRuleBase vía shadow) -----
        modelBuilder.Entity<ScheduledIncome>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.RecurrenceRule)
                .WithMany()
                .HasForeignKey("RecurrenceRuleId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 10. Income (FK Currency, FK ScheduledIncome opcional vía shadow) -----
        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ScheduledIncome)
                .WithMany()
                .HasForeignKey("ScheduledIncomeId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}