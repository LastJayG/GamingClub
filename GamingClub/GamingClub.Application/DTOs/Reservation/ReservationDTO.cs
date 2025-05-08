using GamingClub.Application.DTOs.ReservationUnit;

namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<ReservationUnitDTO> ReservationUnits { get; set; }
    }
}
