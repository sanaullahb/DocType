using DocType.Services.DocTimeSlotService.DTO.Request;
using DocType.Services.DocTimeSlotService.DTO.Response;

namespace DocType.Services.DocTimeSlotService
{
    public interface IDocTimeSlotService
    {
            Task<bool> GenerateSlotsAsync(string availabilityId, CancellationToken cancellationToken);
            Task<IEnumerable<ResponseDocTimeSlot>> GetSlotsByDoctorAndDateAsync(string doctorId, DateOnly date, CancellationToken cancellationToken);
            Task<bool> BookSlotAsync(RequestBookDocTimeSlot request, string userId, CancellationToken cancellationToken);
            Task<bool> CancelSlotAsync(string slotId, CancellationToken cancellationToken);
        }
    
}
