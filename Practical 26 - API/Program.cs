using AutoMapper;
using Practical_26.Database;
using Practical_26.Interface;
using Practical_26.Mapping;
using Practical_26.Repository.CQRS;
using Practical_26.Repository.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddAutoMapper(opt => opt.AddProfile<MappingProfile>());

builder.Services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();
builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
builder.Services.AddScoped<IEmployeeCommands, EmployeeCommands>();
builder.Services.AddScoped<IEmployeeQueries, EmployeeQueries>();

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
