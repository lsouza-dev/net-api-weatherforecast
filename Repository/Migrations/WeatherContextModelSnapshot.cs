﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Context;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ModelsHelper.Models.Repository.ForecastDay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int>("ChanceChuva")
                        .HasColumnType("int")
                        .HasColumnName("CHANDE_DE_CHUVA");

                    b.Property<int>("ChanceNeve")
                        .HasColumnType("int")
                        .HasColumnName("CHANCE_DE_NEVE");

                    b.Property<string>("CondicaoCeu")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CONDICAO_CEU");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date")
                        .HasColumnName("DATA");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("HORARIO");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ICON");

                    b.Property<int>("IdWeatherForecast")
                        .HasColumnType("int")
                        .HasColumnName("ID_WEATHERFORECAST");

                    b.Property<int>("Nebulosidade")
                        .HasColumnType("int")
                        .HasColumnName("NEBULOSIDADE");

                    b.Property<double>("NeveCm")
                        .HasColumnType("double")
                        .HasColumnName("NEVE_CM");

                    b.Property<double>("PrevisaoMm")
                        .HasColumnType("double")
                        .HasColumnName("PREVISAO_MM");

                    b.Property<double>("SensacaoTermicaC")
                        .HasColumnType("double")
                        .HasColumnName("SENSACAO_TERMICA_C");

                    b.Property<double>("SensacaoTermicaF")
                        .HasColumnType("double")
                        .HasColumnName("SENSACAO_TERMICA_F");

                    b.Property<double>("TempC")
                        .HasColumnType("double")
                        .HasColumnName("TEMP_C");

                    b.Property<double>("TempF")
                        .HasColumnType("double")
                        .HasColumnName("TEMP_F");

                    b.Property<int>("Umidade")
                        .HasColumnType("int")
                        .HasColumnName("UMIDADE");

                    b.Property<int>("VaiChover")
                        .HasColumnType("int")
                        .HasColumnName("VAI_HOVER");

                    b.Property<int>("VaiNevar")
                        .HasColumnType("int")
                        .HasColumnName("VAI_NEVAR");

                    b.HasKey("Id");

                    b.HasIndex("IdWeatherForecast");

                    b.ToTable("ForecastsDays");
                });

            modelBuilder.Entity("ModelsHelper.Models.Repository.WeatherForecast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CIDADE");

                    b.Property<string>("CondicaoCeu")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("CONDICAO_CEU");

                    b.Property<DateTime>("DataLocal")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DATA_LOCAL");

                    b.Property<int>("EstaDeDia")
                        .HasColumnType("int")
                        .HasColumnName("ESTA_DE_DIA");

                    b.Property<int>("EstaDeNoite")
                        .HasColumnType("int")
                        .HasColumnName("ESTA_DE_NOITE");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ESTADO");

                    b.Property<string>("FaseDaLua")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("FASE_DA_LUA");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ICON");

                    b.Property<TimeOnly>("NascerDaLua")
                        .HasColumnType("time(6)")
                        .HasColumnName("NASCER_DA_LUA");

                    b.Property<TimeOnly>("NascerDoSol")
                        .HasColumnType("time(6)")
                        .HasColumnName("NASCER_DO_SOL");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("PAIS");

                    b.Property<TimeOnly>("PorDaLua")
                        .HasColumnType("time(6)")
                        .HasColumnName("POR_DA_LUA");

                    b.Property<TimeOnly>("PorDoSol")
                        .HasColumnType("time(6)")
                        .HasColumnName("POR_DO_SOL");

                    b.Property<double>("SensacaoTermicaC")
                        .HasColumnType("double")
                        .HasColumnName("SENSACAO_TERMICA_C");

                    b.Property<double>("SensacaoTermicaF")
                        .HasColumnType("double")
                        .HasColumnName("SENSACAO_TERMICA_F");

                    b.Property<double>("TemF")
                        .HasColumnType("double")
                        .HasColumnName("TEMP_F");

                    b.Property<double>("TempC")
                        .HasColumnType("double")
                        .HasColumnName("TEMP_C");

                    b.Property<DateTime>("UltimaAtualizacao")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("ULTIMA_ATUALIZACAO");

                    b.Property<int>("Umidade")
                        .HasColumnType("int")
                        .HasColumnName("UMIDADE");

                    b.HasKey("Id");

                    b.ToTable("Weathers");
                });

            modelBuilder.Entity("ModelsHelper.Models.Repository.ForecastDay", b =>
                {
                    b.HasOne("ModelsHelper.Models.Repository.WeatherForecast", "WeatherForecast")
                        .WithMany("Forecasts")
                        .HasForeignKey("IdWeatherForecast")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeatherForecast");
                });

            modelBuilder.Entity("ModelsHelper.Models.Repository.WeatherForecast", b =>
                {
                    b.Navigation("Forecasts");
                });
#pragma warning restore 612, 618
        }
    }
}
