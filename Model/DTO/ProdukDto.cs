using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barangku.Model.DTO
{
    public class ProdukDto
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Deskripsi { get; set; } = string.Empty;
        public decimal Harga { get; set; }
        public int Stok { get; set; }
    }
}