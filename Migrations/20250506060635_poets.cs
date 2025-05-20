using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUFEEASP.Migrations
{
    /// <inheritdoc />
    public partial class poets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blogimg1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paragraph1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Paragraph2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blogimg2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ebook",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imgurl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Booklink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ebook", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Myusers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Myusers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Poet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poettype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poet", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Ebook");

            migrationBuilder.DropTable(
                name: "Myusers");

            migrationBuilder.DropTable(
                name: "Poet");
        }
    }
}
