using Perceptyx.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.DTO
{
    public class Question
    {
        public Question()
        {

        }

        public Question(Model.Question entity)
        {
            this.Id = entity.Id;
            this.SurveyId = entity.SurveyId;
            this.Poll = entity.Poll;
            this.Type = entity.Type;
            this.CreatedBy = entity.CreatedBy;
            this.CreatedDate = entity.CreatedDate;
            this.UpdatedDate = entity.UpdatedDate;
            this.UpdatedOn = entity.UpdatedOn;
        }

        public int Id { get; set; }

        public int SurveyId { get; set; }

        public string Poll { get; set; }

        public QuestionType Type { get; set; }

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

        public List<DTO.QuestionChoice> Choices { get; set; }
    }
}
