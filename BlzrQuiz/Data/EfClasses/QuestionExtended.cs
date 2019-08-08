using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.EfClasses
{
    [NotMapped]
    public partial class Question
    {
        public Question Reset()
        {
            return new Question();
        }
        public QResult Result { get; set; }
    }
}
