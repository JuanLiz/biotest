using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biotest.Migrations
{
    /// <inheritdoc />
    public partial class FixGeneticVariantFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneticVariant_AnalysisType_AnalysisID",
                table: "GeneticVariant");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneticVariant_Analysis_AnalysisID",
                table: "GeneticVariant",
                column: "AnalysisID",
                principalTable: "Analysis",
                principalColumn: "AnalysisID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneticVariant_Analysis_AnalysisID",
                table: "GeneticVariant");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneticVariant_AnalysisType_AnalysisID",
                table: "GeneticVariant",
                column: "AnalysisID",
                principalTable: "AnalysisType",
                principalColumn: "AnalysisTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
