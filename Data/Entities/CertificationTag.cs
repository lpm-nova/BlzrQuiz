using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.Entities
{
    public class CertificationTag
    {
        public int TagId { get; set; }
        public int CertificationId { get; set; }
        public Tag Tag { get; set; }
        public Certification Certification { get; set; }
    }
}
