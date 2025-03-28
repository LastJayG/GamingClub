using System.ComponentModel.DataAnnotations;
using GamingClub.Core.Models.GameTariff;
using GamingClub.Models;

namespace GamingClub.Core.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public ReservationHistoryModel ReservationHistory { get; set; }
        public ICollection<GameReservationModel> Orders { get; set; }
    }
}
