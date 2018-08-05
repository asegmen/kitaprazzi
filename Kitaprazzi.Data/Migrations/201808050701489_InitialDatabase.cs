namespace Kitaprazzi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75),
                        Url = c.String(maxLength: 75),
                        CategoryID = c.Int(nullable: false),
                        IsMenu = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Spot = c.String(maxLength: 250),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        PublisherID = c.Int(nullable: false),
                        EditorPoint = c.Single(nullable: false),
                        UserPoint = c.Single(nullable: false),
                        KitaprazziPoint = c.Single(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.MediaItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Url = c.String(maxLength: 100),
                        Type = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Content_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contents", t => t.Content_ID)
                .Index(t => t.Content_ID);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Phone = c.String(),
                        Adress = c.String(),
                        CityID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CityID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        City_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.City_ID)
                .Index(t => t.City_ID);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Phone = c.String(),
                        CityID = c.Int(nullable: false),
                        CountryID = c.Int(nullable: false),
                        PublisherID = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PublisherID)
                .Index(t => t.CityID)
                .Index(t => t.CountryID)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 16),
                        RoleID = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Message = c.String(maxLength: 1000),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.MainControls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Sequence = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.MainSliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        ImageUrl = c.String(),
                        Spot = c.String(),
                        ButtonText = c.String(),
                        ButtonUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Name = c.String(),
                        Value = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MainControls", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Categories", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Contents", "PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Dealers", "PublisherID", "dbo.Publishers");
            DropForeignKey("dbo.Dealers", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Dealers", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Publishers", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Countries", "City_ID", "dbo.Cities");
            DropForeignKey("dbo.Publishers", "CityID", "dbo.Cities");
            DropForeignKey("dbo.MediaItems", "Content_ID", "dbo.Contents");
            DropForeignKey("dbo.Contents", "CategoryID", "dbo.Categories");
            DropIndex("dbo.MainControls", new[] { "CategoryID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Dealers", new[] { "PublisherID" });
            DropIndex("dbo.Dealers", new[] { "CountryID" });
            DropIndex("dbo.Dealers", new[] { "CityID" });
            DropIndex("dbo.Countries", new[] { "City_ID" });
            DropIndex("dbo.Publishers", new[] { "CountryID" });
            DropIndex("dbo.Publishers", new[] { "CityID" });
            DropIndex("dbo.MediaItems", new[] { "Content_ID" });
            DropIndex("dbo.Contents", new[] { "PublisherID" });
            DropIndex("dbo.Contents", new[] { "CategoryID" });
            DropIndex("dbo.Categories", new[] { "User_ID" });
            DropTable("dbo.SystemSettings");
            DropTable("dbo.MainSliders");
            DropTable("dbo.MainControls");
            DropTable("dbo.Comments");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Dealers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Publishers");
            DropTable("dbo.MediaItems");
            DropTable("dbo.Contents");
            DropTable("dbo.Categories");
        }
    }
}
