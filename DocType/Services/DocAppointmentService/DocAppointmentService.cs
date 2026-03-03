using DocType.Data;
using DocType.Enums;
using DocType.Services.DocAppointmentService.DTO.Request;
using DocType.Services.DocAppointmentService.DTO.Response;

namespace DocType.Services.DocAppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseAppointment> CreateAsync(
            RequestAddAppointment request,
            string userId)
        {
            // Prevent double booking
            var exists =  _context.Appointments.Any(x =>
                x.DoctorId == request.DoctorId &&
                x.AppointmentDate == request.AppointmentDate &&
                x.AppointmentTime == request.AppointmentTime &&
                x.Status != AppointmentStatus.Cancelled);

            if (exists)
                throw new Exception("Time slot already booked");

            // Example fees (later fetch from doctor profile)
            decimal doctorFee = 2000;
            decimal platformFee = 200;

            var entity = request.ToDomain(userId, doctorFee, platformFee);

            await _context.Appointments.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.ToResponse();
        }

        public async Task<ResponseAppointment> GetByIdAsync(string id)
        {
            var entity =  _context.Appointments
                .FirstOrDefault(x => x.Id == id && !x.IsArchived);

            if (entity == null)
                throw new Exception("Appointment not found");

            return entity.ToResponse();
        }

        public async Task<List<ResponseAppointment>> GetByDoctorAsync(string doctorId)
        {
            var list =  _context.Appointments
                .Where(x => x.DoctorId == doctorId && !x.IsArchived)
                .ToList();

            return list.Select(x => x.ToResponse()).ToList();
        }

        public async Task<List<ResponseAppointment>> GetByPatientAsync(string patientId)
        {
            var list =  _context.Appointments
                .Where(x => x.PatientId == patientId && !x.IsArchived)
                .ToList();

            return list.Select(x => x.ToResponse()).ToList();
        }

        public async Task<ResponseAppointment> UpdateStatusAsync(
            string id,
            AppointmentStatus status,
            string userId)
        {
            var entity =  _context.Appointments
                .FirstOrDefault(x => x.Id == id && !x.IsArchived);

            if (entity == null)
                throw new Exception("Appointment not found");

            entity.Status = status;
            entity.UpdateRecordStatus(DateTime.UtcNow, userId);

            await _context.SaveChangesAsync();

            return entity.ToResponse();
        }

        public async Task<bool> CancelAsync(string id, string userId)
        {
            var entity =  _context.Appointments
                .FirstOrDefault(x => x.Id == id && !x.IsArchived);

            if (entity == null)
                throw new Exception("Appointment not found");

            entity.Status = AppointmentStatus.Cancelled;
            entity.UpdateRecordStatus(DateTime.UtcNow, userId);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
