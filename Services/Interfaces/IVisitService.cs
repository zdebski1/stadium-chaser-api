using stadiumChaserApi.Entities;

namespace stadiumChaserApi.Services.Interfaces
{
    public interface IVisitService
    {
        Task<string> CreateVisitAsync(Visit visit);
        Task<Visit> GetVisitAsync(int visitId);
    }
}