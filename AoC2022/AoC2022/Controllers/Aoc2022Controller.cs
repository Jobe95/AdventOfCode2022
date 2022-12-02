using AoC2022.Services;
using Microsoft.AspNetCore.Mvc;

namespace AoC2022.Controllers;

[ApiController]
[Route("[controller]")]
public class Aoc2022Controller : ControllerBase
{
    private readonly IAoc2022Service service;

    public Aoc2022Controller(IAoc2022Service service)
    {
        this.service = service;
    }

    [HttpGet("1b")]
    public int AoC1b()
    {
        return service.AoC001b();
    }

    [HttpGet("1a")]
    public int AoC1a()
    {
        return service.AoC001a();
    }

    [HttpGet("2a")]
    public int AoC2a()
    {
        return service.AoC002a();
    }

    [HttpGet("2b")]
    public int AoC2b()
    {
        return service.AoC002b();
    }

}