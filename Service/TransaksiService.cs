using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Data;
using Barangku.Service.Interface;
using Barangku.Model.DTO;
using Barangku.Model.ViewModel;
using Barangku.Model.Entities;
using Barangku.Model.Common;
using Microsoft.EntityFrameworkCore;

namespace Barangku.Service
{
    public class TransaksiService : ITransaksiService
    {
        private readonly AppDbContext _context;

        public TransaksiService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTransaksiAsync(CreateTransaksiDto dto)
        {
            var transaksi = new Transaksi
            {
                UserId = dto.UserId,
                Tanggal = DateTime.Now,
                Total = dto.Total,
                Bayar = dto.Bayar,
                Kembali = dto.Kembali
            };

            _context.Transaksi.Add(transaksi);
            await _context.SaveChangesAsync();
            foreach (var item in dto.Details)
            {
                var detail = new DetailTransaksi
                {
                    TransaksiId = transaksi.Id,
                    ProdukId = item.ProdukId,
                    Jumlah = item.Jumlah,
                    Harga = item.Harga,
                    Subtotal = item.Subtotal
                };
                _context.DetailTransaksi.Add(detail);

                var produk = await _context.Produk.FindAsync(item.ProdukId);
                if (produk != null)
                {
                    produk.Stok -= item.Jumlah;
                }
            }

            await _context.SaveChangesAsync();

            return transaksi.Id;
        }

        // public async Task<List<TransaksiDto>> GetAllTransaksiAsync()
        // {
            
        // }

        // public async Task<List<TransaksiDto>> GetTransaksiByIdAsync(int Id)
        // {
            
        // }
    }
}