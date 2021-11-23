using System;
using System.Collections.Generic;

namespace Pendaftaran.Models
{
    public partial class Siswa
    {
        public int IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public int? JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string NoRegistrasi { get; set; }
    }
}
