namespace UI.Models.KYC
{
    public class RiskAgreement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string ArabicTitle { get; set; }
        public string? ArabicDescription { get; set; }
    }
}