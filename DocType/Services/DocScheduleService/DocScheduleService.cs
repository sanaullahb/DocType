using DocType.Data;
using DocType.Services.DocScheduleService.DTO;
using DocType.Services.DocScheduleService.DTO.Request;
using DocType.Services.DocScheduleService.DTO.Response;

public class DoctorScheduleService : IDoctorScheduleService
{
    private readonly AppDbContext _context;

    public DoctorScheduleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDoctorSchedule> AddAsync(      RequestAddDoctorSchedule request,      string userId)
    {
        if (request.EndTime <= request.StartTime)
            throw new Exception("EndTime must be greater than StartTime");

        var entity = request.ToDomain(userId);

        await _context.DoctorSchedules.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity.ToResponse();
    }

    public async Task<ResponseDoctorSchedule> UpdateAsync(
        string id,
        RequestUpdateDoctorSchedule request,
        string userId)
    {
        var entity = _context.DoctorSchedules
            .FirstOrDefault(x => x.Id == id && !x.IsArchived);

        if (entity == null)
            throw new Exception("Schedule not found");

        if (request.EndTime <= request.StartTime)
            throw new Exception("EndTime must be greater than StartTime");

        entity.UpdateDomain(request, userId);

        await _context.SaveChangesAsync();

        return entity.ToResponse();
    }

    public async Task<bool> DeleteAsync(string id, string userId)
    {
        var entity =  _context.DoctorSchedules
            .FirstOrDefault(x => x.Id == id && !x.IsArchived);

        if (entity == null)
            throw new Exception("Schedule not found");

        entity.SetSoftDelete();
        entity.UpdateRecordStatus(DateTime.UtcNow, userId);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<ResponseDoctorSchedule> GetByIdAsync(string id)
    {
        var entity = _context.DoctorSchedules
            .FirstOrDefault(x => x.Id == id && !x.IsArchived);

        if (entity == null)
            throw new Exception("Schedule not found");

        return entity.ToResponse();
    }

    public async Task<List<ResponseDoctorSchedule>> GetByDoctorAsync(string userId)
    {
        var list =  _context.DoctorSchedules
            .Where(x => x.UserId == userId && !x.IsArchived)
            .ToList();

        return list.Select(x => x.ToResponse()).ToList();
    }
}