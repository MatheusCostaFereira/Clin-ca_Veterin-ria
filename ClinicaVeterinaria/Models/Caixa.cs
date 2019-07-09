using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Caixa
    {
        public int Id { get; set; }
        public  DateTime Data { get; set; }
        [Display(Name = "Histórico")]
        public  string Historico { get; set; }
        [Display(Name = "Fluxo de Caixa")]
        public double EntradaouSaida { get; set; }

        public ICollection<Caixa> CaixaTotal { get; set; } = new List<Caixa>();

        public Caixa()
        {
        }

        public Caixa(int id,DateTime date, string historico, double entradaouSaida)
        {
            Id = id;
            Data = date;
            Historico = historico;
            EntradaouSaida = entradaouSaida;
        }

        public void AddSales(Caixa sr)
        {
            CaixaTotal.Add(sr);
        }

        public void RemoveSales(Caixa sr)
        {
            CaixaTotal.Remove(sr);
        }

        public double TotalCaixa()
        {
            return CaixaTotal.Sum(sr => sr.EntradaouSaida);
        }

    }
}
