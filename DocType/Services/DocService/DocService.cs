using DocType.Controllers.DocService.DTO.Request;
using DocType.Controllers.TImeManagementService.DTO;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.Data;
using DocType.DTO.Requests;
using DocType.Models;
using Microsoft.EntityFrameworkCore;

namespace DocType.Controllers.TImeManagementService
{
    public class DocService : IDocService
    {
        private readonly AppDbContext _context;

        public DocService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Doc?> GetDocByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.Doc.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Doc>> GetAllDocAsync(CancellationToken cancellationToken)
        {
            return await _context.Doc.ToListAsync(cancellationToken);
        }

        public async Task<bool> CreateDocAsync(RequestAddDoctorInformation request, CancellationToken cancellationToken)
        {
            string userId = "System";
            var entity = request.ToDomain(userId);
            await _context.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateDocInfoAsync(RequestUpdateDocInformation request, string userId, CancellationToken cancellationToken)
        {
            var existing = await _context.Doc.FirstOrDefaultAsync(p => p.Id == request.DocID, cancellationToken);
            if (existing == null) return false;

            existing.Cnic = request.Cnic;
            existing.Address = request.Address;
            existing.Email = request.Email;
            existing.PhoneNumber = request.PhoneNumber;
            existing.Address = request.Address;
            existing.City = request.City;
            existing.State = request.State;
            existing.ZipCode = request.ZipCode;
            existing.Country = request.Country;
            existing.Cnic = request.Cnic;
            existing.Gender = request.Gender;
            existing.CreatedBy = userId;
            existing.FullName = request.FullName;
            existing.HomeVisitFees = request.HomeVisitFees;
            existing.ConsultationFee = request.ConsultationFee;
            existing.Country = request.Country;
            existing.Specialization = request.Specialization;
          
            existing.UpdateRecordStatus(DateTime.UtcNow, "system");

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteDocAsync(string id, CancellationToken cancellationToken)
        {
            var profile = await _context.Doc.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (profile == null) return false;
            profile.IsActive = false;
            profile.UpdatedDate = DateTime.UtcNow;

            _context.Doc.Update(profile);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


    }
}
