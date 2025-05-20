using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUFEEASP.Migrations
{
    /// <inheritdoc />
    public partial class qawwalis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poet");

            migrationBuilder.CreateTable(
                name: "Qawwali",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poetname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtubeurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lyrics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qawwali", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qawwali");

            migrationBuilder.CreateTable(
                name: "Poet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poettype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poet", x => x.ID);
                });
        }
    }
}
