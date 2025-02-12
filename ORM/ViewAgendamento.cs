﻿using System;
using System.Collections.Generic;

namespace SiteAgendamento.ORM;

public partial class ViewAgendamento
{
    public int Id { get; set; }

    public DateTime DtHoraAgendamento { get; set; }

    public DateTime AgendarData { get; set; }

    public TimeOnly Horario { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string TipoServico { get; set; } = null!;

    public double Valor { get; set; }
}
