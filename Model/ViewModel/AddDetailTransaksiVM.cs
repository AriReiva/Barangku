using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barangku.Model.ViewModel
{
    public class AddDetailTransaksiVM
    {
        [Required]
        public int ProdukId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Jumlah minimal 1")]
        public int Jumlah { get; set; }

        [Required]
        public decimal Harga { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
    }
}