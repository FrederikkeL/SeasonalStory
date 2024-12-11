using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeasonalStory.Migrations
{
    /// <inheritdoc />
    public partial class SeasonalStory4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateAdded",
                table: "Photos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Photos");
        }
    }
}
