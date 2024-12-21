using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assessment.Models.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversionHistories_ConversionRates_UnitConversionRatesId",
                table: "ConversionHistories");

            migrationBuilder.DropTable(
                name: "ConversionRates");

            migrationBuilder.DropIndex(
                name: "IX_ConversionHistories_UnitConversionRatesId",
                table: "ConversionHistories");

            migrationBuilder.DropColumn(
                name: "UnitConversionRatesId",
                table: "ConversionHistories");

            migrationBuilder.AddColumn<double>(
                name: "NumberOfBaseUnits",
                table: "UnitDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DerivedFactor",
                table: "ConversionHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SourceUnitName",
                table: "ConversionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TargetUnitName",
                table: "ConversionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "ConversionHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfBaseUnits",
                table: "UnitDetails");

            migrationBuilder.DropColumn(
                name: "DerivedFactor",
                table: "ConversionHistories");

            migrationBuilder.DropColumn(
                name: "SourceUnitName",
                table: "ConversionHistories");

            migrationBuilder.DropColumn(
                name: "TargetUnitName",
                table: "ConversionHistories");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "ConversionHistories");

            migrationBuilder.AddColumn<int>(
                name: "UnitConversionRatesId",
                table: "ConversionHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConversionHistories_ConversionRates_UnitConversionRatesId",
                table: "ConversionHistories",
                column: "UnitConversionRatesId",
                principalTable: "ConversionRates",
                principalColumn: "UnitConversionRatesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
