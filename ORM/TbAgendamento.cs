using System;
using System.Collections.Generic;

namespace SiteAgendamento.ORM;

public partial class TbAgendamento
{
    public int Id { get; set; }

    public DateOnly DtHoraAgendamento { get; set; }

    public DateOnly AgendarData { get; set; }

    public TimeOnly Horario { get; set; }

    public int FkUsuarioId { get; set; }

    public int FkServicoId { get; set; }

    public virtual TbServico FkServico { get; set; } = null!;

    public virtual TbUsuario FkUsuario { get; set; } = null!;
}
