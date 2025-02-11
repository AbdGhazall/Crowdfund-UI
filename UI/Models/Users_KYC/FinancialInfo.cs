using UI.Models.KYC;

namespace UI.Models.Users_KYC
{
    public class FinancialInfo
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int NetWorthRangeId { get; set; }
        public int AnnualIncomeRangeId { get; set; }
        public decimal MonthlyIncome { get; set; } = 0;
        public virtual AnnualIncomeRange AnnualIncomeRange { get; set; }
        public virtual NetWorthRange NetWorthRange { get; set; }
    }
}
