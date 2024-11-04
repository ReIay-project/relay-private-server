using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatController(IChatService chatService)
    {
        _chatService = chatService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetChat(int id)
    {
        var chat = await _chatService.GetChatAsync(id);
        return chat == null ? NotFound() : Ok(chat);
    }

    [HttpPost]
    public async Task<IActionResult> CreateChat([FromBody] ChatCreateDto chatDto)
    {
        var chat = new Chat
        {
            Name = chatDto.Title,
            Members = chatDto.MemberIds.Select(id => new User { Id = id }).ToList()
        };

        var createdChat = await _chatService.CreateChatAsync(chat);
        return CreatedAtAction(nameof(GetChat), new { id = createdChat.Id }, createdChat);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChats()
    {
        var chats = await _chatService.GetAllChatsAsync();
        return Ok(chats);
    }
}
