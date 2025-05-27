using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Extensions;
using GamingClub.Application.Interfaces;
using GamingClub.Application.Mappers;
using GamingClub.Domain.Entities;
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

        //public async Task<List<TimeOnly>> FindAvailableTimeSlots(ReservationDTO reservationDTO, List<ReservationEntity> existingReservations)
        //{

        //}
        

        public async Task<List<TimeSpan>> ReturnAvailableReservationStartTimePointsAsync(TimeSpan timeSpan)
        {
            var startDatesList = await reservationRepository.GetAllReservationStartTimesAsync();
            var endDatesList = await reservationRepository.GetAllReservationEndTimesAsync();
            var list = new List<TimeSpan>();

            for (int i = 0; i < startDatesList.Count; i++)
            {
                if (timeSpan.IsInTimeSlot(startDatesList[i].TimeOfDay, endDatesList[i].TimeOfDay)) 
                    list.Add(timeSpan);
            }

            return list;
        }

    }
}
