using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly IChannelService _channelService;

    public ChannelController(IChannelService channelService)
    {
        _channelService = channelService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChannel(int id)
    {
        var channel = await _channelService.GetChannelAsync(id);
        return channel == null ? NotFound() : Ok(channel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChannel([FromBody] ChannelCreateDto channelDto)
    {
        var channel = new Channel
        {
            Name = channelDto.Name,
            ServerId = channelDto.ServerId
        };

        var createdChannel = await _channelService.CreateChannelAsync(channel);
        return CreatedAtAction(nameof(GetChannel), new { id = createdChannel.Id }, createdChannel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChannels()
    {
        var channels = await _channelService.GetAllChannelsAsync();
        return Ok(channels);
    }
}
