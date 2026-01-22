using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barangku.Model.DTO;

namespace Barangku.Service.Interface
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}