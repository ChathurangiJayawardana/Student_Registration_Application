namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAcademicType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "InformationId", "dbo.Information");
            DropIndex("dbo.Students", new[] { "InformationId" });
            CreateTable(
                "dbo.AcademicTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        NoOfCourses = c.Int(nullable: false),
                        TotalCredits = c.Int(nullable: false),
                        year = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "AcademicTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Students", "AcademicTypeId");
            AddForeignKey("dbo.Students", "AcademicTypeId", "dbo.AcademicTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Students", "InformationId");
            DropTable("dbo.Information");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NIC = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Sex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "InformationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Students", "AcademicTypeId", "dbo.AcademicTypes");
            DropIndex("dbo.Students", new[] { "AcademicTypeId" });
            DropColumn("dbo.Students", "AcademicTypeId");
            DropTable("dbo.AcademicTypes");
            CreateIndex("dbo.Students", "InformationId");
            AddForeignKey("dbo.Students", "InformationId", "dbo.Information", "Id", cascadeDelete: true);
        }
    }
}
