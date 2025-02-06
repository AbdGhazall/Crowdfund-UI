using System.ComponentModel.DataAnnotations;

namespace UI.Models.KYC
{
    public class InvestorTypeSetup : AuditBase
    {
        [Key]
        public int Id { get; set; }

        public string InvestorType { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }

        public decimal MaxPerOrder { get; set; }
        public decimal MaxPerPeriod { get; set; }
        public int PeriodInMonths { get; set; }
    }
}