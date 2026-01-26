namespace Circulars.Domain.Models
{
    public class LK_Message : BaseEntity<Guid>
    {
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        public bool IsNew { get; set; }
    }
}
