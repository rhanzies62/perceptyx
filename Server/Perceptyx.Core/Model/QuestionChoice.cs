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
        public string CreatedBy
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        [Required]
        public DateTime CreatedDate
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime? UpdatedDate
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string UpdatedOn
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public Question Question { get; set; }
    }
}
