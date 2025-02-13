using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlteraTabelaWeathersRemoveIdForecastAlteraTabelaForecastsDayRelacionandoFKIdWeatherForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForecastsDays_Weathers_WeatherForecastId",
                table: "ForecastsDays");

            migrationBuilder.DropIndex(
                name: "IX_ForecastsDays_WeatherForecastId",
                table: "ForecastsDays");

            migrationBuilder.DropColumn(
                name: "ID_FORECAST",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "WeatherForecastId",
                table: "ForecastsDays");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastsDays_ID_WEATHERFORECAST",
                table: "ForecastsDays",
                column: "ID_WEATHERFORECAST");

            migrationBuilder.AddForeignKey(
                name: "FK_ForecastsDays_Weathers_ID_WEATHERFORECAST",
                table: "ForecastsDays",
                column: "ID_WEATHERFORECAST",
                principalTable: "Weathers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForecastsDays_Weathers_ID_WEATHERFORECAST",
                table: "ForecastsDays");

            migrationBuilder.DropIndex(
                name: "IX_ForecastsDays_ID_WEATHERFORECAST",
                table: "ForecastsDays");

            migrationBuilder.AddColumn<int>(
                name: "ID_FORECAST",
                table: "Weathers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeatherForecastId",
                table: "ForecastsDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ForecastsDays_WeatherForecastId",
                table: "ForecastsDays",
                column: "WeatherForecastId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForecastsDays_Weathers_WeatherForecastId",
                table: "ForecastsDays",
                column: "WeatherForecastId",
                principalTable: "Weathers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
