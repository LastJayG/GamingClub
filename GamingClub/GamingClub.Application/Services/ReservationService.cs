using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class ReservationService(IReservationRepository reservationRepository) : IReservationService
    {

        private readonly TimeSpan _openingTime = new (9, 0, 0);
        private readonly TimeSpan _closingTime = new (23, 0, 0);
        private readonly TimeSpan _slotInterval = new (0, 30, 0);

        public async Task<ReservationRequestDTO> GetReservationByIdAsync(int id)
        {
            return (await reservationRepository.GetReservationByIdAsync(id))
                    .MapToReservationDTO();
        }

        public async Task CreateReservationAsync(ReservationRequestDTO reservation)
        {
            var reservationEntity = reservation.MapToReservationEntity();
            await reservationRepository.CreateReservationAsync(reservationEntity);
        }

        public async Task UpdateReservationAsync(ReservationUpdateDTO reservation, int id, int userId)
        {
            var reservationEntity = reservation.MapToReservationEntity(id, userId);
            await reservationRepository.UpdateReservationAsync(reservationEntity);
        }

        public async Task DeleteReservationByIdAsync(int id)
        {
            await reservationRepository.DeleteReservationByIdAsync(id);
        }

        public async Task<List<string>> GetAvailableTimeSlotsAsync(TimeSpan duration, int stationId, DateTime date)
        {

            var reservations = await reservationRepository.GetReservationsByDateAsync(date, stationId);

            var allSlots = new List<TimeSpan>();
            for (var time = _openingTime; time <= _closingTime - duration; time = time.Add(_slotInterval))
            {
                allSlots.Add(time);
            }

            var availableSlots = new List<string>();

            foreach (var slot in allSlots)
            {
                bool isAvailable = true;
                TimeSpan slotEnd = slot + duration;

                foreach (var reservation in reservations)
                {
                    TimeSpan resStart = reservation.StartDate.TimeOfDay;
                    TimeSpan resEnd = reservation.EndDate.TimeOfDay;

                    if (slot < resEnd && slotEnd > resStart)
                    {
                        isAvailable = false;
                        break;
                    }
                }

                if (isAvailable)
                {
                    availableSlots.Add(slot.ToString(@"hh\:mm"));
                }
            }

            return availableSlots;
        }

    }
}
