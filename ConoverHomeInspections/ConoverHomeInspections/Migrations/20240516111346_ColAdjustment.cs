using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    /// <inheritdoc />
    public partial class ColAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Groups_GroupId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Groups_ProductGroupGroupId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ProductGroupGroupId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ProductGroupGroupId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Services",
                table: "Services",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Services",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupGroupId",
                table: "Services",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_ProductGroupGroupId",
                table: "Services",
                column: "ProductGroupGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Groups_GroupId",
                table: "Services",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Groups_ProductGroupGroupId",
                table: "Services",
                column: "ProductGroupGroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");
        }
    }
}
