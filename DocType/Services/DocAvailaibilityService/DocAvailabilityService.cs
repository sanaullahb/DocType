using DocType.Controllers.DocService.DTO.Request;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.Data;
using DocType.Models;
using DocType.Services.DocAvailaibilityService.DTO;
using DocType.Services.DocAvailaibilityService.DTO.Request;
using Microsoft.EntityFrameworkCore;

namespace DocType.Services.DocAvailaibilityService
{
    public class DocAvailabilityService : IDocAvailabilityService
    {
        private readonly AppDbContext _context;

        public DocAvailabilityService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DocAvailability?> GetDocAvailabilityByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.DocAvailabilities.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<DocAvailability>> GetAllDocAvailabilityAsync(CancellationToken cancellationToken)
        {
            return await _context.DocAvailabilities.ToListAsync(cancellationToken);
        }

        public async Task<bool> CreateDocAvailabilityAsync(RequestAddDocAvailability request, CancellationToken cancellationToken)
        {
            string userId = "System";
            var entity = request.ToDomain(userId);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateDocAvailabilityAsync(RequestUpdateDocAvailability request, string userId, CancellationToken cancellationToken)
        {
            var existing = await _context.DocAvailabilities.FirstOrDefaultAsync(p => p.Id == request.ID, cancellationToken);
            if (existing == null) return false;

            existing.SlotDurationMinutes = request.SlotDurationMinutes;
            existing.AvailableDate = request.AvailableDate;
            existing.DoctorId =request.DocId;
            existing.StartTime = request.StartTime;
            existing.EndTime = request.EndTime;
            existing.UpdatedDate= DateTime.UtcNow;
            existing.UpdatedBy = userId;
            existing.CreatedBy = userId;
            existing.CreatedDate = DateTime.UtcNow;
      

            existing.UpdateRecordStatus(DateTime.UtcNow, "system");

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteDocAvailabilityAsync(string id, CancellationToken cancellationToken)
        {
            var profile = await _context.DocAvailabilities.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (profile == null) return false;
            profile.IsActive = false;
            profile.UpdatedDate = DateTime.UtcNow;

            _context.DocAvailabilities.Update(profile);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
