using DocType.Models;
using DocType.Services.DocTimeSlotService.DTO.Request;

namespace DocType.Services.DocTimeSlotService.DTO
{
    public static class CRT
    {
        public static DocTimeSlot ToDomain(this RequestAddDocTimeSlot req, string userId)
        {
            return new DocTimeSlot
            {
                Id = Guid.NewGuid().ToString(),
                DoctorId = req.DoctorId,
                Date = req.Date,
                Time = req.StartTime,
                Type = req.Type,
                IsBooked = false,
                IsActive = true,
                IsArchived = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = userId,
                UpdatedBy = userId
            };
        }
    }
}
