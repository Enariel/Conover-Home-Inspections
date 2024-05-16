using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentsIV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SKU",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Groups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Details",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Details");

            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
