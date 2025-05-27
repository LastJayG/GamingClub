using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Extensions;
using GamingClub.Domain.Entities;
using Google.Protobuf.WellKnownTypes;
using System.Globalization;

namespace GamingClub.Application.Mappers
{
    public static class ReservationServiceMapper
    {
        /// <summary>
        /// ReservationEntity
        /// </summary>
        public static ReservationRequestDTO MapToReservationDTO(this ReservationEntity entity) 
        {
            return new ReservationRequestDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                GamingStationId = entity.GamingStationId,
                StartTime = entity.StartDate.GetTimeCustomFormat(),
                Date = entity.StartDate.GetDateCustomFormat(),
            };
        }

        /// <summary>
        /// ReservationDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationRequestDTO DTO)
        {
            string dateTimeStr = $"{DTO.Date} {DTO.StartTime}"; // суммируем дату и время в одну строку
            DateTime dateTime = DateTime.ParseExact(
                    dateTimeStr,
                    "yyyy-MM-dd HH:mm",
                    CultureInfo.InvariantCulture
                );
            return new ReservationEntity
            {
                Id = DTO.Id,
                UserId = DTO.UserId,
                GamingStationId = DTO.GamingStationId,
                StartDate = dateTime,
                EndDate = dateTime + DTO.ReservationDuration
            };
        }

        /// <summary>
        /// ReservationUpdateDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationUpdateDTO DTO, int reservationId, int userId)
        {
            return new ReservationEntity
            {
                Id = reservationId,
                UserId = userId,
                GamingStationId = DTO.GamingStationId,
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate
            };
        }
    }
}
