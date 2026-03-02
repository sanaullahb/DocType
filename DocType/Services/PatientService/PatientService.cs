using DocType.Data;
using DocType.Models;
using DocType.Services.PatientService.DTO;
using DocType.Services.PatientService.DTO.Request;
using DocType.Services.PatientService.DTO.Response;
using Microsoft.EntityFrameworkCore;

public class PatientService : IPatientService
{
    private readonly AppDbContext _context;

    public PatientService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == id && x.IsActive, cancellationToken);

        return patient;
    }

    public async Task<IEnumerable<Patient>> GetAllPatientAsync(CancellationToken cancellationToken)
    {
        return await _context.Patients.ToListAsync(cancellationToken);
    }

    public async Task<bool> CreateAsync(RequestAddPatient request, string userId, CancellationToken cancellationToken)
    {
        var entity = request.ToDomain(userId);
        await _context.Patients.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(RequestUpdatePatient request, string userId, CancellationToken cancellationToken)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.IsActive, cancellationToken);

        if (patient == null) return false;

        patient.FullName = request.FullName;
        patient.PhoneNumber = request.PhoneNumber;
        patient.Address = request.Address;

        patient.UpdateRecordStatus(DateTime.UtcNow, userId);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(string id, string userId, CancellationToken cancellationToken)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(x => x.Id == id && x.IsActive, cancellationToken);

        if (patient == null) return false;

        patient.SetSoftDelete();
        patient.UpdateRecordStatus(DateTime.UtcNow, userId);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}