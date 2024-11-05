namespace SiteAgendamento.Models
{
    public class AtendimentoVM
    {
        public int Id { get; set; }

        public DateTime DtHoraAgendamento { get; set; }

        public DateTime AgendarData { get; set; }

        public TimeOnly Horario { get; set; }

        public int? Satisfacao { get; set; }

        public int? Confirmacao { get; set; }

        public int FkUsuarioId { get; set; }

        public int FkServicoId { get; set; }

    }
}
