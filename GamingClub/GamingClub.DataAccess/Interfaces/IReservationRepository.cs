using GamingClub.Application.DTOs;
using GamingClub.Core.Entities;

namespace GamingClub.Data.Interfaces
{
    public interface IReservationRepository
    {
        public Task<ReservationEntity> GetReservationByIdAsync(int id);
        public Task CreateReservationAsync(ReservationDTO reservationDTO);
        public Task UpdateReservationAsync(ReservationDTO reservationDTO);
        public Task DeleteReservationByIdAsync(int id);
    }
}
