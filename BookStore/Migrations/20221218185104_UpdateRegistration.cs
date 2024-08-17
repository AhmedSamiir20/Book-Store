using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "registrations",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "registrations",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "registrations",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "registrations",
                newName: "Address");
        }
    }
}
