﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeriBilisimFinal.Data;

namespace VeriBilisimFinal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VeriBilisimFinal.Models.Aday", b =>
                {
                    b.Property<int>("AdayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdayAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdaySoyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BasvuruTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ILID")
                        .HasColumnType("int");

                    b.Property<int?>("IlceID")
                        .HasColumnType("int");

                    b.Property<string>("IsyeriAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pozisyon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SeyahatEngeli")
                        .HasColumnType("bit");

                    b.HasKey("AdayID");

                    b.HasIndex("ILID");

                    b.HasIndex("IlceID");

                    b.ToTable("Adays");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.IL", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ILs");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.Ilce", b =>
                {
                    b.Property<int>("IlceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IlceAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ilID")
                        .HasColumnType("int");

                    b.HasKey("IlceID");

                    b.HasIndex("ilID");

                    b.ToTable("Ilces");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.Personel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ILID")
                        .HasColumnType("int");

                    b.Property<int?>("IlceID")
                        .HasColumnType("int");

                    b.Property<string>("PersonelAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonelSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ILID");

                    b.HasIndex("IlceID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.Aday", b =>
                {
                    b.HasOne("VeriBilisimFinal.Models.IL", "IL")
                        .WithMany()
                        .HasForeignKey("ILID");

                    b.HasOne("VeriBilisimFinal.Models.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceID");

                    b.Navigation("IL");

                    b.Navigation("Ilce");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.Ilce", b =>
                {
                    b.HasOne("VeriBilisimFinal.Models.IL", "il")
                        .WithMany()
                        .HasForeignKey("ilID");

                    b.Navigation("il");
                });

            modelBuilder.Entity("VeriBilisimFinal.Models.Personel", b =>
                {
                    b.HasOne("VeriBilisimFinal.Models.IL", "IL")
                        .WithMany()
                        .HasForeignKey("ILID");

                    b.HasOne("VeriBilisimFinal.Models.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceID");

                    b.Navigation("IL");

                    b.Navigation("Ilce");
                });
#pragma warning restore 612, 618
        }
    }
}