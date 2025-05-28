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
using System.ComponentModel.Design;

try
{
    var builder = WebApplication.CreateBuilder(args);

    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

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

    builder.Services.AddScoped<IHelper, Helper>();
    builder.Services.AddScoped<IAgentHardwareInfo, AgentHardwareInfo>();

    builder.Services.AddDbContext<SysDbContext>(opt =>
        opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
}
catch (Exception ex)
{
    Log.Error($"error: {ex.Message}");
	throw;
}
finally
{
    Log.CloseAndFlush();
}