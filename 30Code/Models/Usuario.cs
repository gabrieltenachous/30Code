using System;
using System.ComponentModel.DataAnnotations;

namespace _30Code.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 200 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Nascimento")]
        public DateTime? Nascimento { get; set; }

        [Display(Name = "Tipo Usuario")]
        public TipoUsuario TiposUsuarios { get; set; }

        [Display(Name = "Sexo")]
        public Sexo Sexos { get; set; }

        public enum TipoUsuario
        {
            Comum = 0,
            Admin = 1,
            Premiun = 2
        }
        public enum Sexo
        {
            Masculino = 0,
            Feminino = 1,
            NãoRevelar = 2
        }
    }
}