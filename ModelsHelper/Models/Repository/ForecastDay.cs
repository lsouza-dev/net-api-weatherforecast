using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace ModelsHelper.Models.Repository
{
    public class ForecastDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")] public int Id { get; set; }
        [Column("DATA")] public DateOnly Data { get; set; }
        [Column("HORARIO")] public string Horario { get; set; }
        [Column("TEMP_C")] public double TempC { get; set; }
        [Column("TEMP_F")] public double TempF { get; set; }
        [Column("CONDICAO_CEU")] public string CondicaoCeu { get; set; }
        [Column("ICON")] public string Icon { get; set; }
        [Column("PREVISAO_MM")] public double PrevisaoMm { get; set; }
        [Column("NEVE_CM")] public double NeveCm { get; set; }
        [Column("UMIDADE")] public int Umidade { get; set; }
        [Column("NEBULOSIDADE")] public int Nebulosidade { get; set; }
        [Column("SENSACAO_TERMICA_C")] public double SensacaoTermicaC { get; set; }
        [Column("SENSACAO_TERMICA_F")] public double SensacaoTermicaF { get; set; }
        [Column("VAI_HOVER")] public int VaiChover { get; set; }
        [Column("CHANDE_DE_CHUVA")] public int ChanceChuva { get; set; }
        [Column("VAI_NEVAR")] public int VaiNevar { get; set; }
        [Column("CHANCE_DE_NEVE")] public int ChanceNeve { get; set; }
        [Column("ID_WEATHERFORECAST")] public int IdWeatherForecast { get; set; }
        public WeatherForecast WeatherForecast { get; set; }

        public ForecastDay() { }

        public ForecastDay(ForecastDayDTO dto)
        {
            Data = DateOnly.ParseExact(dto.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Horario = dto.Hour.time;
            TempC = dto.Hour.temp_c;
            TempF = dto.Hour.temp_f;
            CondicaoCeu = dto.Hour.condition.text;
            Icon = dto.Day.condition.icon; // Ou alguma propriedade relevante
            PrevisaoMm = dto.Hour.precip_mm;
            NeveCm = dto.Hour.snow_cm;
            Umidade = dto.Hour.humidity;
            Nebulosidade = dto.Hour.cloud;
            SensacaoTermicaC = dto.Hour.feelslike_c;
            SensacaoTermicaF = dto.Hour.feelslike_f;
            VaiChover = dto.Hour.will_it_rain;
            ChanceChuva = dto.Hour.chance_of_rain;
            VaiNevar = dto.Hour.will_it_snow;
            ChanceNeve = dto.Hour.chance_of_snow;
        }

        public override string ToString()
        {
            return $"ForecastDay: [Data: {Data}, Horario: {Horario}, TempC: {TempC}°C, TempF: {TempF}°F, " +
                   $"CondicaoCeu: {CondicaoCeu}, Icon: {Icon}, PrevisaoMm: {PrevisaoMm}mm, NeveCm: {NeveCm}cm, " +
                   $"Umidade: {Umidade}%, Nebulosidade: {Nebulosidade}, SensacaoTermicaC: {SensacaoTermicaC}°C, " +
                   $"SensacaoTermicaF: {SensacaoTermicaF}°F, VaiChover: {VaiChover}, ChanceChuva: {ChanceChuva}%, " +
                   $"VaiNevar: {VaiNevar}, ChanceNeve: {ChanceNeve}%]";
        }
    }
}