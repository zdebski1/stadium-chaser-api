using stadiumChaserApi.Entities;
using System.ComponentModel;
using System.Threading.Tasks;

namespace stadiumChaserApi.Services.Interfaces
{
    public interface IVisitService
    {
        Task<string> CreateVisitAsync(Visit visit);
    }
}