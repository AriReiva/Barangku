using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.DTO;
using Barangku.Model.ViewModel;
using Barangku.Model.Entities;
using Barangku.Model.Common;

namespace Barangku.Service.Interface
{
    public interface IProdukService
    {
        Task<List<ProdukVM>> GetAllProdukAsync();
        Task<ProdukVM?> GetProdukByIdAsync(int id);
        Task<bool> CreateProdukAsync(ProdukDto produkDto);
        Task<bool> UpdateProdukAsync(int id, ProdukDto produkDto);
        Task<bool> DeleteProdukAsync(int id);
        Task<PagedResult<ProdukVM>> GetPagedAsync(int page, int pageSize);
    }
}