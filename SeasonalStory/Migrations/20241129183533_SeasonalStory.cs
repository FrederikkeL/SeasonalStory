using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonalStory.Migrations
{
    /// <inheritdoc />
    public partial class SeasonalStory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoSeason = table.Column<int>(type: "int", nullable: false),
                    PhotoTemp = table.Column<int>(type: "int", nullable: false),
                    Billede = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");
        }
    }
}
