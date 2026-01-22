using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barangku.Model.DTO
{
    public class DetailTranskasiDto
    {
        public int ProdukId { get; set; }
        public string NamaProduk { get; set; } = string.Empty;

        public int Jumlah { get; set; }
        public decimal Harga { get; set; }
        public decimal Subtotal { get; set; }
    }
}