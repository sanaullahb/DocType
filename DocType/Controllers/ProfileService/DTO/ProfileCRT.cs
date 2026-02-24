using DocType.DTO.Requests;
using DocType.DTO.Response;
using DocType.Generic;
using DocType.Models;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
        public static  ResponseProfile ToResponse(this Profile pro, string userId)
        {
            return new ResponseProfile()
            {
                Id = pro.Id,
               Address = pro.Address,   
               City = pro.City, 
               Country = pro.Country,   
               State = pro.State,   
               Gender = pro.Gender, 
               ZipCode = pro.ZipCode,   
               Cnic  = pro.Cnic,    
               Email = pro.Email,   
               PhoneNumber = pro.PhoneNumber,   
               FirstName    = pro.FirstName,
               LastName= pro.LastName,
              
            };
        }


    }
}
