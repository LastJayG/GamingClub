using FluentValidation;
using GamingClub.Application.DTOs.Reservation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GamingClub.Application.Validation.Reservation
{
    public class ReservationDTOValidator : AbstractValidator<ReservationDTO>
    {
        public ReservationDTOValidator() {
            RuleFor(reservationDTO => reservationDTO.StartDate).Must(BeAValidTime).WithMessage("Enter a corect date in yyyy-MM-dd HH:mm:ss format");
            RuleFor(reservationDTO => reservationDTO.EndDate).Must(BeAValidTime).WithMessage("Enter a corect date in yyyy-MM-dd HH:mm:ss format");
        }

        private bool BeAValidTime(DateTime time) {

            var expr = time.ToString();
            if (!Regex.IsMatch(expr, @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])\s([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$"))
                return false;

            if (DateTime.TryParseExact(expr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime.Minute == 0 || dateTime.Minute == 30;
            }

            return false;
        }
    }
}
