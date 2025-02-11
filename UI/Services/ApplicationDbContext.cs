using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UI.Models;
using UI.Models.KYC;
using UI.Models.Users_KYC;

namespace UI.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<StrategyCode> StrategyCodes { get; set; }
        public DbSet<KnowledgeCode> KnowledgeCodes { get; set; }
        public DbSet<RiskToleranceCode> RiskToleranceCodes { get; set; }
        public DbSet<InvestmentObjectiveCode> InvestmentObjectiveCodes { get; set; }
        public DbSet<PurposeOfInvestmentCode> PurposeOfInvestmentCodes { get; set; }
        public DbSet<ExpectedTransactionPerMonthRange> ExpectedTransactionPerMonthRanges { get; set; }

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

        public DbSet<EmploymentDetails> EmploymentDetails { get; set; }

        public DbSet<FinancialInfo> FinancialInfos { get; set; }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<IndividualKYC> IndividualKYCs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            KYCConfigurations(builder);
            IndividualKYC(builder);

            builder.Entity<StrategyCode>().ToTable("KYC_StrategyCode").HasKey(x => x.Id);
            builder.Entity<StrategyCode>().Property(x => x.Description).IsRequired().HasMaxLength(200);
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

            builder.Entity<AnnualIncomeRange>().ToTable("KYC_AnnualIncomeRange").HasKey(i => i.Id);
            builder.Entity<AnnualIncomeRange>().Property(i => i.Range).HasMaxLength(50);
            builder.Entity<AnnualIncomeRange>().Property(i => i.ArabicRange).HasMaxLength(50);

            builder.Entity<Bank>().ToTable("KYC_Bank").HasKey(q => q.Id);
            builder.Entity<Bank>().Property(q => q.Name).HasMaxLength(200);

            builder.Entity<Country>().ToTable("KYC_Country").HasKey(x => x.Id);
            builder.Entity<Country>().Property(x => x.Name).HasMaxLength(50);
            builder.Entity<Country>().Property(x => x.ArabicName).HasMaxLength(50);
            builder.Entity<Country>().Property(x => x.Code).HasMaxLength(10);

            builder.Entity<Declaration>().ToTable("KYC_Declaration").HasKey(x => x.Id);
            builder.Entity<Declaration>().Property(x => x.Description).HasMaxLength(2000);
            builder.Entity<Declaration>().Property(x => x.ArabicDescription).HasMaxLength(2000);

            builder.Entity<DocumentType>().ToTable("KYC_DocumentType").HasKey(x => x.Id);
            builder.Entity<DocumentType>().Property(x => x.Name).IsRequired();
            builder.Entity<DocumentType>().Property(x => x.ArabicName).IsRequired();
            builder.Entity<DocumentType>().Property(x => x.Name).HasMaxLength(50);
            builder.Entity<DocumentType>().Property(x => x.ArabicName).HasMaxLength(50);

            builder.Entity<EducationLevel>().ToTable("KYC_EducationLevel").HasKey(i => i.Id);
            builder.Entity<EducationLevel>().Property(i => i.Level).HasMaxLength(50);
            builder.Entity<EducationLevel>().Property(i => i.ArabicLevel).HasMaxLength(50);

            builder.Entity<EmploymentStatus>().ToTable("KYC_EmploymentStatus").HasKey(i => i.Id);
            builder.Entity<EmploymentStatus>().Property(i => i.Status).HasMaxLength(50);
            builder.Entity<EmploymentStatus>().Property(i => i.ArabicStatus).HasMaxLength(50);

            builder.Entity<InvestorTypeSetup>().ToTable("KYC_InvestorTypeSetup").HasKey(x => x.Id);
            builder.Entity<InvestorTypeSetup>().Property(a => a.InvestorType).HasMaxLength(50).HasDefaultValue("Retail");
            builder.Entity<InvestorTypeSetup>().Property(a => a.Description).HasMaxLength(1000);
            builder.Entity<InvestorTypeSetup>().Property(a => a.ArabicDescription).HasMaxLength(1000);
            builder.Entity<InvestorTypeSetup>().Property(a => a.PeriodInMonths).HasDefaultValue(12);
            builder.Entity<InvestorTypeSetup>().Property(a => a.MaxPerOrder).HasPrecision(18, 3).HasDefaultValue(1000);
            builder.Entity<InvestorTypeSetup>().Property(a => a.MaxPerPeriod).HasPrecision(18, 3).HasDefaultValue(10000);
            builder.Entity<InvestorTypeSetup>().Property(a => a.CreatedDate).HasDefaultValueSql("DATEADD(hour, 3, sysutcdatetime())");
            builder.Entity<InvestorTypeSetup>().Property(a => a.CreatedBy).HasMaxLength(50);
            builder.Entity<InvestorTypeSetup>().Property(a => a.ModifiedBy).HasMaxLength(50);

            builder.Entity<NetWorthRange>().ToTable("KYC_NetWorthRange").HasKey(i => i.Id);
            builder.Entity<NetWorthRange>().Property(i => i.Range).HasMaxLength(50);
            builder.Entity<NetWorthRange>().Property(i => i.ArabicRange).HasMaxLength(50);

            builder.Entity<Questionnaire>().ToTable("KYC_Questionnaire").HasKey(q => q.Id);
            builder.Entity<Questionnaire>().Property(q => q.Title).HasMaxLength(500);
            builder.Entity<Questionnaire>().Property(q => q.Description).HasMaxLength(500);
            builder.Entity<Questionnaire>().Property(q => q.ArabicTitle).HasMaxLength(500);
            builder.Entity<Questionnaire>().Property(q => q.ArabicDescription).HasMaxLength(500);
            builder.Entity<Questionnaire>().Property(q => q.CreatedDate).HasDefaultValueSql("DATEADD(hour, 3, sysutcdatetime())");

            builder.Entity<RiskAgreement>().ToTable("KYC_RiskAgreement").HasKey(x => x.Id);
            builder.Entity<RiskAgreement>().Property(a => a.Title).HasMaxLength(500);
            builder.Entity<RiskAgreement>().Property(a => a.Description).HasMaxLength(500);
            builder.Entity<RiskAgreement>().Property(a => a.ArabicTitle).HasMaxLength(500);
            builder.Entity<RiskAgreement>().Property(a => a.ArabicDescription).HasMaxLength(500);

            builder.Entity<SocialStatus>().ToTable("KYC_SocialStatus").HasKey(x => x.Id);
            builder.Entity<SocialStatus>().Property(x => x.Name).HasMaxLength(50);
            builder.Entity<SocialStatus>().Property(x => x.ArabicName).HasMaxLength(50);

            builder.Entity<SourceOfIncome>().ToTable("KYC_SourceOfIncome").HasKey(i => i.Id);
            builder.Entity<SourceOfIncome>().Property(i => i.Source).HasMaxLength(50);
            builder.Entity<SourceOfIncome>().Property(i => i.ArabicSource).HasMaxLength(50);

            builder.Entity<SourceOfWealth>().ToTable("KYC_SourceOfWealth").HasKey(i => i.Id);
            builder.Entity<SourceOfWealth>().Property(i => i.Source).HasMaxLength(50);
            builder.Entity<SourceOfWealth>().Property(i => i.ArabicSource).HasMaxLength(50);

            builder.Entity<FinancialInfo>().ToTable("User_KYC_FinancialInfo").HasKey(i => i.Id);
            builder.Entity<FinancialInfo>().Property(i => i.MonthlyIncome).HasPrecision(18, 3);

            builder.Entity<PersonalInfo>().ToTable("User_KYC_PersonalInfo").HasKey(i => i.Id);
            builder.Entity<PersonalInfo>().Property(a => a.EmployeerName).HasMaxLength(200);
            builder.Entity<PersonalInfo>().Property(a => a.EmployeerAddress).HasMaxLength(200);
            builder.Entity<PersonalInfo>().Property(a => a.EmployeerContactDetails).HasMaxLength(500);
            builder.Entity<PersonalInfo>().Property(a => a.Designation).HasMaxLength(200);

            builder.Entity<UserAddress>().ToTable("User_Address").HasKey(q => q.UserId);
            builder.Entity<UserAddress>().Property(q => q.HouseOrBuildingNo).HasMaxLength(10);
            builder.Entity<UserAddress>().Property(q => q.City).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.Area).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.Block).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.Street).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.Floor).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.Apartment).HasMaxLength(50);
            builder.Entity<UserAddress>().Property(q => q.PostalCode).HasMaxLength(50);
        }

        private static void KYCConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndividualKYC>(entity =>
                {
                    entity.HasOne<EmploymentDetails>()
                          .WithOne()
                          .HasForeignKey<IndividualKYC>(i => i.EmploymentDetailsId)
                          .HasConstraintName("FK_IndKYC_EmpDetails");
                });
        }

        private static void IndividualKYC(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndividualKYC>().ToTable("User_KYC_Individual");
            modelBuilder.Entity<IndividualKYC>().HasKey(i => i.UserId);

            modelBuilder.Entity<EmploymentDetails>().ToTable("User_KYC_Employment");
            modelBuilder.Entity<EmploymentDetails>().HasKey(e => e.Id);
        }
    }
}