using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectPortfolio.Model.Migrations
{
    public partial class ProjectAddFormattedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormattedDescription",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormattedDescription",
                table: "Projects");
        }
    }
}
