using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SysAgentV2.Data;
using SysAgentV2.Helpers;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using SysAgentV2.Repository;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services;
using SysAgentV2.Services.Interfaces;
using SysAgentV2.Worker;
using System.ComponentModel.Design;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Console()
//    .CreateBootstrapLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICollectMetricsService, CollectMetricsService>();
builder.Services.AddScoped<ICollectMetricsRepository, CollectMetricsRepository>();

builder.Services.AddScoped<IAgentExecutionStatusRepository, AgentExecutionStatusRepository>();
builder.Services.AddScoped<IAgentExecutionStatusService, AgentExecutionStatusService>();

builder.Services.AddScoped<IScriptCmdRepository, ScriptCmdRepository>();
builder.Services.AddScoped<IScriptCmdService, ScriptCmdService>();

builder.Services.AddScoped<IAgentHealthStatusService, AgentHealthStatusService>();
builder.Services.AddScoped<IAgentHealthStatusRepository, AgentHealthStatusRepository>();

builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();


builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IAgentHardwareInfo, AgentHardwareInfo>();

builder.Services.AddDbContext<SysDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHostedService<StatusCollectDataWorker>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();