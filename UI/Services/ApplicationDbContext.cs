using Microsoft.EntityFrameworkCore;
using UI.Models;

namespace UI.Services
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<StrategyCode> StrategyCodes { get; set; }
        public DbSet<KnowledgeCode> KnowledgeCodes { get; set; }
        public DbSet<RiskToleranceCode> RiskToleranceCodes { get; set; }
        public DbSet<InvestmentObjectiveCode> InvestmentObjectiveCodes { get; set; }
        public DbSet<PurposeOfInvestmentCode> PurposeOfInvestmentCodes { get; set; }
        public DbSet<ExpectedTransactionPerMonthRange> ExpectedTransactionPerMonthRanges { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StrategyCode>().ToTable("KYC_StrategyCode").HasKey(x => x.Id);
            builder.Entity<StrategyCode>().Property(x=>x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<StrategyCode>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);

            builder.Entity<KnowledgeCode>().ToTable("KYC_KnowledgeCode").HasKey(x => x.Id);
            builder.Entity<KnowledgeCode>().Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<KnowledgeCode>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);

            builder.Entity<RiskToleranceCode>().ToTable("KYC_RiskToleranceCode").HasKey(x => x.Id);
            builder.Entity<RiskToleranceCode>().Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<RiskToleranceCode>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);

            builder.Entity<InvestmentObjectiveCode>().ToTable("KYC_InvestmentObjectiveCode").HasKey(x => x.Id);
            builder.Entity<InvestmentObjectiveCode>().Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<InvestmentObjectiveCode>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);

            builder.Entity<PurposeOfInvestmentCode>().ToTable("KYC_PurposeOfInvestmentCode").HasKey(x => x.Id);
            builder.Entity<PurposeOfInvestmentCode>().Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<PurposeOfInvestmentCode>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);

            builder.Entity<ExpectedTransactionPerMonthRange>().ToTable("KYC_ExpectedTransactionPerMonthRange").HasKey(x => x.Id);
            builder.Entity<ExpectedTransactionPerMonthRange>().Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Entity<ExpectedTransactionPerMonthRange>().Property(x => x.ArabicDescription).IsRequired().HasMaxLength(200);


        }
    }
}
    