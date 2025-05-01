using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;
using GamingClub.Data.Context;
using GamingClub.Data.Interfaces;
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
        public async Task CreateGamingStationAsync(GamingStationDTO gamingStationDTO)
        {
            var gamingStation = new GamingStationEntity();
            gamingStation.IsFree = gamingStationDTO.IsFree;
            gamingStation.Type = gamingStationDTO.Type;

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
