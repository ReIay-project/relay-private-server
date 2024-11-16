using Abp.Application.Services.Dto;

namespace ServerApp.Servers.Roles.Dto
{
    public class RoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}