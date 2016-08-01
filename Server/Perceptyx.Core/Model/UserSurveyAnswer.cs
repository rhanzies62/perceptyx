using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Model
{
    public class UserSurveyAnswer : IAudit
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        public int? QuestionChoiceId { get; set; } 

        public YesNo? YesNoAnswer { get; set; }

        public string FreeTextAnswer { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedOn { get; set; }

        public Question Question { get; set; }
        public User User { get; set; }
    }
}
