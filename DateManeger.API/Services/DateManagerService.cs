using DateManager.API.Models;
using DateManeger.API.Services.Interface;
using System.Globalization;

namespace DateManager.API.Services
{
    public class DateManagerService : IDateManagerService
    {
        public DateManagerPostModel ChangeDate(string date, char op, long value)
        {
            string[] formats = { "dd/MM/yyyy", "dd/MM/yyyy HH:mm", "MM/dd/yyyy", "MM/dd/yyyy HH:mm", "dd-MM-yyyy", "dd-MM-yyyy HH:mm", "MM-dd-yyyy", "MM-dd-yyyy HH:mm", "yyyy-MM-dd", "yyyy-MM-dd HH:mm" };
            DateTime targetDate;
            DateTime.TryParseExact(date, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out targetDate);
            if (targetDate == DateTime.MinValue)
                throw new ArgumentException("Campo 'DateValue' não preenchido ou formatado incorretamente (Ex.: 'dd/MM/yyyy HH:mm')");
            switch (op)
            {
                case '+':
                    targetDate = targetDate.AddMinutes(value);
                    break;
                case '-':
                    targetDate = targetDate.AddMinutes(value * -1);
                    break;
                default:
                    throw new ArgumentException("Operador inválido! (Ex.: '+' e '-')");
            }
            return new DateManagerPostModel {
                DateValue = targetDate.ToString("dd/MM/yyyy HH:mm"),
                Op = op,
                Time = 0
            };
        }
    }
}
