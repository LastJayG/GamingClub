using GamingClub.Domain.Entities;

namespace GamingClub.Domain.Interfaces
{
    public interface IReservationRepository
    {
        public Task<List<DateTime>> GetAllReservationStartTimesAsync();
        public Task<List<DateTime>> GetAllReservationEndTimesAsync();

        public Task<ReservationEntity> GetReservationByIdAsync(int id);
        public Task CreateReservationAsync(ReservationEntity reservation);
        public Task UpdateReservationAsync(ReservationEntity reservation);
        public Task DeleteReservationByIdAsync(int id);

    }
}
