using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Models;

namespace DocType.Controllers.TImeManagementService.DTO
{
   
        public static class DoCCRT
        {
            public static Doc  ToDomain (this RequestAddDoctorInformation request, string userId)
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
                    Specialization  = request.Specialization,
                    ConsultationFee = request.ConsultationFee,  
                    IsActive = true,
                    isAvailable = request.isAvailable,  
                    UpdatedDate = DateTime.UtcNow,
                    CreatedDate = now,
                    IsArchived = false,
                    UpdatedBy = userId,
                };
            }

        }
}
