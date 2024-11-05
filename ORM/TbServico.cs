using System;
using System.Collections.Generic;

namespace SiteAgendamento.ORM;

public partial class TbServico
{
    public int Id { get; set; }

    public string TipoServico { get; set; } = null!;

    public double Valor { get; set; }

    public virtual ICollection<TbAgendamento> TbAgendamentos { get; set; } = new List<TbAgendamento>();
}
