using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biotest.Migrations
{
    /// <inheritdoc />
    public partial class ChangeResultsColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "GeneticTest",
                newName: "Results");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Results",
                table: "GeneticTest",
                newName: "Result");
        }
    }
}
