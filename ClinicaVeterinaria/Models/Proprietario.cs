using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Proprietario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public ICollection<Pet> Pet { get; set; } = new List<Pet>();

        public Proprietario()
        {
        }

        public Proprietario(int id, string nome, string rg, string telefone, string email, string endereco)
        {
            Id = id;
            Nome = nome;
            Rg = rg;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }
    }
}
