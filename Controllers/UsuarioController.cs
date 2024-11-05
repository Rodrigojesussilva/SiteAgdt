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
                    return Json(new { success = true, message = "Usu�rio inserido com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao inserir o usu�rio" });
                }
            }
            catch (Exception ex)
            {
                // Trate exce��es, se necess�rio (voc� pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicita��o" });
            }
        }

        public IActionResult AtualizarUsuario(int id, string Nome, string Senha, string Email, string Telefone, int TipoUsuario)
        {
            try
            {
                // Instancia a classe de configura��o que realiza a atualiza��o
                ConfUsuario conf = new ConfUsuario(_context);
                bool resultado = conf.AtualizarUsuario(id, Nome, Email, Telefone, Senha, TipoUsuario);

                // Verifica o resultado da atualiza��o
                if (resultado)
                {
                    return Json(new { success = true, message = "Usu�rio atualizado com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao atualizar o usu�rio" });
                }
            }
            catch (Exception ex)
            {
                // Trate exce��es, se necess�rio (voc� pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicita��o" });
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
                    return Json(new { success = true, message = "Usu�rio exclu�do com sucesso" });
                }
                else
                {
                    return Json(new { success = false, message = "Erro ao excluir o usu�rio" });
                }
            }
            catch (Exception ex)
            {
                // Trate exce��es, se necess�rio (voc� pode logar `ex.Message` se desejar)
                return Json(new { success = false, message = "Erro ao processar a solicita��o" });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
