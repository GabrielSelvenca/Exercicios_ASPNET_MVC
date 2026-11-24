using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exercicios_ASPNET_MVC.Models;

namespace Exercicios_ASPNET_MVC.ViewModels
{
    public class BuscaEventoViewModel
    {
        public string? NomeBusca {get; set;}
        public string? LocalBusca {get; set;}
        public DateTime? DataInicial {get; set;}
        public List<Evento>? Resultados {get; set;}
    }
}