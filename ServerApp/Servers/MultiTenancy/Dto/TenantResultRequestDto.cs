using Abp.Application.Services.Dto;

namespace ServerApp.Servers.MultiTenancy.Dto
{
    public class TenantResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}