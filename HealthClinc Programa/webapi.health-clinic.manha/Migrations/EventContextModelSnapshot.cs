﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webapi.health_clinic.manha.Context;

#nullable disable

namespace webapi.health_clinic.manha.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<DateTime>("HorarioAbertura")
                        .HasColumnType("SMALLDATETIME");

                    b.Property<DateTime>("HorarioFechamento")
                        .HasColumnType("SMALLDATETIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.HasKey("IdClinica");

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.ComentarioConsulta", b =>
                {
                    b.Property<Guid>("IdComentarioConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("situacao")
                        .HasColumnType("bit");

                    b.HasKey("IdComentarioConsulta");

                    b.HasIndex("IdConsulta");

                    b.ToTable("ComentarioConsulta");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataConsultaEHorarioConsulta")
                        .HasColumnType("SMALLDATETIME");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Especialidades", b =>
                {
                    b.Property<Guid>("idEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeEspecialidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("idEspecialidade");

                    b.HasIndex("NomeEspecialidade");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType(" VARCHAR(8)");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEspecialidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdMedico");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPacioente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdPacioente");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.TiposDeUsuario", b =>
                {
                    b.Property<Guid>("IdTipoDeUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdTipoDeUsuario");

                    b.HasIndex("IdTipoDeUsuario");

                    b.ToTable("TiposDeUsuario");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdTipoDeUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(150)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("CHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email");

                    b.HasIndex("IdTipoDeUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.ComentarioConsulta", b =>
                {
                    b.HasOne("webapi.health_clinic.manha.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Consulta", b =>
                {
                    b.HasOne("webapi.health_clinic.manha.Domains.Medico", "medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.manha.Domains.Paciente", "paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medico");

                    b.Navigation("paciente");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Medico", b =>
                {
                    b.HasOne("webapi.health_clinic.manha.Domains.Clinica", "clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.manha.Domains.Especialidades", "especialidades")
                        .WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.health_clinic.manha.Domains.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("clinica");

                    b.Navigation("especialidades");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Paciente", b =>
                {
                    b.HasOne("webapi.health_clinic.manha.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("webapi.health_clinic.manha.Domains.Usuario", b =>
                {
                    b.HasOne("webapi.health_clinic.manha.Domains.TiposDeUsuario", "TiposDeUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoDeUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TiposDeUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
