using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Models;

namespace DocType.DTO
{
    public static class ProfileCRT
    {
        public static Profile ToDomain(this RequestAddProfile request, string userId)
        {

            var ProfileId = NanoId.Generate();  //Guid ID
            var now = DateTime.UtcNow;
            return new Profile()
            {
                Id = ProfileId,
                FirstName = request.FirstName,
                LastName = request.LastName,
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
                CreatedDate = now,
                IsArchived = false,
                UpdatedBy = userId,
            };
        }



    }
}
