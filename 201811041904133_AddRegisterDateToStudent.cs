namespace StudentRegistrationApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterDateToStudent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "RegisterDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "RegisterDate", c => c.DateTime(nullable: false));
        }
    }
}
