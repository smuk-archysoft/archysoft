using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archysoft.Data.Migrations
{
    public partial class AddEducationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    School = table.Column<string>(maxLength: 255, nullable: false),
                    YearAttendedFrom = table.Column<int>(nullable: false),
                    YearAttendedTo = table.Column<int>(nullable: false),
                    Degree = table.Column<string>(maxLength: 255, nullable: true),
                    UserProfileId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserProfileId",
                table: "Educations",
                column: "UserProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");
        }
    }
}
