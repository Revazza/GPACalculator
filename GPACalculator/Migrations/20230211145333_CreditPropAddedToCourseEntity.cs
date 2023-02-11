using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPACalculator.Migrations
{
    /// <inheritdoc />
    public partial class CreditPropAddedToCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Credit",
                table: "Courses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credit",
                table: "Courses");
        }
    }
}
