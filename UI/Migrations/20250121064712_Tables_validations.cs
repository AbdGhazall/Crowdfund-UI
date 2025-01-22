using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UI.Migrations
{
    /// <inheritdoc />
    public partial class Tables_validations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrategyCodes",
                table: "StrategyCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RiskToleranceCodes",
                table: "RiskToleranceCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurposeOfInvestmentCodes",
                table: "PurposeOfInvestmentCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeCodes",
                table: "KnowledgeCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvestmentObjectiveCodes",
                table: "InvestmentObjectiveCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpectedTransactionPerMonthRanges",
                table: "ExpectedTransactionPerMonthRanges");

            migrationBuilder.RenameTable(
                name: "StrategyCodes",
                newName: "KYC_StrategyCode");

            migrationBuilder.RenameTable(
                name: "RiskToleranceCodes",
                newName: "KYC_RiskToleranceCode");

            migrationBuilder.RenameTable(
                name: "PurposeOfInvestmentCodes",
                newName: "KYC_PurposeOfInvestmentCode");

            migrationBuilder.RenameTable(
                name: "KnowledgeCodes",
                newName: "KYC_KnowledgeCode");

            migrationBuilder.RenameTable(
                name: "InvestmentObjectiveCodes",
                newName: "KYC_InvestmentObjectiveCode");

            migrationBuilder.RenameTable(
                name: "ExpectedTransactionPerMonthRanges",
                newName: "KYC_ExpectedTransactionPerMonthRange");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_StrategyCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_StrategyCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_RiskToleranceCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_RiskToleranceCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_PurposeOfInvestmentCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_PurposeOfInvestmentCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_KnowledgeCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_KnowledgeCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_InvestmentObjectiveCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_InvestmentObjectiveCode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KYC_ExpectedTransactionPerMonthRange",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KYC_ExpectedTransactionPerMonthRange",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_StrategyCode",
                table: "KYC_StrategyCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_RiskToleranceCode",
                table: "KYC_RiskToleranceCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_PurposeOfInvestmentCode",
                table: "KYC_PurposeOfInvestmentCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_KnowledgeCode",
                table: "KYC_KnowledgeCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_InvestmentObjectiveCode",
                table: "KYC_InvestmentObjectiveCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KYC_ExpectedTransactionPerMonthRange",
                table: "KYC_ExpectedTransactionPerMonthRange",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_StrategyCode",
                table: "KYC_StrategyCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_RiskToleranceCode",
                table: "KYC_RiskToleranceCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_PurposeOfInvestmentCode",
                table: "KYC_PurposeOfInvestmentCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_KnowledgeCode",
                table: "KYC_KnowledgeCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_InvestmentObjectiveCode",
                table: "KYC_InvestmentObjectiveCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KYC_ExpectedTransactionPerMonthRange",
                table: "KYC_ExpectedTransactionPerMonthRange");

            migrationBuilder.RenameTable(
                name: "KYC_StrategyCode",
                newName: "StrategyCodes");

            migrationBuilder.RenameTable(
                name: "KYC_RiskToleranceCode",
                newName: "RiskToleranceCodes");

            migrationBuilder.RenameTable(
                name: "KYC_PurposeOfInvestmentCode",
                newName: "PurposeOfInvestmentCodes");

            migrationBuilder.RenameTable(
                name: "KYC_KnowledgeCode",
                newName: "KnowledgeCodes");

            migrationBuilder.RenameTable(
                name: "KYC_InvestmentObjectiveCode",
                newName: "InvestmentObjectiveCodes");

            migrationBuilder.RenameTable(
                name: "KYC_ExpectedTransactionPerMonthRange",
                newName: "ExpectedTransactionPerMonthRanges");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "StrategyCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "StrategyCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RiskToleranceCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "RiskToleranceCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PurposeOfInvestmentCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "PurposeOfInvestmentCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "KnowledgeCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "KnowledgeCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "InvestmentObjectiveCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "InvestmentObjectiveCodes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ExpectedTransactionPerMonthRanges",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ArabicDescription",
                table: "ExpectedTransactionPerMonthRanges",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrategyCodes",
                table: "StrategyCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RiskToleranceCodes",
                table: "RiskToleranceCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurposeOfInvestmentCodes",
                table: "PurposeOfInvestmentCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeCodes",
                table: "KnowledgeCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvestmentObjectiveCodes",
                table: "InvestmentObjectiveCodes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpectedTransactionPerMonthRanges",
                table: "ExpectedTransactionPerMonthRanges",
                column: "Id");
        }
    }
}
