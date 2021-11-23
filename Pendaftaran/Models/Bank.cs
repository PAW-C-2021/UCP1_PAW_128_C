using System;
using System.Collections.Generic;

namespace Pendaftaran.Models
{
    public partial class Bank
    {
        public int IdPetugasBank { get; set; }
        public string NamaPetugasBank { get; set; }
        public string JenisKelamin { get; set; }
        public DateTime? TanggalPembayaran { get; set; }
        public string NoRegistrasi { get; set; }
    }
}
