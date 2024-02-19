using CRM.Commens;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Data.Models;
using MongoDB.Driver;

namespace CRM.Data.Repositories;

public class FanRepository(InventoryDatabase database) : IFanInteface
{
    private readonly InventoryDatabase _database = database;

    public async Task AddFanAsync(AddFan fan)
        => await _database.Fans.InsertOneAsync(fan.MapToFan());

    public async Task DeleteFanAsync(string Id)
        => await _database.Fans.DeleteOneAsync(f => f.Id == Id);
    public async Task UpdateFanAsync(Fan fan)
        => await _database.Fans.ReplaceOneAsync(f => f.Id == fan.Id, fan);

    public async Task<IEnumerable<FanWithTeachers>> GetAllFansWithTeachersAsync()
    {
        var fansWithTeachers = new List<FanWithTeachers>();

        var fans = await _database.Fans.Find(_ => true).ToListAsync();

        foreach (var fan in fans)
        {
            var teachers = await _database.Teachers.Find(t => t.FanIds.Contains(fan.Id)).ToListAsync();
            var teacherDtoList = teachers.Select(t => (TeacherDto)t).ToList();

            fansWithTeachers.Add(new FanWithTeachers
            {
                Fan = fan,
                Teachers = teacherDtoList
            });
        }

        return fansWithTeachers;
    }
    public async Task<FanWithTeachers> GetByIdFanWithTeachers(string Id)
    {
        var fan = await _database.Fans.Find(f => f.Id == Id).FirstOrDefaultAsync();
        if (fan == null)
        {
            return null;
        }

        var teachers = await _database.Teachers.Find(t => t.FanIds.Contains(Id)).ToListAsync();
        var teacherDtoList = teachers.Select(t => (TeacherDto)t).ToList();

        var fanWithTeachers = new FanWithTeachers
        {
            Fan = fan,
            Teachers = teacherDtoList
        };

        return fanWithTeachers;
    }

}
