using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Model
{
    public class Survey : IAudit
    {
        public Survey()
        {

        }

        public Survey(DTO.Survey model)
        {
            this.Name = model.Name;
            this.CreatedBy = model.CreatedBy;
            this.CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate
        { get; set; }

        public string UpdatedOn { get; set; }
    }
}
