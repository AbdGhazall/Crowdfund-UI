using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class Added14NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KYC_AnnualIncomeRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_AnnualIncomeRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_Declaration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ArabicDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_Declaration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_EducationLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicLevel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_EducationLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_EmploymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_EmploymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_InvestorTypeSetup",
                columns: table => new
                {
                    InvestorType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "Retail"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArabicDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MaxPerOrder = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false, defaultValue: 1000m),
                    MaxPerPeriod = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false, defaultValue: 10000m),
                    PeriodInMonths = table.Column<int>(type: "int", nullable: false, defaultValue: 12),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "DATEADD(hour, 3, sysutcdatetime())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_InvestorTypeSetup", x => x.InvestorType);
                });

            migrationBuilder.CreateTable(
                name: "KYC_NetWorthRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Range = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicRange = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_NetWorthRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_Questionnaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArabicTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    QuestionType = table.Column<int>(type: "int", nullable: false),
                    ArabicDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "DATEADD(hour, 3, sysutcdatetime())"),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_Questionnaire", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_RiskAgreement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArabicTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArabicDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_RiskAgreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_SocialStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_SocialStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_SourceOfIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_SourceOfIncome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KYC_SourceOfWealth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArabicSource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KYC_SourceOfWealth", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KYC_AnnualIncomeRange");

            migrationBuilder.DropTable(
                name: "KYC_Bank");

            migrationBuilder.DropTable(
                name: "KYC_Country");

            migrationBuilder.DropTable(
                name: "KYC_Declaration");

            migrationBuilder.DropTable(
                name: "KYC_DocumentType");

            migrationBuilder.DropTable(
                name: "KYC_EducationLevel");

            migrationBuilder.DropTable(
                name: "KYC_EmploymentStatus");

            migrationBuilder.DropTable(
                name: "KYC_InvestorTypeSetup");

            migrationBuilder.DropTable(
                name: "KYC_NetWorthRange");

            migrationBuilder.DropTable(
                name: "KYC_Questionnaire");

            migrationBuilder.DropTable(
                name: "KYC_RiskAgreement");

            migrationBuilder.DropTable(
                name: "KYC_SocialStatus");

            migrationBuilder.DropTable(
                name: "KYC_SourceOfIncome");

            migrationBuilder.DropTable(
                name: "KYC_SourceOfWealth");
        }
    }
}