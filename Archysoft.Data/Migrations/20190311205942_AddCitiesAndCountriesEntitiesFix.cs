using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Archysoft.Data.Migrations
{
    public partial class AddCitiesAndCountriesEntitiesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "UserProfiles",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "UserProfiles",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Cities_CityId",
                table: "UserProfiles",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
