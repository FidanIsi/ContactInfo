using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P335_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class newvm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "ContactInfo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "ContactInfo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
