using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MessageInChannelController : ControllerBase
{
    private readonly IMessageInChannelService _messageInChannelService;

    public MessageInChannelController(IMessageInChannelService messageInChannelService)
    {
        _messageInChannelService = messageInChannelService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMessageInChannel(int id)
    {
        var message = await _messageInChannelService.GetMessageInChannelAsync(id);
        return message == null ? NotFound() : Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMessageInChannel([FromBody] MessageInChannelCreateDto messageDto)
    {
        var message = new MessageInChannel
        {
            ChannelId = messageDto.ChannelId,
            Content = messageDto.Content,
            UserId = messageDto.UserId
        };

        var createdMessage = await _messageInChannelService.CreateMessageInChannelAsync(message);
        return CreatedAtAction(nameof(GetMessageInChannel), new { id = createdMessage.Id }, createdMessage);
    }

    [HttpGet("channel/{channelId}")]
    public async Task<IActionResult> GetAllMessagesInChannel(int channelId)
    {
        var messages = await _messageInChannelService.GetAllMessagesInChannelAsync(channelId);
        return Ok(messages);
    }
}
