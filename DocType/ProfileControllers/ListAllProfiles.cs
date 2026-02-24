using CustomHTTP;
using DocType.Services;
using DocType.Generic;
using Microsoft.AspNetCore.Mvc;

namespace DocType.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllProfilesController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public GetAllProfilesController(IProfileService profile)
        {
            _profileService = profile;
        }

        [HttpGet]
        public async Task<IResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            string message = "Success";
            int statusCode = HTTPStatusCode200.Ok;

            try
            {
                var result = await _profileService.GetAllProfilesAsync(cancellationToken);

                if (result == null || !result.Any())
                {
                    statusCode = HTTPStatusCode400.NotFound;
                    message = "No profiles found";

                    return ApiResponseHelper.Convert(true, false, message, statusCode, null);
                }

                return ApiResponseHelper.Convert(true, true, message, statusCode, result);
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