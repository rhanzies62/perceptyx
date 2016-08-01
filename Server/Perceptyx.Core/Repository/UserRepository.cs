using Perceptyx.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Perceptyx.Core.DTO;

namespace Perceptyx.Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Model.PerceptyxContext perceptyxContext;
        private readonly Interface.IQuestionRepository questionRepository;
        public UserRepository()
        {
            perceptyxContext = new Model.PerceptyxContext();
            questionRepository = new QuestionRepository();
        }

        public bool AnswerSurvey(UserAnswer answer)
        {
            var result = false;

            var _answerEntity = perceptyxContext.UserSurveyAnswers.Where(i => i.QuestionId.Equals(answer.QuestionId) && i.UserId.Equals(answer.UserId)).FirstOrDefault();
            var answerEntity = _answerEntity != null ? _answerEntity : new Model.UserSurveyAnswer();
            answerEntity.UserId = answer.UserId;
            answerEntity.QuestionId = answer.QuestionId;
            answerEntity.CreatedBy = answer.UserId.ToString();
            answerEntity.CreatedDate = DateTime.UtcNow;

            var question = questionRepository.Get(answer.QuestionId);
            if (question == null) { throw new Exception("Question not found"); }
            switch (question.Type)
            {
                case Model.QuestionType.FreeText: {
                        answerEntity.FreeTextAnswer = answer.FreeTextAnswer;
                    }; break;
                case Model.QuestionType.MultipleChoice: {
                        if (answer.QuestionChoiceId == null) { throw new Exception("Please select your answer in the choices provided"); }
                        var getChoice = questionRepository.GetChoice(answer.QuestionChoiceId.Value);
                        if(getChoice != null)
                        {
                            answerEntity.QuestionChoiceId = answer.QuestionChoiceId;
                        }
                        throw new Exception("Please select your answer in the choices provided");
                    };
                case Model.QuestionType.YesNo: {
                        if(answer.YesNoAnswer == null) { throw new Exception("Please select yes or no"); }
                        answerEntity.YesNoAnswer = answer.YesNoAnswer;
                    }; break;
                default: { throw new Exception("Please supply the approriate answer"); };
            }
            if(_answerEntity == null) { perceptyxContext.UserSurveyAnswers.Add(answerEntity); }
            perceptyxContext.SaveChanges();
            result = true;
            return result;
        }

        public bool AnswerSurveyBatch(List<UserAnswer> answers)
        {
            answers.ForEach(answer => {
                this.AnswerSurvey(answer);
            });
            return true;
        }

        public UserInfo Login(UserCredential model)
        {
            var userinfo = perceptyxContext.Users.Where(i => i.EmailAddress.Equals(model.EmailAddress)).FirstOrDefault();
            if (userinfo != null)
            {
                var hash = new HashBrown();
                var password = string.Concat(model.Password, userinfo.Salt);
                if (password == userinfo.Password) { return new UserInfo(userinfo); }
                else { throw new Exception("Email/Password didn't match"); }
            }
            throw new Exception("User not found");
        }

        public bool Register(UserInfo model)
        {
            var userEntity = new Model.User();
            userEntity.FirstName = model.FirstName;
            userEntity.LastName = model.LastName;
            userEntity.Salt = Guid.NewGuid().ToString("N");
            userEntity.EmailAddress = model.EmailAddress;
            userEntity.IsAdmin = model.IsAdmin;

            var password = string.Concat(model.Password, userEntity.Salt);

            userEntity.CreatedDate = DateTime.UtcNow;
            userEntity.CreatedBy = string.Concat(model.FirstName, model.LastName);

            perceptyxContext.Users.Add(userEntity);
            perceptyxContext.SaveChanges();
            return true;
        }
    }
}
