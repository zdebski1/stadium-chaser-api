using stadiumChaserApi.Entities;
using System.Threading.Tasks;

namespace stadiumChaserApi.Services.Interfaces
{
    public interface IVisitService
    {
        Task<string> CreateVisitAsync(Visit visit);
        Task<Visit> GetVisitAsync(int visitId);
    }
}