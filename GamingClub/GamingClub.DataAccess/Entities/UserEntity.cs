using System.ComponentModel.DataAnnotations;

namespace GamingClub.DataAccess.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? HashPassword { get; set; }

        //[Required]
        //public ReservationHistoryModel ReservationHistory { get; set; }
        public ICollection<GameReservationEntity>? GameReservations { get; set; }
    }
}
