using DocType.Models;
using DocType.Services.DocTimeSlotService.DTO.Request;
using DocType.Services.DocTimeSlotService.DTO.Response;

namespace DocType.Services.DocTimeSlotService.DTO
{
    public static class CRT
    {
        //public static DocTimeSlot ToDomain(this RequestAddDocTimeSlot req, string userId)
        //{
        //    return new DocTimeSlot
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        DoctorId = req.DoctorId,
        //        Date = req.Date,
        //        Time = req.StartTime,
        //        Type = req.Type,
        //        IsBooked = false,
        //        IsActive = true,
        //        IsArchived = false,
        //        CreatedDate = DateTime.UtcNow,
        //        UpdatedDate = DateTime.UtcNow,
        //        CreatedBy = userId,
        //        UpdatedBy = userId
        //    };
        //}
      
            public static ResponseDocTimeSlot ToResponse(this DocTimeSlot slot)
            {
                return new ResponseDocTimeSlot
                {
                    Id = slot.Id,
                    DoctorId = slot.DoctorId,
                    Date = slot.Date,
                    Time = slot.Time,
                    IsBooked = slot.IsBooked
                };
            }
        
    }
}
