namespace UI.Models.KYC
{
    public class AuditBase
    {
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow.AddHours(3);
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}