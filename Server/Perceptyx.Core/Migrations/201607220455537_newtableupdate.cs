namespace Perceptyx.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtableupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Salt = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        CreatedBy = c.String(nullable: false),
                        UpdatedOn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserSurveyAnswers", "UserId");
            AddForeignKey("dbo.UserSurveyAnswers", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSurveyAnswers", "UserId", "dbo.Users");
            DropIndex("dbo.UserSurveyAnswers", new[] { "UserId" });
            DropTable("dbo.Users");
        }
    }
}
