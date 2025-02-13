using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlteraTabelaWeathersCriaTabelaForecastsDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Weathers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Weathers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TemperatureC",
                table: "Weathers",
                newName: "UMIDADE");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Weathers",
                newName: "ULTIMA_ATUALIZACAO");

            migrationBuilder.AddColumn<string>(
                name: "CIDADE",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CONDICAO_CEU",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_LOCAL",
                table: "Weathers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ESTADO",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ESTA_DE_DIA",
                table: "Weathers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ESTA_DE_NOITE",
                table: "Weathers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FASE_DA_LUA",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ICON",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ID_FORECAST",
                table: "Weathers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "NASCER_DA_LUA",
                table: "Weathers",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "NASCER_DO_SOL",
                table: "Weathers",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "PAIS",
                table: "Weathers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "POR_DA_LUA",
                table: "Weathers",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "POR_DO_SOL",
                table: "Weathers",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "SENSACAO_TERMICA_C",
                table: "Weathers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SENSACAO_TERMICA_F",
                table: "Weathers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_C",
                table: "Weathers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TEMP_F",
                table: "Weathers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "ForecastsDays",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DATA = table.Column<DateOnly>(type: "date", nullable: false),
                    HORARIO = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TEMP_C = table.Column<double>(type: "double", nullable: false),
                    TEMP_F = table.Column<double>(type: "double", nullable: false),
                    CONDICAO_CEU = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ICON = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PREVISAO_MM = table.Column<double>(type: "double", nullable: false),
                    NEVE_CM = table.Column<double>(type: "double", nullable: false),
                    UMIDADE = table.Column<int>(type: "int", nullable: false),
                    NEBULOSIDADE = table.Column<int>(type: "int", nullable: false),
                    SENSACAO_TERMICA_C = table.Column<double>(type: "double", nullable: false),
                    SENSACAO_TERMICA_F = table.Column<double>(type: "double", nullable: false),
                    VAI_HOVER = table.Column<int>(type: "int", nullable: false),
                    CHANDE_DE_CHUVA = table.Column<int>(type: "int", nullable: false),
                    VAI_NEVAR = table.Column<int>(type: "int", nullable: false),
                    CHANCE_DE_NEVE = table.Column<int>(type: "int", nullable: false),
                    ID_WEATHERFORECAST = table.Column<int>(type: "int", nullable: false),
                    WeatherForecastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastsDays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ForecastsDays_Weathers_WeatherForecastId",
                        column: x => x.WeatherForecastId,
                        principalTable: "Weathers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ForecastsDays_WeatherForecastId",
                table: "ForecastsDays",
                column: "WeatherForecastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ForecastsDays");

            migrationBuilder.DropColumn(
                name: "CIDADE",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "CONDICAO_CEU",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "DATA_LOCAL",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ESTADO",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ESTA_DE_DIA",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ESTA_DE_NOITE",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "FASE_DA_LUA",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ICON",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "ID_FORECAST",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "NASCER_DA_LUA",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "NASCER_DO_SOL",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "PAIS",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "POR_DA_LUA",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "POR_DO_SOL",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "SENSACAO_TERMICA_C",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "SENSACAO_TERMICA_F",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "TEMP_C",
                table: "Weathers");

            migrationBuilder.DropColumn(
                name: "TEMP_F",
                table: "Weathers");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Weathers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UMIDADE",
                table: "Weathers",
                newName: "TemperatureC");

            migrationBuilder.RenameColumn(
                name: "ULTIMA_ATUALIZACAO",
                table: "Weathers",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Weathers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
