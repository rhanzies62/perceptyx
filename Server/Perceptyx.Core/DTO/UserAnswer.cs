using Perceptyx.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.DTO
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }

        public int? QuestionChoiceId { get; set; }

        public YesNo? YesNoAnswer { get; set; }

        public string FreeTextAnswer { get; set; }
    }
}
