﻿using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class CollectMetricController : Controller
    {
        private readonly ICollectMetricsService _metricsService;
        public CollectMetricController(ICollectMetricsService metricsService)
        {
            _metricsService = metricsService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDataCollect()
        {
            var listCollectData = await _metricsService.GetAllMetricDataAsync();
            return Ok(listCollectData);
        }
    }
}
