using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Interfaces;

namespace GamingClub.Application.Services
{
    public class ReservationService(IReservationRepository reservationRepository) : IReservationService
    {
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

        public async Task<List<string>> GetAvailableTimeSlotsAsync(TimeSpan duration)
        {
           
            TimeSpan openingTime = new TimeSpan(9, 0, 0); 
            TimeSpan closingTime = new TimeSpan(23, 0, 0);
            TimeSpan slotInterval = new TimeSpan(0, 30, 0);

            var reservations = await reservationRepository.GetReservationsByDateAsync(new DateTime(2025, 5, 27));

            var allSlots = new List<TimeSpan>();
            for (var time = openingTime; time <= closingTime - duration; time = time.Add(slotInterval))
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
