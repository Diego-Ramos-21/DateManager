using DateManager.API.Models;

namespace DateManeger.API.Services.Interface
{
    public interface IDateManagerService
    {
        DateManagerPostModel ChangeDate(string date, char op, long value);
    }
}
