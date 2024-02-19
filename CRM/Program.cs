using CRM.Data;
using CRM.Data.Interfaces;
using CRM.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(st => new InventoryDatabase(
        builder.Configuration.GetConnectionString("MongoDB")!,
        builder.Configuration.GetConnectionString("Database")!
    ));
builder.Services.AddTransient<IFanInteface, FanRepository>();
builder.Services.AddTransient<ITeacherInteface, TeacherRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
