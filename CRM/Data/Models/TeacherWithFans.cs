using CRM.Data.Entities;

namespace CRM.Data.Models;

public class TeacherWithFans
{
    public TeacherDto Teacher { get; set; }
    public List<Fan> Fans { get; set; }
}
