using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PubLog.Migrations
{
    /// <inheritdoc />
    public partial class AddPubExternalLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GooglePlaceId",
                table: "Pubs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripAdvisorUrl",
                table: "Pubs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GooglePlaceId",
                table: "Pubs");

            migrationBuilder.DropColumn(
                name: "TripAdvisorUrl",
                table: "Pubs");
        }
    }
}
