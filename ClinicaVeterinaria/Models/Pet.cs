using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Display(Name = "Raça")]
        public string Raca { get; set; }
        public string Idade { get; set; }
        public string Peso { get; set; }

        public Proprietario Proprietario { get; set; }
        [Display(Name = "Proprietário")]
        public int ProprietarioId { get; set; }

        public ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public ICollection<Agenda> Agenda { get; set; } = new List<Agenda>();

        public Pet()
        {
        }

        public Pet(int id, string nome, string raca, string idade, string peso, Proprietario proprietario)
        {
            Id = id;
            Nome = nome;
            Raca = raca;
            Idade = idade;
            Peso = peso;
            Proprietario = proprietario;
        }
    }
}
