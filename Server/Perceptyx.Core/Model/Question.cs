using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Model
{
    public class Question : IAudit
    {
        public Question()
        {

        }

        public Question(DTO.Question model)
        {
            this.Poll = model.Poll;
            this.Type = model.Type;
            this.CreatedBy = model.CreatedBy;
            this.CreatedDate = DateTime.UtcNow;
            this.SurveyId = model.SurveyId;
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Poll { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedOn { get; set; }

        public Survey Survey { get; set; }
        public List<QuestionChoice> Choices { get; set; }
    }
}
