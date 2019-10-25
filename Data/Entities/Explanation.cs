using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzrQuiz.Data.Entities
{
    public class Explanation
    {
        public int ExplanationId { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public MarkupString ToMarkup()
        {
            return new MarkupString(Text);
        }
    }
}
