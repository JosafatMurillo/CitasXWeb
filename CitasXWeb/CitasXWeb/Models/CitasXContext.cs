using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CitasXWeb.Models
{
    public partial class CitasXContext : DbContext
    {
        public CitasXContext()
        {
        }

        public CitasXContext(DbContextOptions<CitasXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCita> TbCita { get; set; }
        public virtual DbSet<TbEspecialidad> TbEspecialidad { get; set; }
        public virtual DbSet<TbEstado> TbEstado { get; set; }
        public virtual DbSet<TbHistorialMedico> TbHistorialMedico { get; set; }
        public virtual DbSet<TbPaciente> TbPaciente { get; set; }
        public virtual DbSet<TbPersonalHospital> TbPersonalHospital { get; set; }
        public virtual DbSet<TbRol> TbRol { get; set; }
        public virtual DbSet<TbSeguroSocial> TbSeguroSocial { get; set; }
        public virtual DbSet<TbUsuario> TbUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CitasX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCita>(entity =>
            {
                entity.HasKey(e => e.CitId);

                entity.ToTable("tb_cita");

                entity.Property(e => e.CitId).HasColumnName("cit_id");

                entity.Property(e => e.CitCurp)
                    .HasColumnName("cit_curp")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.CitEstado).HasColumnName("cit_estado");

                entity.Property(e => e.CitFecha)
                    .HasColumnName("cit_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.CitHora)
                    .HasColumnName("cit_hora")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CitNombrePaciente)
                    .HasColumnName("cit_nombre_paciente")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CitNumeroPersonalMedico).HasColumnName("cit_numero_personal_medico");

                entity.HasOne(d => d.CitCurpNavigation)
                    .WithMany(p => p.TbCita)
                    .HasForeignKey(d => d.CitCurp)
                    .HasConstraintName("FK_tb_cita_tb_paciente1");

                entity.HasOne(d => d.CitEstadoNavigation)
                    .WithMany(p => p.TbCita)
                    .HasForeignKey(d => d.CitEstado)
                    .HasConstraintName("FK_tb_cita_tb_estado1");

                entity.HasOne(d => d.CitNumeroPersonalMedicoNavigation)
                    .WithMany(p => p.TbCita)
                    .HasForeignKey(d => d.CitNumeroPersonalMedico)
                    .HasConstraintName("FK_tb_cita_tb_personal_hospital");
            });

            modelBuilder.Entity<TbEspecialidad>(entity =>
            {
                entity.HasKey(e => e.EspId);

                entity.ToTable("tb_especialidad");

                entity.Property(e => e.EspId).HasColumnName("esp_id");

                entity.Property(e => e.EspNombre)
                    .HasColumnName("esp_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbEstado>(entity =>
            {
                entity.HasKey(e => e.EstId);

                entity.ToTable("tb_estado");

                entity.Property(e => e.EstId).HasColumnName("est_id");

                entity.Property(e => e.EstNombre)
                    .HasColumnName("est_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbHistorialMedico>(entity =>
            {
                entity.HasKey(e => e.HisId);

                entity.ToTable("tb_historial_medico");

                entity.Property(e => e.HisId).HasColumnName("his_id");

                entity.Property(e => e.HisEvaluacion)
                    .HasColumnName("his_evaluacion")
                    .HasColumnType("text");

                entity.Property(e => e.HisFecha)
                    .HasColumnName("his_fecha")
                    .HasColumnType("date");

                entity.Property(e => e.HisMedicamento)
                    .HasColumnName("his_medicamento")
                    .HasColumnType("text");

                entity.Property(e => e.HisMedico).HasColumnName("his_medico");

                entity.Property(e => e.HisPaciente)
                    .HasColumnName("his_paciente")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.HisPeso).HasColumnName("his_peso");

                entity.Property(e => e.HisPresionArterial).HasColumnName("his_presion_arterial");

                entity.Property(e => e.HisSintoma)
                    .HasColumnName("his_sintoma")
                    .HasColumnType("text");

                entity.HasOne(d => d.HisMedicoNavigation)
                    .WithMany(p => p.TbHistorialMedico)
                    .HasForeignKey(d => d.HisMedico)
                    .HasConstraintName("FK_tb_historial_medico_tb_personal_hospital1");

                entity.HasOne(d => d.HisPacienteNavigation)
                    .WithMany(p => p.TbHistorialMedico)
                    .HasForeignKey(d => d.HisPaciente)
                    .HasConstraintName("FK_tb_historial_medico_tb_paciente1");
            });

            modelBuilder.Entity<TbPaciente>(entity =>
            {
                entity.HasKey(e => e.PacCurp);

                entity.ToTable("tb_paciente");

                entity.Property(e => e.PacCurp)
                    .HasColumnName("pac_curp")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.PacCiudad)
                    .HasColumnName("pac_ciudad")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PacCodigoPostal).HasColumnName("pac_codigo_postal");

                entity.Property(e => e.PacDomicilio)
                    .HasColumnName("pac_domicilio")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PacEstado)
                    .HasColumnName("pac_estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PacFechaNacimiento)
                    .HasColumnName("pac_fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.PacNombre)
                    .HasColumnName("pac_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PacNumeroSeguroSocial).HasColumnName("pac_numero_seguro_social");

                entity.Property(e => e.PacSexo)
                    .HasColumnName("pac_sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PacTelefonoFijo).HasColumnName("pac_telefono_fijo");

                entity.Property(e => e.PacTelefonoPersonal).HasColumnName("pac_telefono_personal");

                entity.Property(e => e.PacTipoSeguro).HasColumnName("pac_tipo_seguro");

                entity.Property(e => e.PacUsuario).HasColumnName("pac_usuario");

                entity.HasOne(d => d.PacTipoSeguroNavigation)
                    .WithMany(p => p.TbPaciente)
                    .HasForeignKey(d => d.PacTipoSeguro)
                    .HasConstraintName("FK_tb_paciente_tb_seguro_social");

                entity.HasOne(d => d.PacUsuarioNavigation)
                    .WithMany(p => p.TbPaciente)
                    .HasForeignKey(d => d.PacUsuario)
                    .HasConstraintName("FK_tb_paciente_tb_usuario1");
            });

            modelBuilder.Entity<TbPersonalHospital>(entity =>
            {
                entity.HasKey(e => e.PerNumeroPersonal);

                entity.ToTable("tb_personal_hospital");

                entity.Property(e => e.PerNumeroPersonal).HasColumnName("per_numero_personal");

                entity.Property(e => e.PerCiudad)
                    .HasColumnName("per_ciudad")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PerEspecialidad).HasColumnName("per_especialidad");

                entity.Property(e => e.PerEstado)
                    .HasColumnName("per_estado")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PerNombre)
                    .HasColumnName("per_nombre")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.PerSexo)
                    .HasColumnName("per_sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PerUsuario).HasColumnName("per_usuario");

                entity.HasOne(d => d.PerEspecialidadNavigation)
                    .WithMany(p => p.TbPersonalHospital)
                    .HasForeignKey(d => d.PerEspecialidad)
                    .HasConstraintName("FK_tb_personal_hospital_tb_especialidad");

                entity.HasOne(d => d.PerUsuarioNavigation)
                    .WithMany(p => p.TbPersonalHospital)
                    .HasForeignKey(d => d.PerUsuario)
                    .HasConstraintName("FK_tb_personal_hospital_tb_usuario1");
            });

            modelBuilder.Entity<TbRol>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.ToTable("tb_rol");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.RolNombre)
                    .HasColumnName("rol_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSeguroSocial>(entity =>
            {
                entity.HasKey(e => e.SegId);

                entity.ToTable("tb_seguro_social");

                entity.Property(e => e.SegId).HasColumnName("seg_id");

                entity.Property(e => e.SegNombre)
                    .HasColumnName("seg_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("tb_usuario");

                entity.Property(e => e.UsuId).HasColumnName("usu_id");

                entity.Property(e => e.UsuContrasenia)
                    .HasColumnName("usu_contrasenia")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuIdentificador)
                    .HasColumnName("usu_identificador")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.UsuRol).HasColumnName("usu_rol");

                entity.HasOne(d => d.UsuRolNavigation)
                    .WithMany(p => p.TbUsuario)
                    .HasForeignKey(d => d.UsuRol)
                    .HasConstraintName("FK_tb_usuario_tb_rol1");
            });
        }
    }
}
