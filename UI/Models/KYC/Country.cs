using System.Diagnostics.CodeAnalysis;

namespace UI.Models.KYC
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowNull]
        public string? ArabicName { get; set; }

        public string Code { get; set; }
    }
}