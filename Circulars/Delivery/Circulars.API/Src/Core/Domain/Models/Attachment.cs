namespace Circulars.Domain.Models
{
    public class Attachment : BaseEntity<Guid>
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public Guid CircularId { get; set; }
        public Circular Circular { get; set; }

    }

}
