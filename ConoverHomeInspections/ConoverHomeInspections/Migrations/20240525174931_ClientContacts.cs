using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConoverHomeInspections.Migrations
{
    /// <inheritdoc />
    public partial class ClientContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AssignmentId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    NamePrefix = table.Column<string>(type: "TEXT", nullable: true),
                    NameSuffix = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleInitial = table.Column<char>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PrefersEmail = table.Column<bool>(type: "INTEGER", nullable: false),
                    PrefersPhone = table.Column<bool>(type: "INTEGER", nullable: false),
                    PrefersText = table.Column<bool>(type: "INTEGER", nullable: false),
                    RealtorFirstName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    RealtorLastName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    RealtorEmail = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    RealtorPhone = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: true),
                    GroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    PreferredStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PreferredEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    InspectionAddress = table.Column<string>(type: "TEXT", nullable: true),
                    MailingAddress = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RemovedOn = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_ClientContacts_Group",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_ClientContacts_Service",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_GroupId",
                table: "ClientContacts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ServiceId",
                table: "ClientContacts",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientContacts");

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
