using GamingClub.Application.DTOs.Reservation;
using GamingClub.Domain.Entities;

namespace GamingClub.Application.Mappers
{
    public static class ReservationServiceMapper
    {
        /// <summary>
        /// ReservationEntity
        /// </summary>
        public static ReservationDTO MapToReservationDTO(this ReservationEntity entity) 
        {
            return new ReservationDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                GamingStationId = entity.GamingStationId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        /// <summary>
        /// ReservationDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationDTO DTO)
        {
            return new ReservationEntity
            {
                Id = DTO.Id,
                UserId = DTO.UserId,
                GamingStationId = DTO.GamingStationId,
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate
            };
        }

        /// <summary>
        /// ReservationUpdateDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationUpdateDTO DTO, int reservationId)
        {
            return new ReservationEntity
            {
                Id = reservationId,
                GamingStationId = DTO.GamingStationId,
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate
            };
        }
    }
}
