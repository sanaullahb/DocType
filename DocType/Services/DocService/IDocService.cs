using DocType.Controllers.DocService.DTO.Request;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.Models;

namespace DocType.Controllers.TImeManagementService
{
    public interface IDocService
    {
        Task<bool> DeleteDocAsync(string id, CancellationToken cancellationToken);
        Task<bool> CreateDocAsync(RequestAddDoctorInformation request, CancellationToken cancellationToken);
        Task<Doc?> GetDocByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Doc>> GetAllDocAsync(CancellationToken cancellationToken);
        Task<bool> UpdateDocInfoAsync(RequestUpdateDocInformation request, string userId, CancellationToken cancellationToken); 

    }
}
