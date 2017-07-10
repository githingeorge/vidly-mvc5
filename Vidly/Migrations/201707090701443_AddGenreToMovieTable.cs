namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreToMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Movies", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "NumberInStock");
            DropTable("dbo.Genres");
        }
    }
}
