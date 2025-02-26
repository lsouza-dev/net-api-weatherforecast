using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ModelsHelper.Models.Repository.DTOS.Exibicao
{
    public record WeatherForecastExibicaoDTO
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string DataLocal { get; set; }
        public string UltimaAtualizacao { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public double SensacaoTermicaC { get; set; }
        public double SensacaoTermicaF { get; set; }
        public int Umidade { get; set; }
        public string NascerDoSol { get; set; }
        public string PorDoSol { get; set; }
        public string NascerDaLua { get; set; }
        public string PorDaLua { get; set; }
        public string FaseDaLua { get; set; }
        public int EstaDeDia { get; set; }
        public int EstaDeNoite { get; set; }
        public string CondicaoCeu { get; set; }
        public string Icon { get; set; }
        public List<ForecastDayExibicaoDTO> Forecasts { get; set; }

        public WeatherForecastExibicaoDTO(WeatherForecast weatherForecast)
        {
            var culturaPtBr = CultureInfo.GetCultureInfo("pt-BR");

            Cidade = weatherForecast.Cidade;
            Estado = weatherForecast.Estado;
            Pais = weatherForecast.Pais;
            DataLocal = weatherForecast.DataLocal.ToString("dd/MM/yyyy HH:mm:ss", culturaPtBr);
            UltimaAtualizacao = weatherForecast.UltimaAtualizacao.ToString("dd/MM/yyyy HH:mm:ss", culturaPtBr);
            TempC = weatherForecast.TempC;
            TempF = weatherForecast.TempF;
            SensacaoTermicaC = weatherForecast.SensacaoTermicaC;
            SensacaoTermicaF = weatherForecast.SensacaoTermicaF;
            Umidade = weatherForecast.Umidade;
            NascerDoSol = weatherForecast.NascerDoSol.ToString("HH:mm");
            PorDoSol = weatherForecast.PorDoSol.ToString("HH:mm");
            NascerDaLua = weatherForecast.NascerDaLua.ToString("HH:mm");
            PorDaLua = weatherForecast.PorDaLua.ToString("HH:mm");
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
