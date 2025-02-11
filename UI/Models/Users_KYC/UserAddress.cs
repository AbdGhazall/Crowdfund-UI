namespace UI.Models.Users_KYC
{
    public class UserAddress : AuditBase
    {
        public Guid UserId { get; set; }
        public int Country { get; set; }
        public string? City { get; set; }
        public string? Area { get; set; }
        public string? Block { get; set; }
        public string? HouseOrBuildingNo { get; set; }
        public string? Street { get; set; }
        public string? Floor { get; set; }
        public string? Apartment { get; set; }
        public string? PostalCode { get; set; }
    }
}
