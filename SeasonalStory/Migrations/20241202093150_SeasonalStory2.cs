using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonalStory.Migrations
{
    /// <inheritdoc />
    public partial class SeasonalStory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Billede",
                table: "Photos",
                newName: "UploadedImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedImage",
                table: "Photos",
                newName: "Billede");
        }
    }
}
