namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToStudentName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "IndexNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "IndexNo", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
