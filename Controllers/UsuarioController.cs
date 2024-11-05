using Microsoft.AspNetCore.Mvc;
using SiteAgendamento.ConfSistema;
using SiteAgendamento.Models;
using SiteAgendamento.ORM;
using System.Diagnostics;

namespace SiteAgendamento.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly BdServicoContext _context;

        public UsuarioController(BdServicoContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Index()
        {
            ConfUsuario cf = new ConfUsuario(_context);
            var listaContato = cf.ListarUsuarios();
            return View(listaContato);
        }
        public IActionResult InserirUsuario(string Nome, string Senha, string Email, string Telefone, int TipoUsuario)
        {
            try
            {
                ConfUsuario conf = new ConfUsuario(_context);
                bool resultado = conf.InserirUsuario(Nome, Email, Telefone, Senha, TipoUsuario);

                if (resultado)
                {
                    return Json(new { success = true, message = "Usuário inserido com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao inserir o usuário" });
                }
            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário (você pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }

        public IActionResult AtualizarUsuario(int id, string Nome, string Senha, string Email, string Telefone, int TipoUsuario)
        {
            try
            {
                // Instancia a classe de configuração que realiza a atualização
                ConfUsuario conf = new ConfUsuario(_context);
                bool resultado = conf.AtualizarUsuario(id, Nome, Email, Telefone, Senha, TipoUsuario);

                // Verifica o resultado da atualização
                if (resultado)
                {
                    return Json(new { success = true, message = "Usuário atualizado com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar o usuário" });
                }
            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário (você pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }

        public IActionResult ExcluirUsuario(int id)
        {
            try
            {
                ConfUsuario conf = new ConfUsuario(_context);
                bool resultado = conf.ExcluirUsuario(id);

                if (resultado)
                {
                    return Json(new { success = true, message = "Usuário excluído com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao excluir o usuário" });
                }
            }
            catch (Exception ex)
            {
                // Trate exceções, se necessário (você pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicitação" });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
