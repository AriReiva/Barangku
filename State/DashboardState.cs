using Barangku.Model.DTO;
using Barangku.Service.Interface;

namespace Barangku.State
{
    public class DashboardState
    {
        private readonly IDashboardService _dashboardService;

        public DashboardDto Data { get; private set; } = new();
        public bool IsLoading { get; private set; }

        public event Action? OnChange;

        public DashboardState(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task LoadAsync()
        {
            IsLoading = true;
            NotifyStateChanged();

            Data = await _dashboardService.GetDashboardAsync();

            IsLoading = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
