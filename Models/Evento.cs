using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace Exercicios_ASPNET_MVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required] [MinLength(5)] [MaxLength(80)]
        public string? Nome { get; set; }

        [Required] [MinLength(10)]
        public string? Descricao { get; set; }

        [Required] [MinLength(3)] [MaxLength(100)]
        public string? Local { get; set; }

        [Required]
        public DateTime DataEvento { get; set; }

        [Range(1, 1000)]
        public int QuantidadeVagas { get; set; }

        [Range(0, int.MaxValue)]
        public decimal ValorIngresso { get; set; }
    }
}