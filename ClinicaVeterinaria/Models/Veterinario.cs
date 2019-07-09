using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Veterinario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CRMV { get; set; }
        [Required]
        public string Rg { get; set; }
        public string Email { get; set; }
        [Required]
        public string Contato { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Especialização { get; set; }


        public ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

        public ICollection<Agenda> Agenda { get; set; } = new List<Agenda>();

        public Veterinario()
        {
        }

        public Veterinario(int id, string nome, string cRMV, string rg, string email, string contato, string endereco, string especialização)
        {
            Id = id;
            Nome = nome;
            CRMV = cRMV;
            Rg = rg;
            Email = email;
            Contato = contato;
            Endereco = endereco;
            Especialização = especialização;
        }
    }
}
