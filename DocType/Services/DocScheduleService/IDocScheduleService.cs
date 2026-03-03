using DocType.Services.DocScheduleService.DTO.Request;
using DocType.Services.DocScheduleService.DTO.Response;

public interface IDoctorScheduleService
{
    Task<ResponseDoctorSchedule> AddAsync(RequestAddDoctorSchedule request, string userId);
    Task<ResponseDoctorSchedule> UpdateAsync(string id, RequestUpdateDoctorSchedule request, string userId);
    Task<bool> DeleteAsync(string id, string userId);
    Task<ResponseDoctorSchedule> GetByIdAsync(string id);
    Task<List<ResponseDoctorSchedule>> GetByDoctorAsync(string userId);
}