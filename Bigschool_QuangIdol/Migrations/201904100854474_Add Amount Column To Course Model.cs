namespace Bigschool_QuangIdol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountColumnToCourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Amount");
        }
    }
}
