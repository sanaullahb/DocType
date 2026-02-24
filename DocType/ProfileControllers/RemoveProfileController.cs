using CustomHTTP;
using DocType.Generic;
using DocType.Services;
using KininTech.SqlMapping.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DocType.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public RemoveProfileController(IProfileService profile)
        {
            _profileService = profile;
        }

        [HttpDelete("{id}")]
        public async Task<IResult> RemoveProfile(string id, CancellationToken cancellationToken)
        {
            string message = "Success";
            int statusCode = HTTPStatusCode200.Ok;

            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new InvalidDataException("Profile id cannot be null");
                }

                var result = await _profileService.DeleteProfileAsync(id, cancellationToken);

                if (!result)
                {
                    statusCode = HTTPStatusCode400.NotFound;
                    message = "Profile not found";

                    return ApiResponseHelper.Convert(true, false, message, statusCode, null);
                }

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
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