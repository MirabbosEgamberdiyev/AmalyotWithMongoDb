using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Data.Models;
using CRM.Commens;
using MongoDB.Driver;



namespace CRM.Data.Repositories;

public class TeacherRepository(InventoryDatabase database) : ITeacherInteface
{
    private readonly InventoryDatabase _database = database;

    public async Task AddTeacherAsync(AddTeacher teacher)
           => await _database.Teachers.InsertOneAsync(teacher.MapToTeacher());

    public async Task DeleteTeacherAsync(string Id)
           => await _database.Teachers.DeleteOneAsync(t => t.Id == Id);



    public async Task<IEnumerable<TeacherWithFans>> GetAllTeachersWithFanAsync()
    {
        var teachers = await _database.Teachers.Find(_ => true).ToListAsync();
        var fans = await _database.Fans.Find(_ => true).ToListAsync();

        var teachersWithFans = new List<TeacherWithFans>();

        foreach (var teacher in teachers)
        {
            var teacherWithFans = new TeacherWithFans
            {
                Teacher = (TeacherDto)teacher,
                Fans = fans.FindAll(f => teacher.FanIds.Contains(f.Id))
            };
            teachersWithFans.Add(teacherWithFans);
        }

        return teachersWithFans;
    }



    public async Task<TeacherWithFans> GetByIdTeacherWithFanAsync(string Id)
    {
        var teacher = await _database.Teachers.Find(t => t.Id == Id).FirstOrDefaultAsync();
        if (teacher == null)
        {
            return null;
        }

        var fans = await _database.Fans.Find(f => teacher.FanIds.Contains(f.Id)).ToListAsync();

        var teacherWithFans = new TeacherWithFans
        {
            Teacher = (TeacherDto)teacher,
            Fans = fans
        };

        return teacherWithFans;
    }


    public async Task UpdateTeacher(Teacher teacher)
          => await _database.Teachers.ReplaceOneAsync(t => t.Id == teacher.Id, teacher);
}

