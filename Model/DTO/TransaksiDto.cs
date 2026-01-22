using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barangku.Model.DTO
{
    public class TransaksiDto
    {
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }

        public int UserId { get; set; }
        public string NamaKasir { get; set; } = string.Empty;

        public decimal Total { get; set; }
        public decimal Bayar { get; set; }
        public decimal Kembali { get; set; }

        public List<DetailTranskasiDto> Details { get; set; } = new();
    }
}