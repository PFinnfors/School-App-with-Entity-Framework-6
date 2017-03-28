namespace SchoolNew1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignmentStudentManyRelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentAssignments",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Assignment_AssignmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Assignment_AssignmentId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Assignments", t => t.Assignment_AssignmentId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Assignment_AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentAssignments", "Assignment_AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.StudentAssignments", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.StudentAssignments", new[] { "Assignment_AssignmentId" });
            DropIndex("dbo.StudentAssignments", new[] { "Student_StudentId" });
            DropTable("dbo.StudentAssignments");
        }
    }
}
