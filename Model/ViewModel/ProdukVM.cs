using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barangku.Model.ViewModel
{
    public class ProdukVM
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Deskripsi { get; set; } = string.Empty;
        public decimal Harga { get; set; } = 0;
        public int Stok { get; set; } = 0;
    }
}