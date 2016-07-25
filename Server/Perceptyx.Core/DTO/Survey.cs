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
    }
}
