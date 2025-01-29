namespace UI.Models.KYC
{
    public class Declaration : AuditBase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
    }
}