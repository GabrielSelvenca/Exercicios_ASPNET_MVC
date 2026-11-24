using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Exercicios_ASPNET_MVC.Models;
using Exercicios_ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;

namespace Exercicios_ASPNET_MVC.Controllers
{
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new List<Evento>
        {
            new Evento{Id = 0, Nome = "Natal", Descricao="Felicidade é estar contigo todo dia", Local="Casa", DataEvento= new DateTime(2026, 12, 25), QuantidadeVagas=20, ValorIngresso=0},
            new Evento{Id = 1, Nome = "Confra", Descricao="O que acontece na confra, fica na confra", Local="SENAI", DataEvento=new DateTime(2026, 12, 19), QuantidadeVagas=50, ValorIngresso=6.9m}
        };

        public IActionResult Index()
        {
            return View(_eventos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var eventoExiste = _eventos.FirstOrDefault(x => x.Id == id);

            if (eventoExiste == null)
                return NotFound();

            return View(eventoExiste);
        }

        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (evento.DataEvento.Date < DateTime.Today)
                ModelState.AddModelError(
                    nameof(evento.DataEvento),
                    "A data não pode ser anterior a hoje."
                );

            if (!ModelState.IsValid)
                return View(evento);

            evento.Id = _eventos.Max(x => x.Id) + 1;
            _eventos.Add(evento);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaEventoViewModel());
        }

        [HttpPost]
        public IActionResult Buscar(BuscaEventoViewModel vm)
        {
            vm.Resultados = _eventos;

            if (!string.IsNullOrEmpty(vm.NomeBusca))
                vm.Resultados = _eventos.Where(e => e.Nome!.Contains(vm.NomeBusca, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}