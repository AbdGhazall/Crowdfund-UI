using System.ComponentModel.DataAnnotations;

namespace UI.Models.KYC
{
    public class ExpectedTransactionPerMonthRange
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
    }
}
