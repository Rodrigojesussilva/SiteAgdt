﻿using System;
using System.Collections.Generic;

namespace SiteAgendamento.ORM;

public partial class TbUsuario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<TbAgendamento> TbAgendamentos { get; set; } = new List<TbAgendamento>();
}
