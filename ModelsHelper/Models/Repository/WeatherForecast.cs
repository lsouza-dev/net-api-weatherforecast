using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsHelper.Models.Repository
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
        [Column("TEMP_F")] public double TempF { get; set; }
        [Column("SENSACAO_TERMICA_C")] public double SensacaoTermicaC { get; set; }
        [Column("SENSACAO_TERMICA_F")] public double SensacaoTermicaF { get; set; }
        [Column("UMIDADE")] public int Umidade { get; set; }
        [Column("NASCER_DO_SOL")] public TimeOnly NascerDoSol { get; set; }
        [Column("POR_DO_SOL")] public TimeOnly PorDoSol { get; set; }
        [Column("NASCER_DA_LUA")] public TimeOnly NascerDaLua { get; set; }
        [Column("POR_DA_LUA")] public TimeOnly PorDaLua { get; set; }
        [Column("FASE_DA_LUA")] public string FaseDaLua { get; set; }
        [Column("ESTA_DE_DIA")] public int EstaDeDia { get; set; }
        [Column("ESTA_DE_NOITE")] public int EstaDeNoite { get; set; }
        [Column("CONDICAO_CEU")] public string CondicaoCeu { get; set; }
        [Column("ICON")] public string Icon { get; set; }
        public ICollection<ForecastDay> Forecasts { get; set; }


        public WeatherForecast() { }
        public WeatherForecast(WeatherForecastDTO dto)
        {
            Cidade = dto.Cidade;
            Estado = dto.Estado;
            Pais = dto.Pais;
            DataLocal = dto.DataLocal;
            UltimaAtualizacao = dto.UltimaAtualizacao;
            TempC = dto.TempC;
            TempF = dto.TempF;
            SensacaoTermicaC = dto.SensacaoTermicaC;
            SensacaoTermicaF = dto.SensacaoTermicaF;
            Umidade = dto.Umidade;
            NascerDoSol = dto.NascerDoSol;
            PorDoSol = dto.PorDoSol;
            NascerDaLua = dto.NascerDaLua;
            PorDaLua = dto.PorDaLua;
            FaseDaLua = dto.FaseDaLua;
            EstaDeDia = dto.EstaDeDia;
            EstaDeNoite = dto.EstaDeNoite;
            CondicaoCeu = dto.CondicaoCeu;
            Icon = dto.Icon;
            Forecasts = dto.Forecasts.Select(f => new ForecastDay(f)).ToList();
        }

        public WeatherForecast(int id, string cidade, string estado, string pais, DateTime dataLocal, DateTime ultimaAtualizacao,
        double tempC, double tempF, double sensacaoTermicaC, double sensacaoTermicaF, int umidade, TimeOnly nascerDoSol,
        TimeOnly porDoSol, TimeOnly nascerDaLua, TimeOnly porDaLua, string faseDaLua, int estaDeDia, int estaDeNoite,
        string condicaoCeu, string icon)
        {
            Id = id;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            DataLocal = dataLocal;
            UltimaAtualizacao = ultimaAtualizacao;
            TempC = tempC;
            TempF = tempF;
            SensacaoTermicaC = sensacaoTermicaC;
            SensacaoTermicaF = sensacaoTermicaF;
            Umidade = umidade;
            NascerDoSol = nascerDoSol;
            PorDoSol = porDoSol;
            NascerDaLua = nascerDaLua;
            PorDaLua = porDaLua;
            FaseDaLua = faseDaLua;
            EstaDeDia = estaDeDia;
            EstaDeNoite = estaDeNoite;
            CondicaoCeu = condicaoCeu;
            Icon = icon;
            Forecasts = new List<ForecastDay>(); // Inicializa a lista vazia
        }

        public override string ToString()
        {
            string forecastsString = string.Join("\n", Forecasts.Select(f => f.ToString()));
            return $"WeatherForecast: [Cidade: {Cidade}, Estado: {Estado}, Pais: {Pais}, DataLocal: {DataLocal}, " +
                   $"UltimaAtualizacao: {UltimaAtualizacao}, TempC: {TempC}°C, TempF: {TempF}°F, " +
                   $"SensacaoTermicaC: {SensacaoTermicaC}°C, SensacaoTermicaF: {SensacaoTermicaF}°F, Umidade: {Umidade}%, " +
                   $"NascerDoSol: {NascerDoSol}, PorDoSol: {PorDoSol}, NascerDaLua: {NascerDaLua}, PorDaLua: {PorDaLua}, " +
                   $"FaseDaLua: {FaseDaLua}, EstaDeDia: {EstaDeDia}, EstaDeNoite: {EstaDeNoite}, CondicaoCeu: {CondicaoCeu}, " +
                   $"Icon: {Icon}, Forecasts: [\n{forecastsString}\n]]";
        }
    }
}