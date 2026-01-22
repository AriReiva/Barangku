using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barangku.Model.DTO
{
    public class DashboardDto
    {
        public int TotalTransaksiHariIni { get; set; }
        public decimal TotalPendapatanHariIni { get; set; }
        public int TotalProdukTerjualHariIni { get; set; }

        public int TotalBarang { get; set; }
        public int TotalBarangStokMenipis { get; set; }

        public List<DashboardTransaksiDTO> TransaksiTerakhir { get; set; } = new();
    }
}