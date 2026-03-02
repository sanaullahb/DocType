using DocType.Models;
using DocType.Services.PatientService.DTO.Request;
using DocType.Services.PatientService.DTO.Response;

namespace DocType.Services.PatientService.DTO
{
    public static class CRT
    {
        public static Patient ToDomain(this RequestAddPatient req, string userId)
        {
            return new Patient
            {
                Id = Guid.NewGuid().ToString(),
                FullName = req.FullName,
                PhoneNumber = req.PhoneNumber,
                Address = req.Address,

                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true,
                IsArchived = false
            };
        }

        public static ResponsePatient ToResponse(this Patient patient)
        {
            return new ResponsePatient
            {
                Id = patient.Id,
                FullName = patient.FullName,
                PhoneNumber = patient.PhoneNumber,
                Address = patient.Address
            };
        }
    }
}