using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.DTO
{
    public class Survey
    {
        public Survey()
        {

        }


        public Survey(Model.Survey entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.CreatedBy = entity.CreatedBy;
            this.CreatedDate = entity.CreatedDate;
            this.UpdatedDate = entity.UpdatedDate;
            this.UpdatedOn = entity.UpdatedOn;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate
        { get; set; }

        public DateTime? UpdatedDate
        { get; set; }

        public string UpdatedOn { get; set; }
    }
}
