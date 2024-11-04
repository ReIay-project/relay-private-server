using Microsoft.AspNetCore.Mvc;
using Relay.Services;
using Relay.DTOs;
using Microsoft.Extensions.Logging;
using System.Globalization;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;
    private readonly ILogger<RolesController> _logger;

    public RolesController(IRoleService roleService, ILogger<RolesController> logger)
    {
        _roleService = roleService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var culture = HttpContext.Items["RequestCulture"] as CultureInfo ?? new CultureInfo("ru");
        _logger.LogInformation("Получение роли на языке: {Culture}", culture.Name);

        var role = await _roleService.GetRoleAsync(id);
        if (role == null)
        {
            _logger.LogWarning("Роль с ID {RoleId} не найдена", id);
            return NotFound();
        }
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto roleDto)
    {
        var culture = HttpContext.Items["RequestCulture"] as CultureInfo ?? new CultureInfo("ru");
        _logger.LogInformation("Создание роли '{RoleName}' на языке {Culture}", roleDto.Name, culture.Name);

        var role = await _roleService.CreateRoleAsync(roleDto);
        return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
    }
}
