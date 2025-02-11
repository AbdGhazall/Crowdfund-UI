using System.ComponentModel.DataAnnotations;

namespace UI.Models.Users_KYC
{
    public class EmploymentDetails
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }

        /// <summary>
        /// موظف / Employee
        /// </summary>
        public bool Employee { get; set; }

        /// <summary>
        /// عمل خاص / Self-Employed
        /// </summary>
        public bool SelfEmployed { get; set; }

        /// <summary>
        /// غير موظف / Unemployed
        /// </summary>
        public bool Unemployed { get; set; }

        /// <summary>
        /// متقاعد / Retired
        /// </summary>
        public bool Retired { get; set; }

        /// <summary>
        /// طالب / Student
        /// </summary>
        public bool Student { get; set; }

        /// <summary>
        /// ربة منزل / Housewife
        /// </summary>
        public bool Housewife { get; set; }

        /// <summary>
        /// أخرى (يرجى التحديد) / Others (Pls Specify)
        /// </summary>
        [MaxLength(200)]
        public string Others { get; set; }

        /// <summary>
        /// جهة العمل / Employer
        /// إذا كنت متقاعدا، يرجى تحديد آخر جهة عمل
        /// </summary>
        [MaxLength(200)]
        public string Employer { get; set; }

        /// <summary>
        /// المسمى الوظيفي / Job title
        /// إذا كنت متقاعدا، يرجى تحديد آخر مسمى وظيفي
        /// </summary>
        [MaxLength(50)]
        public string JobTitle { get; set; }

        /// <summary>
        /// عنوان العمل / Work Address
        /// </summary>
        [MaxLength(200)]
        public string WorkAddress { get; set; }

        /// <summary>
        /// طبيعة النشاط التجاري للأعمال الخاصة أو التجارية / Nature of Business for the Private or Commercial Business
        /// </summary>
        [MaxLength(200)]
        public string NatureOfBusiness { get; set; }

    }
}
