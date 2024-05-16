using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    /// <inheritdoc />
    public partial class AdjustmentsII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Assignments_WorkUnitWorkOrderId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_WorkUnitWorkOrderId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "WorkUnitWorkOrderId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "WorkOrderId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "WorkServices",
                columns: table => new
                {
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkServices", x => new { x.WorkOrderId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_WorkServices_Assignments_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "Assignments",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkServices_ServiceId",
                table: "WorkServices",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkServices");

            migrationBuilder.AddColumn<int>(
                name: "WorkUnitWorkOrderId",
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
                name: "IX_Services_WorkUnitWorkOrderId",
                table: "Services",
                column: "WorkUnitWorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Assignments_WorkUnitWorkOrderId",
                table: "Services",
                column: "WorkUnitWorkOrderId",
                principalTable: "Assignments",
                principalColumn: "WorkOrderId");
        }
    }
}
