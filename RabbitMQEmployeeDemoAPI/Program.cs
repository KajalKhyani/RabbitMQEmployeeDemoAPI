using RabbitMQEmployeeDemoAPI.Data;
using RabbitMQEmployeeDemoAPI.RabitMQ;
using RabbitMQEmployeeDemoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IRabitMQProducer, RabitMQProducer>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
