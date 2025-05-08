using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingClub.Domain.Entities
{
    [Table("reservation")]
    public class ReservationEntity    
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }

        public IEnumerable<ReservationUnitEntity> ReservationUnits { get; set; }
    }
}
