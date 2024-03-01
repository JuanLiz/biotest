using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biotest.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalysisType",
                columns: table => new
                {
                    AnalysisTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisType", x => x.AnalysisTypeID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeePosition",
                columns: table => new
                {
                    EmployeePositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePosition", x => x.EmployeePositionID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "GeneticTestType",
                columns: table => new
                {
                    GeneticTestTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticTestType", x => x.GeneticTestTypeID);
                });

            migrationBuilder.CreateTable(
                name: "GeneticVariantType",
                columns: table => new
                {
                    GeneticVariantTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticVariantType", x => x.GeneticVariantTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Genotype",
                columns: table => new
                {
                    GenotypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genotype", x => x.GenotypeID);
                });

            migrationBuilder.CreateTable(
                name: "PredictedEffect",
                columns: table => new
                {
                    PredictedEffectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictedEffect", x => x.PredictedEffectID);
                });

            migrationBuilder.CreateTable(
                name: "SampleSource",
                columns: table => new
                {
                    SampleSourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleSource", x => x.SampleSourceID);
                });

            migrationBuilder.CreateTable(
                name: "SampleType",
                columns: table => new
                {
                    SampleTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleType", x => x.SampleTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    EmployeePositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeePosition_EmployeePositionID",
                        column: x => x.EmployeePositionID,
                        principalTable: "EmployeePosition",
                        principalColumn: "EmployeePositionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patient_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneticVariant",
                columns: table => new
                {
                    GeneticVariantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneticVariantTypeID = table.Column<int>(type: "int", nullable: false),
                    AnalysisID = table.Column<int>(type: "int", nullable: false),
                    GenotypeID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredictedEffectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticVariant", x => x.GeneticVariantID);
                    table.ForeignKey(
                        name: "FK_GeneticVariant_AnalysisType_AnalysisID",
                        column: x => x.AnalysisID,
                        principalTable: "AnalysisType",
                        principalColumn: "AnalysisTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticVariant_GeneticVariantType_GeneticVariantTypeID",
                        column: x => x.GeneticVariantTypeID,
                        principalTable: "GeneticVariantType",
                        principalColumn: "GeneticVariantTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticVariant_Genotype_GenotypeID",
                        column: x => x.GenotypeID,
                        principalTable: "Genotype",
                        principalColumn: "GenotypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticVariant_PredictedEffect_PredictedEffectID",
                        column: x => x.PredictedEffectID,
                        principalTable: "PredictedEffect",
                        principalColumn: "PredictedEffectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sample",
                columns: table => new
                {
                    SampleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleTypeID = table.Column<int>(type: "int", nullable: false),
                    SampleSourceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sample", x => x.SampleID);
                    table.ForeignKey(
                        name: "FK_Sample_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sample_SampleSource_SampleSourceID",
                        column: x => x.SampleSourceID,
                        principalTable: "SampleSource",
                        principalColumn: "SampleSourceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sample_SampleType_SampleTypeID",
                        column: x => x.SampleTypeID,
                        principalTable: "SampleType",
                        principalColumn: "SampleTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneticTest",
                columns: table => new
                {
                    GeneticTestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneticTestTypeID = table.Column<int>(type: "int", nullable: false),
                    SampleID = table.Column<int>(type: "int", nullable: true),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneticTest", x => x.GeneticTestID);
                    table.ForeignKey(
                        name: "FK_GeneticTest_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticTest_GeneticTestType_GeneticTestTypeID",
                        column: x => x.GeneticTestTypeID,
                        principalTable: "GeneticTestType",
                        principalColumn: "GeneticTestTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneticTest_Sample_SampleID",
                        column: x => x.SampleID,
                        principalTable: "Sample",
                        principalColumn: "SampleID");
                });

            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    AnalysisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnalysisTypeID = table.Column<int>(type: "int", nullable: false),
                    GeneticTestID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Results = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.AnalysisID);
                    table.ForeignKey(
                        name: "FK_Analysis_AnalysisType_AnalysisTypeID",
                        column: x => x.AnalysisTypeID,
                        principalTable: "AnalysisType",
                        principalColumn: "AnalysisTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Analysis_GeneticTest_GeneticTestID",
                        column: x => x.GeneticTestID,
                        principalTable: "GeneticTest",
                        principalColumn: "GeneticTestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_AnalysisTypeID",
                table: "Analysis",
                column: "AnalysisTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_GeneticTestID",
                table: "Analysis",
                column: "GeneticTestID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeePositionID",
                table: "Employee",
                column: "EmployeePositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderID",
                table: "Employee",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticTest_EmployeeID",
                table: "GeneticTest",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticTest_GeneticTestTypeID",
                table: "GeneticTest",
                column: "GeneticTestTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticTest_SampleID",
                table: "GeneticTest",
                column: "SampleID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticVariant_AnalysisID",
                table: "GeneticVariant",
                column: "AnalysisID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticVariant_GeneticVariantTypeID",
                table: "GeneticVariant",
                column: "GeneticVariantTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticVariant_GenotypeID",
                table: "GeneticVariant",
                column: "GenotypeID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneticVariant_PredictedEffectID",
                table: "GeneticVariant",
                column: "PredictedEffectID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderID",
                table: "Patient",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_PatientID",
                table: "Sample",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SampleSourceID",
                table: "Sample",
                column: "SampleSourceID");

            migrationBuilder.CreateIndex(
                name: "IX_Sample_SampleTypeID",
                table: "Sample",
                column: "SampleTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "GeneticVariant");

            migrationBuilder.DropTable(
                name: "GeneticTest");

            migrationBuilder.DropTable(
                name: "AnalysisType");

            migrationBuilder.DropTable(
                name: "GeneticVariantType");

            migrationBuilder.DropTable(
                name: "Genotype");

            migrationBuilder.DropTable(
                name: "PredictedEffect");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "GeneticTestType");

            migrationBuilder.DropTable(
                name: "Sample");

            migrationBuilder.DropTable(
                name: "EmployeePosition");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "SampleSource");

            migrationBuilder.DropTable(
                name: "SampleType");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
