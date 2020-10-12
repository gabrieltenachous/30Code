using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _30Code.Models
{
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Campo nome deve estar entre 3 a 100 caracteres")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Duração")]
        public double Duracao { get; set; }
        public string Url_imagem { get; set; }
        public Nivel Niveis { get; set; }
        public enum Nivel
        {
            Basico = 1,
            Intermediario = 2,
            Avançado = 3
        }
    }
}