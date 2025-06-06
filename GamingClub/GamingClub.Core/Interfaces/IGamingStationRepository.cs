using GamingClub.Domain.Entities;

namespace GamingClub.Domain.Interfaces
{
    public interface IGamingStationRepository
    {
        public Task<List<GamingStationEntity>> GetGamingStationsAsync();
        public Task<GamingStationEntity> GetGamingStationByIdAsync(int id);
        public Task CreateGamingStationAsync(GamingStationEntity gamingStation);
        //public Task UpdateGamingStationAsync(GamingStationEntity gamingStation);
        //public Task DeleteGamingStationByIdAsync(int id);


    }
}
