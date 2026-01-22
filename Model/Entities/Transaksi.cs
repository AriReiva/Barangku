using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Barangku.Model.Entities
{
    public class Transaksi
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime Tanggal { get; set; } = DateTime.Now;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? Kasir { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Bayar { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Kembali { get; set; }
    }

}