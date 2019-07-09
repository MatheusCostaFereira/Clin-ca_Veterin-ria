using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Agenda
    {
        public int Id { get; set; }

        [Display(Name = "Data da Consulta")]
        public DateTime DataConsulta { get; set; }

        public Pet Pet { get; set; }
        [Display(Name = "Pet")]
        public int PetId { get; set; }
        public Veterinario Veterinario { get; set; }
        [Display(Name = "Veterinário")]
        public int VeterinarioId { get; set; }

        public Agenda()
        {
        }

        public Agenda(int id, DateTime dataConsulta, Pet pet, Veterinario veterinario)
        {
            Id = id;
            DataConsulta = dataConsulta;
            Pet = pet;
            Veterinario = veterinario;
        }
    }
}
