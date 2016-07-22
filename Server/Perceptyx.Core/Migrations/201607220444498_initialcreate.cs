namespace Perceptyx.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Ordinal = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SurveyId = c.Int(nullable: false),
                        Poll = c.String(nullable: false, maxLength: 100),
                        Type = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Surveys", t => t.SurveyId, cascadeDelete: true)
                .Index(t => t.SurveyId);
            
            CreateTable(
                "dbo.Surveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSurveyAnswers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        QuestionChoiceId = c.Int(),
                        YesNoAnswer = c.Int(),
                        FreeTextAnswer = c.String(),
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        UpdatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSurveyAnswers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.QuestionChoices", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "SurveyId", "dbo.Surveys");
            DropIndex("dbo.UserSurveyAnswers", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "SurveyId" });
            DropIndex("dbo.QuestionChoices", new[] { "QuestionId" });
            DropTable("dbo.UserSurveyAnswers");
            DropTable("dbo.Surveys");
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionChoices");
        }
    }
}
