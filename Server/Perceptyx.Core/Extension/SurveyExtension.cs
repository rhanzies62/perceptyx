using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Extension
{
    public static class SurveyExtension
    {
        public static bool ValidateSurvey(this DTO.Survey model)
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(model.Name)) { throw new Exception("Name is required"); }
            
            return result;
        }
    }
}
