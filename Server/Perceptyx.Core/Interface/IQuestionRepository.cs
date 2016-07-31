using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Interface
{
    public interface IQuestionRepository
    {
        int AddQuestion(DTO.Question model);
        int UpdateQuestion(DTO.Question model);
        bool AddQuestionChoices(List<DTO.QuestionChoice> choices, int questionId);
        bool AddQuestionChoice(DTO.QuestionChoice choice);
        bool UpdateQuestionChoices(List<DTO.QuestionChoice> choices);
        bool UpdateQuestionChoice(DTO.QuestionChoice model);
        bool ClearQuestionChoices(int questionId);
        bool DeleteQuestion(int questionId);
        List<DTO.Question> Retrieve(int surveyId);
    }
}
