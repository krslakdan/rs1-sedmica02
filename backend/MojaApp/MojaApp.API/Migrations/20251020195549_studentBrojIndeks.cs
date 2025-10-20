using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MojaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class studentBrojIndeks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Broj_indeksa",
                table: "Students",
                newName: "BrojIndeksa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrojIndeksa",
                table: "Students",
                newName: "Broj_indeksa");
        }
    }
}
