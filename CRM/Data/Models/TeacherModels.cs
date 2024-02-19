using CRM.Data.Entities;

namespace CRM.Data.Models;


public record AddTeacher(string FirstName,
                         string LastName,
                         string PhoneNumber,
                         string Password,
                         List<string> FanIds);

