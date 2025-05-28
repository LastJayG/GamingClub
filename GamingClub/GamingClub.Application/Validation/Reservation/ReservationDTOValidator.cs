using FluentValidation;
using GamingClub.Application.DTOs.Reservation;
using System.Globalization;
using System.Text.RegularExpressions;

namespace GamingClub.Application.Validation.Reservation
{
    public class ReservationDTOValidator : AbstractValidator<ReservationRequestDTO>
    {
        public ReservationDTOValidator() {
            RuleFor(DTO => DTO.StartTime).Must(BeAValidTime).WithMessage("Enter a correct time in HH:mm format");
            RuleFor(DTO => DTO.Date).Must(BeAValidDate).WithMessage("Enter a correct date in yyyy-MM-dd format");
            RuleFor(DTO => DTO.ReservationDuration).Must(BeAValidDuration).WithMessage("Enter a correct duration in HH:mm format");
            //Можно ли при валидации обращаться к БД? Я бы тут достала список существующих айди вместо статического списка внутри этого класса
            //RuleFor(DTO => DTO.GamingStationId).Must(BeAnExistingId); 
        }

        private bool BeAValidTime(string time) {

            if (!Regex.IsMatch(time, @"^([01][0-9]|2[0-3]):[0-5][0-9]$"))
                return false;

            if (DateTime.TryParseExact(time, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime.Minute == 0 || dateTime.Minute == 30;
            }

            return false;
        }
        private bool BeAValidDate(string date)
        {
            if (!Regex.IsMatch(date, @"^\d{4}-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])$"))
                return false;

            return DateTime.TryParseExact(date, "yyyy-MM-dd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }

        private bool BeAValidDuration(TimeSpan duration)
        {
            bool is30MinuteInterval = duration.Minutes == 0 || duration.Minutes == 30;
            bool isNonNegative = duration >= TimeSpan.Zero;
            bool isWithin6Hours = duration <= TimeSpan.FromHours(6);

            return is30MinuteInterval && isNonNegative && isWithin6Hours;
        }
    }
}
