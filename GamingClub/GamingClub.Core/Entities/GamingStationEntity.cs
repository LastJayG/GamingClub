using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingClub.Domain.Entities
{
    [Table("gamingstation")]
    public class GamingStationEntity
    {
        [Key]
        public int Id { get; set; }
        public GamingStationType Type {  get; set; } 
        public IEnumerable<ReservationEntity> Reservations { get; set; }
    }
}
