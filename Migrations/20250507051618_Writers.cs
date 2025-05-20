using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SUFEEASP.Migrations
{
    /// <inheritdoc />
    public partial class Writers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Writer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imgurl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Famous = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewMore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writer", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Writer");
        }
    }
}
