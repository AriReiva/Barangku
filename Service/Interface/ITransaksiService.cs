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
    public interface ITransaksiService
    {
        Task<int> CreateTransaksiAsync(CreateTransaksiDto dto);
        // Task<TransaksiDto> GetTransaksiByIdAsync(int id);
        // Task<List<TransaksiDto>> GetAllTransaksiAsync();
    }
}