namespace Circulars.Domain.Models
{
    public class OrgConcerned : BaseEntity<Guid>
    {
        public Guid OrgsConcernedId {  get; set; }
        public Guid CircularId {  get; set; }
        public Circular Circular {  get; set; }
    }
}
