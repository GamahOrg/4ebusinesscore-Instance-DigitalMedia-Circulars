using System.ComponentModel.DataAnnotations.Schema;

namespace Circulars.Domain.Models
{
    public class Circular : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string? NameEn { get; set; }
        public string Number { get; set; }
        [ForeignKey("Approval")]
        public Guid? ApprovalId { get; set; }
        public LK_Approval Approval { get; set; }
        public List<OrgConcerned>? OrgsConcerned { get; set; }
        [ForeignKey("Issuer")]
        public Guid? IssuerId { get; set; }
        public LK_Issuer Issuer { get; set; }
        public string? DocumentClass { get; set; }
        public string? DocumentClassAr { get; set; }

        [ForeignKey("Enforcement")]
        public Guid? EnforcementId { get; set; }
        public LK_Enforcement Enforcement { get; set; }
        public string DocumentAbout { get; set; }
        public DateTime AccreditationDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Details { get; set; }
        public PublicationType PublicationType { get; set; }
        public bool IsArchived { get; set; }
        public bool Ispublished { get; set; }
        public List<Attachment>? Attachments { get; set; }
        public List<CircularUsers>? Users { get; set; }
        public List<CircularOrg>? Orgs { get; set; }

        public List<RelatedDocuments>? RelatedDocuments { get; set; }

        public string? DocumentAboutEn { get; set; }

    }
}
