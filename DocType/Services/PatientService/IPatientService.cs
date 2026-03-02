using DocType.Models;
using DocType.Services.PatientService.DTO.Request;
using DocType.Services.PatientService.DTO.Response;

public interface IPatientService
{
    Task<Patient?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IEnumerable<Patient>> GetAllPatientAsync(CancellationToken cancellationToken);
    Task<bool> CreateAsync(RequestAddPatient request, string userId, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(RequestUpdatePatient request, string userId, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(string id, string userId, CancellationToken cancellationToken);
}