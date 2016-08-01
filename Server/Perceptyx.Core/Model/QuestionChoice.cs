using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Model
{
    public class QuestionChoice : IAudit
    {
        public QuestionChoice()
        {

        }

        public QuestionChoice(DTO.QuestionChoice model)
        {
            this.QuestionId = model.QuestionId;
            this.Ordinal = model.Ordinal;
            this.Value = model.Value;
            this.CreatedBy = model.CreatedBy;
            this.CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [Required]
        public int Ordinal { get; set; }

        [Required]
        [MaxLength(100)]
        public string Value { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedOn { get; set; }

        public Question Question { get; set; }
    }
}
