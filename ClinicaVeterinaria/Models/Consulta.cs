using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVeterinaria.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        [Display(Name = "Data da Consulta")]
        public DateTime Data_Consulta { get; set; }
        public Pet Pet { get; set; }
        [Display(Name = "Pet")]
        public int PetId { get; set; }
        public Veterinario Veterinario { get; set; }
        [Display(Name = "Veterinário")]
        public int VeterinarioId { get; set; }
        public string Receita { get; set; }
        public string Motivo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Exames Realizados")]
        public string ExamesRealizados { get; set; }


        public Consulta()
        {
        }

        public Consulta(int id, DateTime data_Consulta, Pet pet, int petId, Veterinario veterinario, int veterinarioId, string receita, string motivo, string descricao, string examesRealizados)
        {
            Id = id;
            Data_Consulta = data_Consulta;
            Pet = pet;
            PetId = petId;
            Veterinario = veterinario;
            VeterinarioId = veterinarioId;
            Receita = receita;
            Motivo = motivo;
            Descricao = descricao;
            ExamesRealizados = examesRealizados;
        }
    }
}
