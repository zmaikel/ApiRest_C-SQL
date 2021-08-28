using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using CapaDatos.Entidades;

namespace CapaDatos.Entidades
{
    public partial class ProyectoBDModel : DbContext
    {
        public ProyectoBDModel()
            : base("name=ProyectoBDModel")
        {
        }

        public virtual DbSet<T_Genero> T_Genero { get; set; }
        public virtual DbSet<T_Persona> T_Persona { get; set; }
        public virtual DbSet<T_Provincia> T_Provincia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Genero>()
                .Property(e => e.TGE_Descripcion)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_Genero>()
                .HasMany(e => e.T_Persona)
                .WithRequired(e => e.T_Genero)
                .HasForeignKey(e => e.TPE_TGE_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Persona>()
                .Property(e => e.TPE_Nombre)
                .IsUnicode(false);

            //modelBuilder.Entity<T_Persona>()
            //    .Property(e => e.TPE_ID);

            modelBuilder.Entity<T_Persona>()
                .Property(e => e.TPE_Apellido1)
                .IsUnicode(false);

            modelBuilder.Entity<T_Persona>()
                .Property(e => e.TPE_Apellido2)
                .IsUnicode(false);

            modelBuilder.Entity<T_Provincia>()
                .Property(e => e.TRP_Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<T_Provincia>()
                .HasMany(e => e.T_Persona)
                .WithRequired(e => e.T_Provincia)
                .HasForeignKey(e => e.TPE_TPR_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
