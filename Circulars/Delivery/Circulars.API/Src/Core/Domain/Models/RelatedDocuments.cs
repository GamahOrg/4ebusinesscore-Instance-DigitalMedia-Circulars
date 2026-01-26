namespace Circulars.Domain.Models
{
    public class RelatedDocuments : BaseEntity<Guid>
    {
        public Guid CircularId { get; set; }
        public Circular Circular { get; set; }
        public Guid RelatedDocumentId { get; set; }
    }
}
