using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AttachmentController : ControllerBase
{
    private readonly IAttachmentService _attachmentService;

    public AttachmentController(IAttachmentService attachmentService)
    {
        _attachmentService = attachmentService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttachment(int id)
    {
        var attachment = await _attachmentService.GetAttachmentAsync(id);
        return attachment == null ? NotFound() : Ok(attachment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAttachment([FromBody] AttachmentCreateDto attachmentDto)
    {
        var attachment = new Attachment
        {
            FileName = attachmentDto.FileName,
            FileType = attachmentDto.FileType,
            MessageId = attachmentDto.MessageId
        };

        var createdAttachment = await _attachmentService.CreateAttachmentAsync(attachment);
        return CreatedAtAction(nameof(GetAttachment), new { id = createdAttachment.Id }, createdAttachment);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAttachments()
    {
        var attachments = await _attachmentService.GetAllAttachmentsAsync();
        return Ok(attachments);
    }
}
