using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptyx.Core.Model
{
    public class PerceptyxContext : DbContext
    {
        public PerceptyxContext() : 
            base("PerceptyxContext")
        {

        }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionChoice> QuestionChoices { get; set; }
        public DbSet<UserSurveyAnswer> UserSurveyAnswers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
