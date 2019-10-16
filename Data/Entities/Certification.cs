using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    public class Certification
    {
        public int CertificationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
