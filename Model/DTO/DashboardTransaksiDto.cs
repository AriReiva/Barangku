using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Barangku.Model.DTO
{
    public class DashboardTransaksiDTO
    {
        public int Id { get; set; }
        public DateTime Tanggal { get; set; }
        public string Kasir { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}
