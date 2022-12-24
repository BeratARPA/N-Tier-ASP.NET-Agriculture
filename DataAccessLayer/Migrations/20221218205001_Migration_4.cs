using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_socialMedias",
                table: "socialMedias");

            migrationBuilder.DropColumn(
                name: "Description1",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "socialMedias",
                newName: "SocialMedias");

            migrationBuilder.RenameColumn(
                name: "Description4",
                table: "Addresses",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Description3",
                table: "Addresses",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Description2",
                table: "Addresses",
                newName: "Description");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias",
                column: "SocialMediaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialMedias",
                table: "SocialMedias");

            migrationBuilder.RenameTable(
                name: "SocialMedias",
                newName: "socialMedias");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Addresses",
                newName: "Description4");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Addresses",
                newName: "Description3");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Addresses",
                newName: "Description2");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_socialMedias",
                table: "socialMedias",
                column: "SocialMediaId");
        }
    }
}
