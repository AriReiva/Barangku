using Barangku.Data;
using Barangku.Model.DTO;
using Barangku.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Barangku.Service.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly AppDbContext _context;
        private const int STOK_MENIPIS = 5;

        public DashboardService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var today = DateTime.Today;

            var totalTransaksi = await _context.Transaksi
                .CountAsync(t => t.Tanggal >= today);

            var totalPendapatan = await _context.Transaksi
                .Where(t => t.Tanggal >= today)
                .SumAsync(t => (decimal?)t.Total) ?? 0;

            var totalProdukTerjual = await _context.DetailTransaksi
                .Where(d => d.Transaksi!.Tanggal >= today)
                .SumAsync(d => (int?)d.Jumlah) ?? 0;

            var totalBarang = await _context.Produk.CountAsync();

            var stokMenipis = await _context.Produk
                .CountAsync(p => p.Stok <= STOK_MENIPIS);

            var transaksiTerakhir = await _context.Transaksi
                .Include(t => t.Kasir)
                .OrderByDescending(t => t.Tanggal)
                .Take(5)
                .Select(t => new DashboardTransaksiDTO
                {
                    Id = t.Id,
                    Tanggal = t.Tanggal,
                    Kasir = t.Kasir!.Username,
                    Total = t.Total
                })
                .ToListAsync();

            return new DashboardDto
            {
                TotalTransaksiHariIni = totalTransaksi,
                TotalPendapatanHariIni = totalPendapatan,
                TotalProdukTerjualHariIni = totalProdukTerjual,
                TotalBarang = totalBarang,
                TotalBarangStokMenipis = stokMenipis,
                TransaksiTerakhir = transaksiTerakhir
            };
        }
    }
}
