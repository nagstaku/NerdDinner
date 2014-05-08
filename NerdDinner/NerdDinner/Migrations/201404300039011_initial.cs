namespace NerdDinner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Guid(nullable: false),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        MeetingID = c.Guid(nullable: false),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                        OwnerID = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Location_LocationID = c.Guid(),
                    })
                .PrimaryKey(t => t.MeetingID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Locations", t => t.Location_LocationID)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Location_LocationID)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        email = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Meeting_MeetingID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meetings", t => t.Meeting_MeetingID)
                .Index(t => t.Meeting_MeetingID);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meetings", "OwnerID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Meetings", "Location_LocationID", "dbo.Locations");
            DropForeignKey("dbo.AspNetUsers", "Meeting_MeetingID", "dbo.Meetings");
            DropForeignKey("dbo.Meetings", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Meetings", new[] { "OwnerID" });
            DropIndex("dbo.Meetings", new[] { "Location_LocationID" });
            DropIndex("dbo.AspNetUsers", new[] { "Meeting_MeetingID" });
            DropIndex("dbo.Meetings", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Meetings");
            DropTable("dbo.Locations");
        }
    }
}
