using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingClub.Domain.Entities
{
    [Table("reservationunit")]
    public class ReservationUnitEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int ReservationId { get; set; }
        public ReservationEntity Reservation { get; set; }

        public int GamingStationId { get; set; }
        public GamingStationEntity GamingStation { get; set; }

    }
}
