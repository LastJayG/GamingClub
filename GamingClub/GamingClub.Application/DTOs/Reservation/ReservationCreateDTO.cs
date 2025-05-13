using GamingClub.Application.DTOs.ReservationUnit;

namespace GamingClub.Application.DTOs.Reservation
{
    public class ReservationCreateDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public IEnumerable<ReservationUnitCreateDTO> ReservationUnits { get; set; }
    }
}
