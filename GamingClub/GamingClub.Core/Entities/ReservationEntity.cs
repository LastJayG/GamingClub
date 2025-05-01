using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingClub.Core.Entities
{
    [Table("reservation")]
    public class ReservationEntity    
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public List<GamingStationEntity> GameStations { get; set; }
    }
}
