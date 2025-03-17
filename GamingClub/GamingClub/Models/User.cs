using System.ComponentModel.DataAnnotations;

namespace GamingClub.Models
{
	public class User
	{
		[Required]
		public string? Name { get; set; }
		[Required]
		public string? Email { get; set; }
		public Guid Id { get; set; }
		public string? Password { get; set; }
 
    }

}

