using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archysoft.Data.Migrations
{
    public partial class AddSkillsAndLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "UserProfiles",
                type: "image",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "UserProfiles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileLanguage",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(nullable: false),
                    LanguageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileLanguage", x => new { x.UserProfileId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UserProfileLanguage_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileLanguage_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileSkill",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(nullable: false),
                    SkillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileSkill", x => new { x.UserProfileId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserProfileSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileSkill_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileLanguage_LanguageId",
                table: "UserProfileLanguage",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkill_SkillId",
                table: "UserProfileSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileLanguage");

            migrationBuilder.DropTable(
                name: "UserProfileSkill");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "image",
                oldNullable: true);
        }
    }
}
