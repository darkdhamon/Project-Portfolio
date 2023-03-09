using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPortfolio.Model.Migrations
{
    public partial class ProjectEndDateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag");

            migrationBuilder.RenameTable(
                name: "ProjectTag",
                newName: "ProjectTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTag_ProjectId",
                table: "ProjectTags",
                newName: "IX_ProjectTags_ProjectId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTags",
                table: "ProjectTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTags_Projects_ProjectId",
                table: "ProjectTags",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTags_Projects_ProjectId",
                table: "ProjectTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTags",
                table: "ProjectTags");

            migrationBuilder.RenameTable(
                name: "ProjectTags",
                newName: "ProjectTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTags_ProjectId",
                table: "ProjectTag",
                newName: "IX_ProjectTag_ProjectId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTag",
                table: "ProjectTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTag_Projects_ProjectId",
                table: "ProjectTag",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
