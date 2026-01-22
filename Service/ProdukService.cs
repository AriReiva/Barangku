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
    public class ProdukService: IProdukService
    { 
        private readonly AppDbContext _context;
        public ProdukService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProdukVM>> GetAllProdukAsync()
        {
            return await _context.Produk
                .Select(produk => new ProdukVM
                {
                    Id = produk.Id,
                    Nama = produk.Nama,
                    Deskripsi = produk.Deskripsi,
                    Harga = produk.Harga,
                    Stok = produk.Stok
                })
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task<ProdukVM?> GetProdukByIdAsync(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null) return null;

            return new ProdukVM
            {
                Id = produk.Id,
                Nama = produk.Nama,
                Deskripsi = produk.Deskripsi,
                Harga = produk.Harga,
                Stok = produk.Stok
            };
        }

        public async Task<bool> CreateProdukAsync(ProdukDto produkDto)
        {
            var produk = new Produk
            {
                Nama = produkDto.Nama,
                Deskripsi = produkDto.Deskripsi,
                Harga = produkDto.Harga,
                Stok = produkDto.Stok
            };

            _context.Produk.Add(produk);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProdukAsync(int id, ProdukDto produkDto)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null) return false;

            produk.Nama = produkDto.Nama;
            produk.Deskripsi = produkDto.Deskripsi;
            produk.Harga = produkDto.Harga;
            produk.Stok = produkDto.Stok;

            _context.Produk.Update(produk);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProdukAsync(int id)
        {
            var produk = await _context.Produk.FindAsync(id);
            if (produk == null) return false;

            _context.Produk.Remove(produk);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PagedResult<ProdukVM>> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.Produk.AsQueryable();

            var totalItems = await query.CountAsync();

            var items = await query
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(produk => new ProdukVM
                {
                    Id = produk.Id,
                    Nama = produk.Nama,
                    Deskripsi = produk.Deskripsi,
                    Harga = produk.Harga,
                    Stok = produk.Stok
                })
                .ToListAsync();

            return new PagedResult<ProdukVM>
            {
                Items = items,
                TotalItems = totalItems,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}