using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Perceptyx.Core;
using Perceptyx.Core.Interface;
using Perceptyx.Core.Repository;

namespace Perceptyx.Core.Text
{
    [TestClass]
    public class SurveyTest
    {
        private ISurveyRepository surveyRepository;
        private DTO.Survey surveyModel = new DTO.Survey()
        {
            Name = "Survey 2",
            CreatedBy = "Francis"
        };

        [TestMethod]
        public void AddSurveyValid()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                var result = surveyRepository.Add(surveyModel);
                Assert.AreNotEqual(0, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSurveyInvalidName()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                surveyModel.Name = string.Empty;
                var result = surveyRepository.Add(surveyModel);
                Assert.AreNotEqual(0, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSurveyInvalidCreatedBy()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                surveyModel.CreatedBy = string.Empty;
                var result = surveyRepository.Add(surveyModel);
                Assert.AreNotEqual(0, result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void AddSurveyExistingSurveyName()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                surveyModel.Name = "Survey 1";
                var result = surveyRepository.Add(surveyModel);
                Assert.AreNotEqual(0, result);
            }
        }

        [TestMethod]
        public void DeleteSurveyValid()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                var surveys = surveyRepository.Retrieve();
                surveys.ForEach(survey =>
                {
                    var result = surveyRepository.Delete(survey.Id);
                    Assert.IsTrue(result);
                });
            }
        }

        [TestMethod]
        public void DeleteSurveyInvalid()
        {
            using (var tx = new System.Transactions.TransactionScope())
            {
                surveyRepository = new SurveyRepository();
                var surveys = surveyRepository.Retrieve();
                var result = surveyRepository.Delete(0);
                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void RetrieveSurveys()
        {
            surveyRepository = new SurveyRepository();
            var result = surveyRepository.Retrieve();
            Assert.AreNotEqual(0, result.Count);
        }

        [TestMethod]
        public void GetSurveyByIDValid()
        {
            surveyRepository = new SurveyRepository();
            var result = surveyRepository.Get(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetSurveyByIdInvalid()
        {
            surveyRepository = new SurveyRepository();
            var result = surveyRepository.Get(0);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetSurveyByNameValid()
        {
            surveyRepository = new SurveyRepository();
            var result = surveyRepository.Get("Survey 1");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetSurveyByNameInvalid()
        {
            surveyRepository = new SurveyRepository();
            var result = surveyRepository.Get("Survey 2");
            Assert.IsNull(result);
        }
    }
}
