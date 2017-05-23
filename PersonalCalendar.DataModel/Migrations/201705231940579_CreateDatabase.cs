namespace PersonalCalendar.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        DateOfMonth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAllDayEvent = c.Boolean(nullable: false),
                        StartDateId = c.Int(),
                        EndDateId = c.Int(),
                        StartTimeId = c.Int(),
                        EndTimeId = c.Int(),
                        Title = c.String(),
                        Category = c.Int(nullable: false),
                        Description = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dates", t => t.EndDateId)
                .ForeignKey("dbo.Times", t => t.EndTimeId)
                .ForeignKey("dbo.Dates", t => t.StartDateId)
                .ForeignKey("dbo.Times", t => t.StartTimeId)
                .Index(t => t.StartDateId)
                .Index(t => t.EndDateId)
                .Index(t => t.StartTimeId)
                .Index(t => t.EndTimeId);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.Int(nullable: false),
                        Minute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "StartTimeId", "dbo.Times");
            DropForeignKey("dbo.Plans", "StartDateId", "dbo.Dates");
            DropForeignKey("dbo.Plans", "EndTimeId", "dbo.Times");
            DropForeignKey("dbo.Plans", "EndDateId", "dbo.Dates");
            DropIndex("dbo.Plans", new[] { "EndTimeId" });
            DropIndex("dbo.Plans", new[] { "StartTimeId" });
            DropIndex("dbo.Plans", new[] { "EndDateId" });
            DropIndex("dbo.Plans", new[] { "StartDateId" });
            DropTable("dbo.Times");
            DropTable("dbo.Plans");
            DropTable("dbo.Dates");
        }
    }
}
