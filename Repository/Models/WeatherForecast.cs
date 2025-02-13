using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class WeatherForecast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CIDADE")] public string Cidade { get; set; }
        [Column("ESTADO")] public string Estado { get; set; }
        [Column("PAIS")] public string Pais { get; set; }
        [Column("DATA_LOCAL")] public DateTime DataLocal { get; set; }
        [Column("ULTIMA_ATUALIZACAO")] public DateTime UltimaAtualizacao { get; set; }
        [Column("TEMP_C")] public double TempC { get; set; }
        [Column("TEMP_F")] public double TemF { get; set; }
        [Column("SENSACAO_TERMICA_C")] public double SensacaoTermicaC { get; set; }
        [Column("SENSACAO_TERMICA_F")] public double SensacaoTermicaF { get; set; }
        [Column("UMIDADE")] public int Umidade { get; set; }
        [Column("NASCER_DO_SOL")] public TimeOnly NascerDoSol { get; set; }
        [Column("POR_DO_SOL")] public TimeOnly PorDoSol { get; set; }
        [Column("NASCER_DA_LUA")] public TimeOnly NascerDaLua { get; set; }
        [Column("POR_DA_LUA")] public TimeOnly PorDaLua { get; set; }
        [Column("FASE_DA_LUA")] public string FaseDaLua { get; set; }
        [Column("ESTA_DE_DIA")] public int EstaDeDia { get; set; }
        [Column("ESTA_DE_NOITE")] public int EstaDeNoite{ get; set; }
        [Column("CONDICAO_CEU")] public string CondicaoCeu { get; set; }
        [Column("ICON")] public string Icon { get; set; }
        public ICollection<ForecastDay> Forecasts { get; set; }

    }
}