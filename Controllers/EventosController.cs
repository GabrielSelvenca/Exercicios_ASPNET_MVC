using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading.Tasks;
using Exercicios_ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;

namespace Exercicios_ASPNET_MVC.Controllers
{
    [Route("[controller]")]
    public class EventosController : Controller
    {
        private static List<Evento> _eventos = new List<Evento>
        {
            new Evento{Id = 0, Nome = "Natal", Descricao="Felicidade é estar contigo todo dia", Local="Casa", DataEvento=DateTime.Parse("25/12/2026"), QuantidadeVagas=20, ValorIngresso=0},
            new Evento{Id = 1, Nome = "Confra", Descricao="O que acontece na confra, fica na confra", Local="SENAI", DataEvento=DateTime.Parse("19/12/2026"), QuantidadeVagas=50, ValorIngresso=6.9m}
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

        [HttpPost]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento);
            }

            if (evento.DataEvento.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    nameof(evento.DataEvento),
                    "A data está menor que hoje."
                );

                return View(evento);
            }
            _eventos.Add(evento);

            return View(evento);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}