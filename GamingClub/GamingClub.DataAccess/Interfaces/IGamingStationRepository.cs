using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;

namespace GamingClub.Data.Interfaces
{
    public interface IGamingStationRepository
    {
        public Task<List<GamingStationEntity>> GetGamingStationsAsync();
        public Task<GamingStationEntity> GetGamingStationByIdAsync(int id);
        public Task CreateGamingStationAsync(GamingStationDTO gamingStationDTO);
        //public Task UpdateGamingStationAsync(GamingStationDTO gamingStationDTO);
        //public Task DeleteGamingStationByIdAsync(int id);
    }
}
