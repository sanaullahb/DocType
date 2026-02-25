using DocType.DTO.Requests;
using DocType.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DocType.Services
{
    public interface IProfileService
    {
        Task<bool> CreateProfileAsync(RequestAddProfile request, CancellationToken cancellationToken);
        Task<Profile?> GetProfileByIdAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Profile>> GetAllProfilesAsync(CancellationToken cancellationToken);  
        Task<bool> UpdateProfileAsync(RequestUpdateProfile request,string userId, CancellationToken cancellationToken);
        Task<bool> DeleteProfileAsync(string id, CancellationToken cancellationToken);
    }
}
