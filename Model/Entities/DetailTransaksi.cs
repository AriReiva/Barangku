using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barangku.Model.Entities
{
    public class DetailTransaksi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TransaksiId { get; set; }
        [ForeignKey("TransaksiId")]
        public Transaksi? Transaksi { get; set; }

        [Required]
        public int ProdukId { get; set; }
        
        [ForeignKey("ProdukId")]
        public Produk? Produk { get; set; }

        [Required]
        public int Jumlah { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Harga { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }
    }

}