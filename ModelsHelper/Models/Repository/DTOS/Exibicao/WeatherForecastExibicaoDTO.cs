using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsHelper.Models.Repository.DTOS.Exibicao
{
    public record WeatherForecastExibicaoDTO
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public DateTime DataLocal { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public double SensacaoTermicaC { get; set; }
        public double SensacaoTermicaF { get; set; }
        public int Umidade { get; set; }
        public TimeOnly NascerDoSol { get; set; }
        public TimeOnly PorDoSol { get; set; }
        public TimeOnly NascerDaLua { get; set; }
        public TimeOnly PorDaLua { get; set; }
        public string FaseDaLua { get; set; }
        public int EstaDeDia { get; set; }
        public int EstaDeNoite { get; set; }
        public string CondicaoCeu { get; set; }
        public string Icon { get; set; }
        public List<ForecastDayExibicaoDTO> Forecasts { get; set; }

        public WeatherForecastExibicaoDTO(WeatherForecast weatherForecast)
        {
            Cidade = weatherForecast.Cidade;
            Estado = weatherForecast.Estado;
            Pais = weatherForecast.Pais;
            DataLocal = weatherForecast.DataLocal;
            UltimaAtualizacao = weatherForecast.UltimaAtualizacao;
            TempC = weatherForecast.TempC;
            TempF = weatherForecast.TemF;
            SensacaoTermicaC = weatherForecast.SensacaoTermicaC;
            SensacaoTermicaF = weatherForecast.SensacaoTermicaF;
            Umidade = weatherForecast.Umidade;
            NascerDoSol = weatherForecast.NascerDoSol;
            PorDoSol = weatherForecast.PorDoSol;
            NascerDaLua = weatherForecast.NascerDaLua;
            PorDaLua = weatherForecast.PorDaLua;
            FaseDaLua = weatherForecast.FaseDaLua;
            EstaDeDia = weatherForecast.EstaDeDia;
            EstaDeNoite = weatherForecast.EstaDeNoite;
            CondicaoCeu = weatherForecast.CondicaoCeu;
            Icon = weatherForecast.Icon;
            Forecasts = weatherForecast.Forecasts?.Select(f => new ForecastDayExibicaoDTO(f)).ToList();
        }

        public WeatherForecastExibicaoDTO() { }
    }
}
