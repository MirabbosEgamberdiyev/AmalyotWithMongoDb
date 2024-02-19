using CRM.Data.Entities;
using CRM.Data.Models;

namespace CRM.Data.Interfaces
{
    public interface IFanInteface
    {
        Task<IEnumerable<FanWithTeachers>> GetAllFansWithTeachersAsync();
        Task<FanWithTeachers> GetByIdFanWithTeachers(string Id);
        Task AddFanAsync(AddFan fan);
        Task UpdateFanAsync(Fan fan);
        Task DeleteFanAsync(string Id);
    }
}
