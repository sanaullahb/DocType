using DocType.Controllers.DocScheduleService.DTO.Response;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Models;

namespace DocType.Controllers.TImeManagementService.DTO
{

    public static class DoCCRT
    {
        public static Doc ToDomain(this RequestAddDoctorInformation request, string userId)
        {

            var DocId = NanoId.Generate();  //Guid ID
            var now = DateTime.UtcNow;
            return new Doc()
            {
                Id = DocId,
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                City = request.City,
                Cnic = request.Cnic,
                Country = request.Country,
                State = request.State,
                Gender = request.Gender,
                ZipCode = request.ZipCode,
                CreatedBy = userId,
                Specialization = request.Specialization,
                ConsultationFee = request.ConsultationFee,
                IsActive = true,
                isAvailable = request.isAvailable,
                UpdatedDate = DateTime.UtcNow,
                CreatedDate = now,
                IsArchived = false,
                UpdatedBy = userId,
                HomeVisitFees = request.HomeVisitFees,
                
            };
        }
        public static ResponseDocInformation ToResponse(this Doc doc)
        {
            return new ResponseDocInformation()
            {
                Id = doc.Id,
                FullName = doc.FullName,
                Email = doc.Email,
                PhoneNumber = doc.PhoneNumber,
                Address = doc.Address,
                City = doc.City,
                Country = doc.Country,
                State = doc.State,
                Gender = doc.Gender,
                ZipCode = doc.ZipCode,
                Cnic = doc.Cnic,
                ConsultationFee = doc.ConsultationFee,
                isAvailable = doc.isAvailable,
                Specialization = doc.Specialization,

            };

        }
    }
}
