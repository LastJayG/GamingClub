using GamingClub.Data.Context;
using GamingClub.Domain.Entities;
using GamingClub.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data.Repositories
{
    public class GamingStationRepository(GamingClubContext gamingClubContext) : IGamingStationRepository
    {
        public async Task<List<GamingStationEntity>> GetGamingStationsAsync()
        {
            return await gamingClubContext.GamingStations.ToListAsync();
        }
        public async Task<GamingStationEntity> GetGamingStationByIdAsync(int id)
        {
            return await gamingClubContext.GamingStations
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
        }
        public async Task CreateGamingStationAsync(GamingStationEntity gamingStation)
        {
            var newGamingStation = new GamingStationEntity();
            gamingStation.IsFree = gamingStation.IsFree;
            gamingStation.Type = gamingStation.Type;

            gamingClubContext.GamingStations.Add(gamingStation);

            await gamingClubContext.SaveChangesAsync();
        }

        //public async Task DeleteGamingStationByIdAsync(int id)
        //{
        //    var reservation = await gamingClubContext.Reservations
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(r => r.Id == id);
        //    gamingClubContext.Reservations.Remove(reservation);
        //    await gamingClubContext.SaveChangesAsync();
        //}

    }
}
