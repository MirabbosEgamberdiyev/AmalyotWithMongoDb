using CRM.Data.Entities;

namespace CRM.Data.Models;

public class FanWithTeachers
{
    public Fan Fan { get; set; }
    public List<TeacherDto> Teachers { get; set; }

}
