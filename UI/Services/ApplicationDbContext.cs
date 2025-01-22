using Microsoft.EntityFrameworkCore;
using UI.Models.KYC;

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

        //

        public DbSet<AnnualIncomeRange> AnnualIncomeRanges { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Declaration> Declarations { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<EducationLevel> EducationLevels { get; set; }

        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }

        public DbSet<InvestorTypeSetup> InvestorTypeSetups { get; set; }

        public DbSet<NetWorthRange> NetWorthRanges { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<RiskAgreement> RiskAgreements { get; set; }

        public DbSet<SocialStatus> SocialStatuses { get; set; }

        public DbSet<SourceOfIncome> SourceOfIncomes { get; set; }
        public DbSet<SourceOfWealth> SourceOfWealths { get; set; }
        //



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
    