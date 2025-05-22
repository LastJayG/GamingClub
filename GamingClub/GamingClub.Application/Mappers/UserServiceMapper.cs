using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.DTOs.User;
using GamingClub.Domain.Entities;

namespace GamingClub.Application.Mappers
{
    public static class UserServiceMapper
    {
        /// <summary>
        /// UserEntity
        /// </summary>
        public static UserDTO MapToUserDTO(this UserEntity entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email
            };
        }

        public static UserUpdateDTO MapToUserUpdateDTO(this UserEntity entity)
        {
            return new UserUpdateDTO
            {
                Username = entity.Username,
                Email = entity.Email
            };
        }

        public static UserWithReservationsDTO MapToUserWithReservationsDTO(this UserEntity entity)
        {
            return new UserWithReservationsDTO
            {
                Username = entity.Username,
                Email = entity.Email,
                Reservations = from reservation in entity.Reservations
                               select reservation.MapToReservationDTO()
            };
        }

        /// <summary>
        /// UserDTO
        /// </summary>
        public static UserEntity MapToUserEntity(this UserDTO DTO)
        {
            return new UserEntity
            {
                Id = DTO.Id,
                Username = DTO.Username,
                Email = DTO.Email
            };
        }

        /// <summary>
        /// UserUpdateDTO
        /// </summary>
        public static UserEntity MapToUserEntity(this UserUpdateDTO DTO)
        {
            return new UserEntity
            {
                Username = DTO.Username,
                Email = DTO.Email
            };
        }

        /// <summary>
        /// UserWithReservationsDTO
        /// </summary>
        public static UserEntity MapToUserEntity(this UserWithReservationsDTO DTO)
        {
            return new UserEntity
            {
                Username = DTO.Username,
                Email = DTO.Email,
                Reservations = from reservation in DTO.Reservations
                               select reservation.MapToReservationEntity()
            };
        }
    }
}
