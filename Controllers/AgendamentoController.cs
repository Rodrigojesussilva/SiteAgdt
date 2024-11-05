using Microsoft.AspNetCore.Mvc;
using SiteAgendamento.ConfSistema;
using SiteAgendamento.Models;
using SiteAgendamento.ORM;
using System.Diagnostics;

namespace SiteAgendamento.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly BdServicoContext _context;

        public AgendamentoController(BdServicoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ConfAtendimento cf = new ConfAtendimento(_context);
            var listaAtendimento = cf.ListarAtendimentos();
            return View(listaAtendimento);
        }    
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
