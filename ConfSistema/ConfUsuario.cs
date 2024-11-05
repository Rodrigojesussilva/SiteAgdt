using SiteAgendamento.Models;
using SiteAgendamento.ORM;
using Microsoft.EntityFrameworkCore;

namespace SiteAgendamento.ConfSistema
{
    public class ConfUsuario
    {
        private BdServicoContext _context;
        public ConfUsuario(BdServicoContext context)
        {
            _context = context;
        }      

        public List<UsuarioVM> ListarUsuarios()
        {
            List<UsuarioVM> ListaUsuarios = new List<UsuarioVM>();

            var list = _context.TbUsuarios.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    UsuarioVM UsuarioVM = new UsuarioVM();
                    {
                        UsuarioVM.Id = (int)item.Id;
                        UsuarioVM.Nome = item.Nome;
                        UsuarioVM.Senha = item.Senha;
                        UsuarioVM.Email = item.Email;
                        UsuarioVM.Telefone = item.Telefone;
                        UsuarioVM.TipoUsuario = item.TipoUsuario;

                    }

                    ListaUsuarios.Add(UsuarioVM);
                }

                return ListaUsuarios;
            }
            else
            {
                return null;
            }
        }
       
        public bool InserirUsuario(string nome, string email, string telefone, string senha, int tipoUsuario)
         {
                try
                {
                    TbUsuario usuario = new TbUsuario();
                    usuario.Nome = nome;
                    usuario.Email = email;
                    usuario.Telefone = telefone;
                    usuario.Senha = senha;
                    usuario.TipoUsuario = tipoUsuario.ToString();

                    _context.TbUsuarios.Add(usuario);  // Supondo que _context.TbUsuarios seja o DbSet para a entidade de usuários
                    _context.SaveChanges();

                    return true;  // Retorna true para indicar sucesso
                }
                catch (Exception ex)
                {
                    // Trate o erro ou faça um log do ex.Message se necessário
                    return false;  // Retorna false para indicar falha
                }
            }

        public bool AtualizarUsuario(int id, string nome, string email, string telefone, string senha, int tipoUsuario)
        {
            try
            {
                // Encontra o usuário pelo ID
                TbUsuario usuario = _context.TbUsuarios.FirstOrDefault(u => u.Id == id);

                // Verifica se o usuário foi encontrado
                if (usuario == null)
                {
                    return false; // Retorna false se o usuário não for encontrado
                }

                // Atualiza os campos do usuário
                usuario.Nome = nome;
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.Senha = senha;
                usuario.TipoUsuario = tipoUsuario.ToString();

                // Salva as mudanças no banco de dados
                _context.TbUsuarios.Update(usuario);
                _context.SaveChanges();

                return true; // Retorna true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate o erro ou faça um log do ex.Message se necessário
                return false; // Retorna false para indicar falha
            }
        }

        public bool ExcluirUsuario(int id)
        {
            try
            {
                // Busca o usuário pelo ID
                var usuario = _context.TbUsuarios.Find(id);

                if (usuario == null)
                {
                    return false; // Retorna false se o usuário não for encontrado
                }

                // Remove o usuário do DbSet
                _context.TbUsuarios.Remove(usuario);
                _context.SaveChanges();

                return true; // Retorna true para indicar sucesso
            }
            catch (Exception ex)
            {
                // Trate o erro ou faça um log do ex.Message se necessário
                return false; // Retorna false para indicar falha
            }
        }
    }
}
