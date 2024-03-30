using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nzwalks.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Difficulties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Difficulties",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Difficulties",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Difficulties",
                newName: "id");
        }
    }
}
