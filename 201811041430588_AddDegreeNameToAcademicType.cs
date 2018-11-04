namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDegreeNameToAcademicType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcademicTypes", "DegreeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcademicTypes", "DegreeName");
        }
    }
}
