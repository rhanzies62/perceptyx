using Perceptyx.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perceptyx.Core.DTO;
using System.Data.Entity;
using Perceptyx.Core.Model;
using Perceptyx.Core.Extension;
namespace Perceptyx.Core.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly PerceptyxContext perceptyxContext;

        public SurveyRepository()
        {
            perceptyxContext = new PerceptyxContext();
        }

        public int Add(DTO.Survey model)
        {
            model.ValidateSurvey();
            var existingEntity = this.Get(model.Name);
            if (existingEntity == null)
            {
                var entity = new Model.Survey(model);
                perceptyxContext.Surveys.Add(entity);
                perceptyxContext.SaveChanges();
                return entity.Id;
            }

            throw new Exception("Name already exist in the DB");
        }

        public bool Delete(int surveyId)
        {
            var result = false;
            var entity = perceptyxContext.Surveys.Where(i => i.Id.Equals(surveyId)).FirstOrDefault();

            if (entity != null)
            {
                perceptyxContext.Surveys.Remove(entity);
                result = true;
            }

            return result;
        }

        public int Edit(DTO.Survey model)
        {
            model.ValidateSurvey();

            var existingEntity = this.Get(model.Name);
            var entity = this.Get(model.Id);

            if (entity == null)
                throw new Exception("Survey is not existing in the DB");

            if(existingEntity != null)
                if (existingEntity.Id != entity.Id)
                    throw new Exception("Name already existi in the DB");

            entity.Name = model.Name;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedOn = model.UpdatedOn;
            perceptyxContext.SaveChanges();
            return entity.Id;
        }

        public DTO.Survey Get(string name)
        {
            var entity = perceptyxContext.Surveys.Where(i => i.Name.Equals(name)).FirstOrDefault();
            return entity == null ? null : new DTO.Survey(entity);
        }

        public DTO.Survey Get(int id)
        {
            var entity = perceptyxContext.Surveys.Where(i => i.Id.Equals(id)).FirstOrDefault();
            if(entity == null) {  throw new Exception("survey not found"); }
            return new DTO.Survey(entity);
        }

        public List<DTO.Survey> Retrieve()
        {
            return perceptyxContext.Surveys.Select(i => new DTO.Survey
            {
                Id = i.Id,
                CreatedBy = i.CreatedBy,
                CreatedDate = i.CreatedDate,
                Name = i.Name,
                UpdatedDate = i.UpdatedDate,
                UpdatedOn = i.UpdatedOn
            }).ToList();
        }

        public List<DTO.Survey> Retrieve(int skip, int take)
        {
            return perceptyxContext.Surveys.Select(i => new DTO.Survey
            {
                Id = i.Id,
                CreatedBy = i.CreatedBy,
                CreatedDate = i.CreatedDate,
                Name = i.Name,
                UpdatedDate = i.UpdatedDate,
                UpdatedOn = i.UpdatedOn
            }).Skip(skip).Take(take).ToList();
        }

        public List<DTO.Survey> Retrieve(string name, int skip, int take)
        {
            return perceptyxContext.Surveys.Where(i=>i.Name.Contains(name)).Select(i => new DTO.Survey
            {
                Id = i.Id,
                CreatedBy = i.CreatedBy,
                CreatedDate = i.CreatedDate,
                Name = i.Name,
                UpdatedDate = i.UpdatedDate,
                UpdatedOn = i.UpdatedOn
            }).Skip(skip).Take(take).ToList();
        }
    }
}
