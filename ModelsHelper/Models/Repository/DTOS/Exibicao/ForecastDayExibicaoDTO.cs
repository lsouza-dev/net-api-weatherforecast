using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsHelper.Models.Repository.DTOS.Exibicao
{
    public record ForecastDayExibicaoDTO
    {
        public DateOnly Data { get; set; }
        public string Horario { get; set; }
        public double TempC { get; set; }
        public double TempF { get; set; }
        public string CondicaoCeu { get; set; }
        public string Icon { get; set; }
        public double PrevisaoMm { get; set; }
        public double NeveCm { get; set; }
        public int Umidade { get; set; }
        public int Nebulosidade { get; set; }
        public double SensacaoTermicaC { get; set; }
        public double SensacaoTermicaF { get; set; }
        public int VaiChover { get; set; }
        public int ChanceChuva { get; set; }
        public int VaiNevar { get; set; }
        public int ChanceNeve { get; set; }

        public ForecastDayExibicaoDTO(ForecastDay forecastDay)
        {
            Data = forecastDay.Data;
            Horario = forecastDay.Horario;
            TempC = forecastDay.TempC;
            TempF = forecastDay.TempF;
            CondicaoCeu = forecastDay.CondicaoCeu;
            Icon = forecastDay.Icon;
            PrevisaoMm = forecastDay.PrevisaoMm;
            NeveCm = forecastDay.NeveCm;
            Umidade = forecastDay.Umidade;
            Nebulosidade = forecastDay.Nebulosidade;
            SensacaoTermicaC = forecastDay.SensacaoTermicaC;
            SensacaoTermicaF = forecastDay.SensacaoTermicaF;
            VaiChover = forecastDay.VaiChover;
            ChanceChuva = forecastDay.ChanceChuva;
            VaiNevar = forecastDay.VaiNevar;
            ChanceNeve = forecastDay.ChanceNeve;
        }
    }
}

