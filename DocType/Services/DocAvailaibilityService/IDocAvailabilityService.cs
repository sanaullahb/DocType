using DocType.Models;
using DocType.Services.DocAvailaibilityService.DTO.Request;

namespace DocType.Services.DocAvailaibilityService
{
    public interface IDocAvailabilityService
    {
        Task<DocAvailability?> GetDocAvailabilityByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<DocAvailability>> GetAllDocAvailabilityAsync(CancellationToken cancellationToken);
        Task<bool> CreateDocAvailabilityAsync(RequestAddDocAvailability request, CancellationToken cancellationToken);
        Task<bool> UpdateDocAvailabilityAsync(RequestUpdateDocAvailability request, string userId, CancellationToken cancellationToken);
        Task<bool> DeleteDocAvailabilityAsync(string id, CancellationToken cancellationToken);
    }
}
