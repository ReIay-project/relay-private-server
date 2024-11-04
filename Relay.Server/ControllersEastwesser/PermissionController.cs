using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Relay.Models;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _permissionService;

    public PermissionController(IPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPermission(int id)
    {
        var permission = await _permissionService.GetPermissionAsync(id);
        return permission == null ? NotFound() : Ok(permission);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePermission([FromBody] PermissionCreateDto permissionDto)
    {
        var permission = new Permission
        {
            Name = permissionDto.Name,
            Description = permissionDto.Description
        };

        var createdPermission = await _permissionService.CreatePermissionAsync(permission);
        return CreatedAtAction(nameof(GetPermission), new { id = createdPermission.Id }, createdPermission);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPermissions()
    {
        var permissions = await _permissionService.GetAllPermissionsAsync();
        return Ok(permissions);
    }
}
