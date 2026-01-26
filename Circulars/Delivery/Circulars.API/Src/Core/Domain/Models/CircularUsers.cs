using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circulars.Domain.Models
{
    public class CircularUsers : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid CircularId { get; set; }
        public Circular Circular { get; set; }


    }
}
