using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class ConsultaPagar
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Validade")]
        public DateTime Data_Validade { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }

        public Proprietario Proprietario { get; set; }
        [Display(Name = "Proprietário")]
        public int ProprietarioId { get; set; }

        public ConsultaPagar()
        {
        }

        public ConsultaPagar(int id, DateTime data_Validade, double valor, Proprietario proprietario, int proprietarioId)
        {
            Id = id;
            Data_Validade = data_Validade;
            Valor = valor;
            Proprietario = proprietario;
            ProprietarioId = proprietarioId;
        }
    }
}
