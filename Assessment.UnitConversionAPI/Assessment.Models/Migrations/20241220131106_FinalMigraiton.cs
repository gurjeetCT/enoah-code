using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Models.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigraiton : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitTypes",
                columns: table => new
                {
                    UnitTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitTypes", x => x.UnitTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UnitDetails",
                columns: table => new
                {
                    UnitDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitDetails", x => x.UnitDetailsId);
                    table.ForeignKey(
                        name: "FK_UnitDetails_UnitTypes_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitTypes",
                        principalColumn: "UnitTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversionRates",
                columns: table => new
                {
                    UnitConversionRatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUnitDetailsId = table.Column<int>(type: "int", nullable: false),
                    TargetUnitDetailsId = table.Column<int>(type: "int", nullable: false),
                    ConversionFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionRates", x => x.UnitConversionRatesId);
                    table.ForeignKey(
                        name: "FK_ConversionRates_UnitDetails_SourceUnitDetailsId",
                        column: x => x.SourceUnitDetailsId,
                        principalTable: "UnitDetails",
                        principalColumn: "UnitDetailsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConversionRates_UnitDetails_TargetUnitDetailsId",
                        column: x => x.TargetUnitDetailsId,
                        principalTable: "UnitDetails",
                        principalColumn: "UnitDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConversionHistories",
                columns: table => new
                {
                    ConversionHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitConversionRatesId = table.Column<int>(type: "int", nullable: false),
                    InputValue = table.Column<double>(type: "float", nullable: false),
                    OutputValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversionHistories", x => x.ConversionHistoryId);
                    table.ForeignKey(
                        name: "FK_ConversionHistories_ConversionRates_UnitConversionRatesId",
                        column: x => x.UnitConversionRatesId,
                        principalTable: "ConversionRates",
                        principalColumn: "UnitConversionRatesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversionHistories_UnitConversionRatesId",
                table: "ConversionHistories",
                column: "UnitConversionRatesId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversionRates_SourceUnitDetailsId",
                table: "ConversionRates",
                column: "SourceUnitDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConversionRates_TargetUnitDetailsId",
                table: "ConversionRates",
                column: "TargetUnitDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitDetails_UnitTypeId",
                table: "UnitDetails",
                column: "UnitTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversionHistories");

            migrationBuilder.DropTable(
                name: "ConversionRates");

            migrationBuilder.DropTable(
                name: "UnitDetails");

            migrationBuilder.DropTable(
                name: "UnitTypes");
        }
    }
}
