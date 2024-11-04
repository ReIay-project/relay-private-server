using System.Collections.Generic;
using System.Threading.Tasks;
using Relay.Models;

namespace Relay.Services
{
    public interface IAttachmentService
    {
        Task<Attachment?> GetAttachmentAsync(int id); // Возможен возврат null, если вложение не найдено
        Task<Attachment> CreateAttachmentAsync(Attachment attachment);
        Task<IEnumerable<Attachment>> GetAllAttachmentsAsync();
    }
}
