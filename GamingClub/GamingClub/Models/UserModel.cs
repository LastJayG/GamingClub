using System.ComponentModel.DataAnnotations;

namespace GamingClub.Models
{
	public class UserModel
	{
		[Required]
		public string? Username { get; set; }
		[Required]
		[EmailAddress]
		public string? Email { get; set; }
		public int Id { get; set; }
		public string? HashPassword { get; set; }
 
    }

}

