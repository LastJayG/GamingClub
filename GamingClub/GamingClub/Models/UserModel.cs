using System.ComponentModel.DataAnnotations;

namespace GamingClub.Models
{
	public class UserModel
	{
		[Required]
		[MaxLength(30)]
		public string? Username { get; set; }

		[Required]
		[EmailAddress]
		public string? Email { get; set; }

		public int Id { get; set; }
		public string? HashPassword { get; set; }

        [Required]
        public ReservationHistoryModel? ReservationHistory { get; set; }
		static int GetRandomIdNumber()
		{
			var random = new Random();
			return random.Next();
		}
        static string GetRandomHashNumber()
        {
            var random = new Random();
            return random.Next().ToString();
        }

        public UserModel(string? username, string? email) {
			Username = username;
			Email = email;
			Id = GetRandomIdNumber();
            HashPassword = GetRandomHashNumber();
        }
    }
}
