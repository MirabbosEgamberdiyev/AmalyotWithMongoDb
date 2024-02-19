using CRM.Data.Entities;
using CRM.Data.Models;

namespace CRM.Data.Interfaces;

public interface ITeacherInteface
{
    Task<IEnumerable<TeacherWithFans>> GetAllTeachersWithFanAsync();
    Task<TeacherWithFans> GetByIdTeacherWithFanAsync(string Id);
    Task AddTeacherAsync(AddTeacher teacher);
    Task UpdateTeacher(Teacher teacher);
    Task DeleteTeacherAsync(string Id);
}
