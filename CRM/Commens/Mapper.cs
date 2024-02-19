using CRM.Data.Entities;
using CRM.Data.Models;

namespace CRM.Commens;

public static class Mapper
{
    public static Fan MapToFan(this AddFan fan)
        => new()
        {
             FanName = fan.FanName,
             FanDescription = fan.FanDescription
        };

    public static Teacher MapToTeacher(this AddTeacher teacher)
        => new Teacher
        {
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber,
            Password = teacher.Password,
            FanIds = teacher.FanIds ?? new List<string>()
        };

}
