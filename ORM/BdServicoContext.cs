using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SiteAgendamento.ORM;

public partial class BdServicoContext : DbContext
{
    public BdServicoContext()
    {
    }

    public BdServicoContext(DbContextOptions<BdServicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAgendamento> TbAgendamentos { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<ViewAgendamento> ViewAgendamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=bd_servico;User Id=admin;Password=admin;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAgendamento>(entity =>
        {
            entity.ToTable("TbAgendamento");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FkServicoId).HasColumnName("fk_Servico_ID");
            entity.Property(e => e.FkUsuarioId).HasColumnName("fk_Usuario_ID");

            entity.HasOne(d => d.FkServico).WithMany(p => p.TbAgendamentos)
                .HasForeignKey(d => d.FkServicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAgendamento_TbServico");

            entity.HasOne(d => d.FkUsuario).WithMany(p => p.TbAgendamentos)
                .HasForeignKey(d => d.FkUsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbAgendamento_TbUsuario");
        });

        modelBuilder.Entity<TbServico>(entity =>
        {
            entity.ToTable("TbServico");

            entity.Property(e => e.TipoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("TbUsuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ViewAgendamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ViewAgendamento");

            entity.Property(e => e.AgendarData).HasColumnType("datetime");
            entity.Property(e => e.DtHoraAgendamento).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TipoServico)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
