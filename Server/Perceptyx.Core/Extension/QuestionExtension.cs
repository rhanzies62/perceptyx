using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Extension
{
    public static class QuestionExtension
    {
        public static bool Validate(this DTO.Question model)
        {
            if (string.IsNullOrWhiteSpace(model.Poll)) { throw new Exception("Poll is required"); }
            if (model.SurveyId == 0) { throw new Exception("Please select a survey before adding question"); }
            if (string.IsNullOrWhiteSpace(model.CreatedBy)) { throw new Exception("Please add user who created this record"); }

            return true;
        }

        public static bool ValidateChoice(this DTO.QuestionChoice model)
        {
            if (string.IsNullOrWhiteSpace(model.Value)) { throw new Exception("Choice should have a value"); }
            if(model.QuestionId == 0) { throw new Exception("Please select a question before adding choices"); }
            if(string.IsNullOrWhiteSpace(model.CreatedBy)) { throw new Exception("Please add use who created this"); }
            return true;
        }
    }
}
