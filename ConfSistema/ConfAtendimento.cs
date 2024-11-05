using SiteAgendamento.Models;
using SiteAgendamento.ORM;
using Microsoft.EntityFrameworkCore;

namespace SiteAgendamento.ConfSistema
{
    public class ConfAtendimento
    {
        private BdServicoContext _context;
        public ConfAtendimento(BdServicoContext context)
        {
            _context = context;
        }      
        public List<ViewAgendamentoVM> ListarAtendimentos()
        {
            List<ViewAgendamentoVM> ListaAtendimentos = new List<ViewAgendamentoVM>();

            var list = _context.ViewAgendamentos.ToList();

            if (list.Count != 0)
            {
                foreach (var item in list)
                {
                    ViewAgendamentoVM Agdmt = new ViewAgendamentoVM();
                    {

                        Agdmt.Id = item.Id;
                        Agdmt.Nome = item.Nome;
                        Agdmt.Email = item.Email;
                        Agdmt.Telefone = item.Telefone;
                        Agdmt.DtHoraAgendamento = item.DtHoraAgendamento;
                        Agdmt.AgendarData = item.AgendarData;
                        Agdmt.Horario = item.Horario;
                        Agdmt.TipoServico = item.TipoServico;
                        Agdmt.Valor = item.Valor;


                    }

                    ListaAtendimentos.Add(Agdmt);
                }

                return ListaAtendimentos;
            }
            else
            {
                return null;
            }
        }     
       
    }
}
