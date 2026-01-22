using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barangku.Model.Entities
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Nama { get; set; } = string.Empty;
        [Required, MaxLength(500)]
        public string Deskripsi { get; set; } = string.Empty;
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Harga { get; set; }
        [Required]
        public int Stok { get; set; }
    }
}