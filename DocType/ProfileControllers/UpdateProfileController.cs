using CustomHTTP;
using DocType.Services;
using DocType.Generic;
using DocType.DTO.Requests;
using Microsoft.AspNetCore.Mvc;
using KininTech.SqlMapping.Exceptions;

namespace DocType.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public UpdateProfileController(IProfileService profile)
        {
            _profileService = profile;
        }

        [HttpPut]
        public async Task<IResult> UpdateProfile(RequestUpdateProfile request, CancellationToken cancellationToken)
        {
            string message = "Success";
            int statusCode = HTTPStatusCode200.Ok;

            try
            {
                if (request == null)
                {
                    throw new InvalidDataException("Request cannot be null");
                }

                var result = await _profileService.UpdateProfileAsync(request,"system" ,cancellationToken);

                if (!result)
                {
                    statusCode = HTTPStatusCode400.NotFound;
                    message = "Profile not found or update failed";

                    return ApiResponseHelper.Convert(true, false, message, statusCode, null);
                }

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
            }
            catch (InvalidOperationException e)
            {
                statusCode = HTTPStatusCode400.UnprocessableEntity;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (RecordNotFoundException e)
            {
                statusCode = HTTPStatusCode400.NotFound;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (InvalidDataException e)
            {
                statusCode = HTTPStatusCode400.UnprocessableEntity;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (Exception)
            {
                statusCode = HTTPStatusCode500.InternalServerError;
                message = ExceptionMessage.SWW;

                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }
        }
    }
}