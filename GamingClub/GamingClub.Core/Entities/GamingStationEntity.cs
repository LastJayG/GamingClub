using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingClub.Core.Entities
{
    [Table("gamingstation")]
    public class GamingStationEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsFree { get; set; }
        public GamingStationType Type {  get; set; } 
        public List<ReservationEntity> Reservations { get; set; }
    }
}
