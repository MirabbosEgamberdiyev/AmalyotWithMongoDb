using CRM.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CRM.Data.Models;

public class TeacherDto : BaseEntity
{
    [Required, StringLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string LastName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public static implicit operator TeacherDto(Teacher teacher)
    {
        if (teacher == null)
            return null;

        return new TeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber,
            Password = teacher.Password
        };
    }

    public static implicit operator Teacher(TeacherDto teacher)
    {
        if (teacher == null)
            return null;

        return new Teacher
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            PhoneNumber = teacher.PhoneNumber,
            Password = teacher.Password
        };
    }
}
