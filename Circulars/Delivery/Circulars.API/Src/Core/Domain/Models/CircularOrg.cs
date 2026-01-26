namespace Circulars.Domain.Models
{
    public class CircularOrg : BaseEntity<Guid>
    {
        public Guid OrgId { get; set; }
        public Guid CircularId { get; set; }
        public Circular Circular { get; set; }
    }
}
