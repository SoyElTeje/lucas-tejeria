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
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        // ----- 2. Account (FK User vía shadow) -----
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

            entity.OwnsOne(e => e.CurrencyType, c =>
            {
                c.Property(x => x.Code).HasMaxLength(3);
                c.Property(x => x.FullName).HasMaxLength(100);
            });
        });

        // ----- 3. ExpenseTag (FK User vía shadow) -----
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

            entity.OwnsOne(e => e.Color, c =>
            {
                c.Property(x => x.HexCode).HasMaxLength(7);
            });
        });

        // ----- 4. Purchase (FK Account vía shadow) -----
        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Notes).HasMaxLength(1000);

            entity.HasOne<Account>()
                .WithMany(a => a.Purchases)
                .HasForeignKey("AccountId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 5. Expense (FK ExpenseTag y Purchase vía shadow) -----
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

        // ----- 6. RecurrenceRuleBase (TPH) y EveryNDaysRule -----
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

        // ----- 7. ScheduledIncome (FK RecurrenceRuleBase vía shadow) -----
        modelBuilder.Entity<ScheduledIncome>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.RecurrenceRule)
                .WithMany()
                .HasForeignKey("RecurrenceRuleId")
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ----- 8. Income (FK ScheduledIncome opcional vía shadow) -----
        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(e => e.ScheduledIncome)
                .WithMany()
                .HasForeignKey("ScheduledIncomeId")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.OwnsOne(e => e.Currency, c =>
            {
                c.Property(x => x.Code).HasMaxLength(3);
                c.Property(x => x.FullName).HasMaxLength(100);
            });
        });
    }
}