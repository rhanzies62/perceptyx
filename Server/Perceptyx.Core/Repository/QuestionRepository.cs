using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perceptyx.Core.Interface;
using Perceptyx.Core.DTO;
using Perceptyx.Core.Model;
using Perceptyx.Core.Extension;
namespace Perceptyx.Core.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PerceptyxContext perceptyxContext;
        private readonly ISurveyRepository surveyRepository;

        public QuestionRepository()
        {
            perceptyxContext = new PerceptyxContext();
            surveyRepository = new SurveyRepository();
        }

        public int AddQuestion(DTO.Question model)
        {
            model.Validate();
            var existingQuesiton = this.GetQuestion(model.Poll);
            if (existingQuesiton.Any()) { throw new Exception("Question already exist in this survey"); }

            var existingSurvey = surveyRepository.Get(model.SurveyId);
            if (existingSurvey == null) { throw new Exception("Survey is not existing in the."); }


            var questionEntity = new Model.Question(model);
            perceptyxContext.Questions.Add(questionEntity);
            perceptyxContext.SaveChanges();

            if (model.Type == QuestionType.MultipleChoice && model.Choices != null)
            {
                this.AddQuestionChoices(model.Choices, questionEntity.Id);
            }
            return questionEntity.Id;
        }

        private IQueryable<Model.Question> GetQuestion(string poll)
        {
            return perceptyxContext.Questions.Where(i => i.Poll.Equals(poll));
        }

        public bool AddQuestionChoices(List<DTO.QuestionChoice> choices, int questionId)
        {
            using(System.Transactions.TransactionScope tx = new System.Transactions.TransactionScope())
            {
                choices.ForEach(choice => {
                    choice.QuestionId = questionId;
                    this.AddQuestionChoice(choice);
                });
                perceptyxContext.SaveChanges();
                tx.Complete();
            }
            return true;
        }

        public bool ClearQuestionChoices(int questionId)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public List<DTO.Question> Retrieve(int surveyId)
        {
            throw new NotImplementedException();
        }

        public int UpdateQuestion(DTO.Question model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestionChoices(List<DTO.QuestionChoice> choices)
        {
            throw new NotImplementedException();
        }

        public bool AddQuestionChoice(DTO.QuestionChoice choice)
        {
            var result = false;
            choice.ValidateChoice();
            var choiceEntity = new Model.QuestionChoice(choice);
            choiceEntity.Ordinal = GenerateOrdinal(choice.QuestionId);
            perceptyxContext.QuestionChoices.Add(choiceEntity);
            return result;
        }

        private int GenerateOrdinal(int questionId)
        {
            var lastChoice = perceptyxContext.QuestionChoices
                .Where(i => i.QuestionId.Equals(questionId))
                .OrderBy(i => i.Ordinal)
                .FirstOrDefault();

            return lastChoice == null ? 1 : lastChoice.Ordinal + 1;
        }
    }
}
