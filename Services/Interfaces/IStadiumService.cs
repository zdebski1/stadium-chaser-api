using Microsoft.AspNetCore.Mvc;
using stadiumChaserApi.Entities;

namespace stadiumChaserApi.Services.Interfaces
{
    public interface IStadiumService
    {
        Task<ActionResult<IEnumerable<Stadium>>> GetStadiumAsync();
    }
}
