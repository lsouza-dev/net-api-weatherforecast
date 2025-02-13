using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
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
        [Column("ICON")] public string Icon {  get; set; }
        [Column("PREVISAO_MM")] public double PrevisaoMm{ get; set; }
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
    }
}
