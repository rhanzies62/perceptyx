using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Interface
{
    public interface ISurveyRepository
    {
        int Add(DTO.Survey model);
        int Edit(DTO.Survey model);
        bool Delete(int surveyId);
        List<DTO.Survey> Retrieve();
        List<DTO.Survey> Retrieve(int skip, int take);
        List<DTO.Survey> Retrieve(string name, int skip, int take);
        DTO.Survey Get(int id);
        DTO.Survey Get(string name);
    }
}
