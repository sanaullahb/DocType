using DocType.Enums;
using DocType.Services.DocAppointmentService.DTO.Request;
using DocType.Services.DocAppointmentService.DTO.Response;

namespace DocType.Services.DocAppointmentService
{
    public interface IAppointmentService
    {
        Task<ResponseAppointment> CreateAsync(RequestAddAppointment request, string userId);
        Task<ResponseAppointment> GetByIdAsync(string id);
        Task<List<ResponseAppointment>> GetByDoctorAsync(string doctorId);
        Task<List<ResponseAppointment>> GetByPatientAsync(string patientId);
        Task<ResponseAppointment> UpdateStatusAsync(string id, AppointmentStatus status, string userId);
        Task<bool> CancelAsync(string id, string userId);
    }
}
