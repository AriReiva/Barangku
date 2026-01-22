using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.ViewModel;
using Barangku.Service.Interface;
using Barangku.Model.Common;

namespace Barangku.State
{
    public class ProdukState
    {
        private readonly IProdukService _produkService;

        public ProdukState(IProdukService produkService)
        {
            _produkService = produkService;
        }

        public List<ProdukVM> Produks { get; private set; } = new List<ProdukVM>();

        public async Task LoadProduksAsync()
        {
            Produks = await _produkService.GetAllProdukAsync();
        }

        public async Task RefreshProduksAsync()
        {
            await LoadProduksAsync();
        }

        public async Task<ProdukVM?> GetProdukByIdAsync(int id)
        {
            return await _produkService.GetProdukByIdAsync(id);
        }

        public async Task<bool> CreateProdukAsync(Model.DTO.ProdukDto produkDto)
        {
            var result = await _produkService.CreateProdukAsync(produkDto);
            if (result)
            {
                await LoadProduksAsync();
            }
            return result;
        }

        public async Task<bool> UpdateProdukAsync(int id, Model.DTO.ProdukDto produkDto)
        {
            var result = await _produkService.UpdateProdukAsync(id, produkDto);
            if (result)
            {
                await LoadProduksAsync();
            }
            return result;
        }

        public async Task<bool> DeleteProdukAsync(int id)
        {
            var result = await _produkService.DeleteProdukAsync(id);
            if (result)
            {
                await LoadProduksAsync();
            }
            return result;
        }

        public async Task<PagedResult<ProdukVM>> GetPagedProduksAsync(int page, int pageSize)
        {
            return await _produkService.GetPagedAsync(page, pageSize);
        }
    }
}