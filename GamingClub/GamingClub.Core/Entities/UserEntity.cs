using System.ComponentModel.DataAnnotations;

namespace GamingClub.Core.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IEnumerable<ReservationEntity> Reservations { get; set; }
    }
}
