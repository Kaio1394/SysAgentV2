using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Repository;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services;
using SysAgentV2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICollectMetricsService, CollectMetricsService>();
builder.Services.AddScoped<ICollectMetricsRepository, CollectMetricsRepository>();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=SysAgent.db"));

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
