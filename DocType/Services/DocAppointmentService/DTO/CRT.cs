using DocType.Enums;
using DocType.Models;
using DocType.Services.DocAppointmentService.DTO.Request;
using DocType.Services.DocAppointmentService.DTO.Response;

public static class AppointmentMapping
{
    public static Appointment ToDomain(
        this RequestAddAppointment req,
        string userId,
        decimal doctorFee,
        decimal platformFee)
    {
        return new Appointment
        {
            Id = Guid.NewGuid().ToString(),

            DoctorId = req.DoctorId,
            PatientId = req.PatientId,

            AppointmentDate = req.AppointmentDate,
            AppointmentTime = req.AppointmentTime,

            AppointmentType = req.AppointmentType,
            Status = AppointmentStatus.Pending,

            DoctorFee = doctorFee,
            PlatformFee = platformFee,
            TotalAmount = doctorFee + platformFee,

            PaymentStatus = PaymentStatus.Unpaid,

           

            CreatedBy = userId,
            UpdatedBy = userId,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow,
            IsActive = true,
            IsArchived = false
        };
    }

    public static ResponseAppointment ToResponse(this Appointment entity)
    {
        return new ResponseAppointment
        {
            Id = entity.Id,
            DoctorId = entity.DoctorId,
            PatientId = entity.PatientId,
            AppointmentDate = entity.AppointmentDate,
            AppointmentTime = entity.AppointmentTime,
            AppointmentType = entity.AppointmentType,
            Status = entity.Status,
            DoctorFee = entity.DoctorFee,
            PlatformFee = entity.PlatformFee,
            TotalAmount = entity.TotalAmount,
            PaymentStatus = entity.PaymentStatus,
       
        };
    }
}