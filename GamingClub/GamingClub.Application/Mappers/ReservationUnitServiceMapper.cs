using GamingClub.Application.DTOs.ReservationUnit;
using GamingClub.Domain.Entities;

namespace GamingClub.Application.Mappers
{
    public static class ReservationUnitServiceMapper
    {
        /// <summary>
        /// ReservationUnitEntity
        /// </summary>
        public static ReservationUnitDTO MapToReservationUnitDTO(this ReservationUnitEntity entity)
        {
            return new ReservationUnitDTO
            {
                Id = entity.Id,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ReservationId = entity.ReservationId,
                GamingStationId = entity.GamingStationId
            };
        }

        public static ReservationUnitCreateDTO MapToReservationUnitCreateDTO(this ReservationUnitEntity entity)
        {
            return new ReservationUnitCreateDTO
            {
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                GamingStationId = entity.GamingStationId
            };
        }

        /// <summary>
        /// ReservationUnitDTO
        /// </summary>
        public static ReservationUnitEntity MapToReservationUnitEntity(this ReservationUnitDTO DTO)
        {
            return new ReservationUnitEntity
            {
                Id = DTO.Id,
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate,
                ReservationId = DTO.ReservationId,
                GamingStationId = DTO.GamingStationId
            };
        }

        /// <summary>
        /// ReservationUnitCreateDTO
        /// </summary>
        public static ReservationUnitEntity MapToReservationUnitEntity(this ReservationUnitCreateDTO DTO)
        {
            return new ReservationUnitEntity
            {
                StartDate = DTO.StartDate,
                EndDate = DTO.EndDate,
                GamingStationId = DTO.GamingStationId
            };
        }
    }
}
