using DocType.Models;
using DocType.Services.DocScheduleService.DTO.Request;
using DocType.Services.DocScheduleService.DTO.Response;

namespace DocType.Services.DocScheduleService.DTO
{
    public static class DoctorScheduleMapping
    {
        public static DoctorSchedule ToDomain(this RequestAddDoctorSchedule req,string userId)
        {
            return new DoctorSchedule
            {
                Id = Guid.NewGuid().ToString(),
                StartTime = req.StartTime,
                EndTime = req.EndTime,
                Title = req.Title,
                Description = req.Description,
                Type = req.Type,
                UserId = userId,
        

                CreatedBy = userId,
                UpdatedBy = userId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                IsActive = true,
                IsArchived = false
            };
        }

        public static void UpdateDomain(
            this DoctorSchedule entity,
            RequestUpdateDoctorSchedule req,
            string userId)
        {
            entity.StartTime = req.StartTime;
            entity.EndTime = req.EndTime;
            entity.Title = req.Title;
            entity.Description = req.Description;
            entity.Type = req.Type;

            entity.UpdateRecordStatus(DateTime.UtcNow, userId);
        }

        public static ResponseDoctorSchedule ToResponse(this DoctorSchedule entity)
        {
            return new ResponseDoctorSchedule
            {
                Id = entity.Id,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                Title = entity.Title,
                Description = entity.Description,
                Type = entity.Type,
                UserId = entity.UserId,
                UserName = entity.UserName
            };
        }
    }
}
