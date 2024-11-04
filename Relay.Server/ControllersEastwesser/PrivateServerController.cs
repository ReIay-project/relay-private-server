using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PrivateServerController : ControllerBase
{
    private readonly IPrivateServerService _privateServerService;

    public PrivateServerController(IPrivateServerService privateServerService)
    {
        _privateServerService = privateServerService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPrivateServer(int id)
    {
        var server = await _privateServerService.GetPrivateServerAsync(id);
        return server == null ? NotFound() : Ok(server);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrivateServer([FromBody] PrivateServerCreateDto serverDto)
    {
        var server = new PrivateServer
        {
            Name = serverDto.Name,
            OwnerId = serverDto.OwnerId
        };

        var createdServer = await _privateServerService.CreatePrivateServerAsync(server);
        return CreatedAtAction(nameof(GetPrivateServer), new { id = createdServer.Id }, createdServer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPrivateServers()
    {
        var servers = await _privateServerService.GetAllPrivateServersAsync();
        return Ok(servers);
    }
}
