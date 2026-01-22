using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.ViewModel;

namespace Barangku.Model.DTO
{
    public class CreateTransaksiDto
    {
         public int UserId { get; set; }
        public decimal Total { get; set; }
        public decimal Bayar { get; set; }
        public decimal Kembali { get; set; }

        public List<DetailTranskasiDto> Details { get; set; } = new();
    }
}