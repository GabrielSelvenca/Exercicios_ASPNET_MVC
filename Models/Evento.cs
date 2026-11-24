using System.ComponentModel.DataAnnotations;

namespace Exercicios_ASPNET_MVC.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")] [StringLength(80, MinimumLength = 5, ErrorMessage = "O valor mínimo de caracteres é 5 e o máximo é 80")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")] [MinLength(10, ErrorMessage = "O valor mínimo é de 10 caracteres")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O campo Local é obrigatório.")] [StringLength(100, MinimumLength = 3, ErrorMessage = "O valor mínimo de caracteres é 3 e o máximo é 100")]
        public string? Local { get; set; }

        [Required(ErrorMessage = "O campo de Data do Evento é obrigatório.")]
        public DateTime DataEvento { get; set; }

        [Range(1, 1000, ErrorMessage = "Quantidade de vagas mínima é 1 e máxima é 1000")]
        public int QuantidadeVagas { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "O valor mínimo é R$ 0,00")]
        public decimal ValorIngresso { get; set; }
    }
}