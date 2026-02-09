using DocType.Data;
using DocType.DTO;
using DocType.DTO.Requests;
using DocType.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DocType.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _context;

        public ProfileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Profile?> GetProfileByIdAsync(string id, CancellationToken cancellationToken)
        {
            return await _context.Profile.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<Profile>> GetAllProfilesAsync(CancellationToken cancellationToken)
        {
            return await _context.Profile.ToListAsync(cancellationToken);
        }

        public async Task<bool> CreateProfileAsync(RequestAddProfile request, CancellationToken cancellationToken)
        {
            string userId = "System";
            var entity = request.ToDomain(userId);
            await _context.AddAsync(entity, cancellationToken);     
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateProfileAsync(RequestUpdateProfile request,string userId, CancellationToken cancellationToken)
        {
            var existing = await _context.Profile.FirstOrDefaultAsync(p => p.Id == request.ProfileId, cancellationToken);
            if (existing == null) return false;

            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.Email = request.Email;
            existing.PhoneNumber = request.PhoneNumber;
            existing.Address = request.Address;
            existing.City = request.City;
            existing.State = request.State;
            existing.ZipCode = request.ZipCode;
            existing.Country = request.Country;
            existing.Cnic =     request.Cnic;
            existing.Gender = request.Gender;
            existing.CreatedBy =  userId; 
            existing.UpdateRecordStatus(DateTime.UtcNow, "system");

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> DeleteProfileAsync(string id, CancellationToken cancellationToken)
        {
            var profile = await _context.Profile.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (profile == null) return false;
            profile.IsActive = false;
            profile.UpdatedDate = DateTime.UtcNow;

            _context.Profile.Update(profile);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
