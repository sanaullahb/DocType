using DocType.Generic;
using DocType.Models;
using DocType.Services.DocAvailaibilityService.DTO.Request;
using DocType.Services.DocAvailaibilityService.DTO.Response;
using System.Runtime.CompilerServices;

namespace DocType.Services.DocAvailaibilityService.DTO
{
    public static class CRT
    {
        public static DocAvailability ToDomain(this RequestAddDocAvailability obj,string userID) {

            return new DocAvailability()
            {
                Id = NanoId.Generate(),    
                DoctorId = obj.DocId,
                SlotDurationMinutes = obj.SlotDurationMinutes,
                IsActive = true,
                IsArchived = false,
                AvailableDate = obj.AvailableDate,
                CreatedBy    =  userID,
                UpdatedBy = userID,
                CreatedDate = DateTime.UtcNow,
                StartTime = obj.StartTime,
                EndTime  = obj.EndTime, 
                UpdatedDate = DateTime.UtcNow,      

            };
        }
        public static ResponseDocAvailability ToDomain(this DocAvailability obj, string userID)
        {

            return new ResponseDocAvailability()
            {
                Id = obj.Id,
                DocId = obj.DoctorId,
                SlotDurationMinutes = obj.SlotDurationMinutes,
                //IsActive = true,
                //IsArchived = false,
                AvailableDate = obj.AvailableDate,
                //CreatedBy = userID,
                //UpdatedBy = userID,
                //CreatedDate = DateTime.UtcNow,
                StartTime = obj.StartTime,
                EndTime = obj.EndTime,
                //UpdatedDate = DateTime.UtcNow,

            };
        }

    }
}
