using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Pendaftaran.Models
{
    public partial class PendaftaranContext : DbContext
    {
        public PendaftaranContext()
        {
        }

        public PendaftaranContext(DbContextOptions<PendaftaranContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<CustomerService> CustomerService { get; set; }
        public virtual DbSet<KepalaSekolah> KepalaSekolah { get; set; }
        public virtual DbSet<Petugas> Petugas { get; set; }
        public virtual DbSet<Siswa> Siswa { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.IdPetugasBank);

                entity.Property(e => e.IdPetugasBank)
                    .HasColumnName("ID_PetugasBank")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPetugasBank)
                    .HasColumnName("Nama_PetugasBank")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoRegistrasi)
                    .HasColumnName("No_Registrasi")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalPembayaran)
                    .HasColumnName("Tanggal_Pembayaran")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<CustomerService>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.Property(e => e.IdCustomer)
                    .HasColumnName("ID_Customer")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCustomerService)
                    .HasColumnName("Nama_CustomerService")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KepalaSekolah>(entity =>
            {
                entity.HasKey(e => e.IdKepalaSekolah);

                entity.Property(e => e.IdKepalaSekolah)
                    .HasColumnName("ID_KepalaSekolah")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaKepalaSekolah)
                    .HasColumnName("Nama_KepalaSekolah")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Petugas>(entity =>
            {
                entity.HasKey(e => e.IdPetugas);

                entity.Property(e => e.IdPetugas)
                    .HasColumnName("ID_Petugas")
                    .ValueGeneratedNever();

                entity.Property(e => e.JenisKelamin)
                    .HasColumnName("Jenis_Kelamin")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPetugas)
                    .HasColumnName("Nama_Petugas")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Siswa>(entity =>
            {
                entity.HasKey(e => e.IdSiswa);

                entity.Property(e => e.IdSiswa)
                    .HasColumnName("ID_Siswa")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alamat)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.JenisKelamin).HasColumnName("Jenis_Kelamin");

                entity.Property(e => e.NamaSiswa)
                    .HasColumnName("Nama_Siswa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoRegistrasi)
                    .HasColumnName("No_Registrasi")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.TanggalLahir)
                    .HasColumnName("Tanggal_Lahir")
                    .HasColumnType("date");
            });
        }
    }
}
