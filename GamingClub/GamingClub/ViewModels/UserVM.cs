using GamingClub.Models;
using System.ComponentModel.DataAnnotations;

namespace GamingClub.ViewModels
{
    public class UserVM
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public ReservationHistoryModel? ReservationHistory { get; set; }

    }
}
