using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SYAC_OP.model.Models
{
    public partial class syac_opContext : DbContext
    {
        public syac_opContext()
        {
        }

        public syac_opContext(DbContextOptions<syac_opContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Listum> Lista { get; set; }
        public virtual DbSet<OrdenPedido> OrdenPedidos { get; set; }
        public virtual DbSet<OrdenPedidoDetalle> OrdenPedidoDetalles { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("creadoPor")
                    .IsFixedLength(true);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .HasColumnName("direccion")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("identificacion")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("nombres")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Listum>(entity =>
            {
                entity.HasKey(e => e.ListaId);

                entity.Property(e => e.ListaId).HasColumnName("listaId");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("creadoPor")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.TipoLista).HasColumnName("tipoLista");

                entity.HasOne(d => d.TipoListaNavigation)
                    .WithMany(p => p.InverseTipoListaNavigation)
                    .HasForeignKey(d => d.TipoLista)
                    .HasConstraintName("FK_Lista_Lista");
            });

            modelBuilder.Entity<OrdenPedido>(entity =>
            {
                entity.ToTable("OrdenPedido");

                entity.Property(e => e.OrdenPedidoId).HasColumnName("ordenPedidoId");

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.ClienteId).HasColumnName("clienteId");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("creadoPor")
                    .IsFixedLength(true);

                entity.Property(e => e.DireccionEntrega)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("direccionEntrega")
                    .IsFixedLength(true);

                entity.Property(e => e.EstadoId).HasColumnName("estadoId");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.PrioridadId).HasColumnName("prioridadId");

                entity.Property(e => e.ValorTotal).HasColumnName("valorTotal");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.OrdenPedidos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenPedido_Cliente");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.OrdenPedidoEstados)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenPedido_Estado");

                entity.HasOne(d => d.Prioridad)
                    .WithMany(p => p.OrdenPedidoPrioridads)
                    .HasForeignKey(d => d.PrioridadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenPedido_Prioridad");
            });

            modelBuilder.Entity<OrdenPedidoDetalle>(entity =>
            {
                entity.ToTable("OrdenPedidoDetalle");

                entity.Property(e => e.OrdenPedidoDetalleId).HasColumnName("ordenPedidoDetalleId");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CreadoPor)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("creadoPor")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.OrdenPedidoId).HasColumnName("ordenPedidoId");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.HasOne(d => d.OrdenPedido)
                    .WithMany(p => p.OrdenPedidoDetalles)
                    .HasForeignKey(d => d.OrdenPedidoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenPedidoDetalle_OrdenPedido");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.OrdenPedidoDetalles)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenPedidoDetalle_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("codigo")
                    .IsFixedLength(true);

                entity.Property(e => e.CreadoPor)
                    .HasMaxLength(10)
                    .HasColumnName("creadoPor")
                    .IsFixedLength(true);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.ValorUnitario).HasColumnName("valorUnitario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
