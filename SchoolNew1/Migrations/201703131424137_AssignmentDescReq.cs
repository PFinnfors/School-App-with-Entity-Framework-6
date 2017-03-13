namespace SchoolNew1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignmentDescReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "Name", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Assignments", "Description", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(maxLength: 25));
            AlterColumn("dbo.Teachers", "LastName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Teachers", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Students", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Courses", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Assignments", "Description", c => c.String());
            AlterColumn("dbo.Assignments", "Name", c => c.String(maxLength: 50));
        }
    }
}
