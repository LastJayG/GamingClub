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
                ReservationUnits = from unit in entity.ReservationUnits
                                   select unit.MapToReservationUnitDTO()
            };
        }

        public static ReservationCreateDTO MapToReservationCreateDTO(this ReservationEntity entity)
        {
            return new ReservationCreateDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ReservationUnits = from unit in entity.ReservationUnits
                                   select unit.MapToReservationUnitCreateDTO()
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
                ReservationUnits = from unit in DTO.ReservationUnits
                                   select unit.MapToReservationUnitEntity()
            };
        }

        /// <summary>
        /// ReservationCreateDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationCreateDTO DTO)
        {
            return new ReservationEntity
            {
                Id = DTO.Id,
                UserId = DTO.UserId,
                ReservationUnits = from unit in DTO.ReservationUnits
                                   select unit.MapToReservationUnitEntity()
            };
        }

        /// <summary>
        /// ReservationUpdateDTO
        /// </summary>
        public static ReservationEntity MapToReservationEntity(this ReservationUpdateDTO DTO)
        {
            return new ReservationEntity
            {
                Id = DTO.Id,
                UserId = DTO.UserId,
                ReservationUnits = from unit in DTO.ReservationUnits
                                   select unit.MapToReservationUnitEntity()
            };
        }
    }
}
