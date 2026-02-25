using CustomHTTP;
using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Services;
using KininTech.SqlMapping.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DocType.ProfileControllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        #region CREATE

        [HttpPost]
        public async Task<IResult> CreateProfile(RequestAddProfile request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                var result = await _profileService.CreateProfileAsync(request, cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Created Successfully",
                    HTTPStatusCode200.Created, result);
            }
            catch (InvalidDataException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.UnprocessableEntity, null);
            }
            catch (Exception)
            {
                return ApiResponseHelper.Convert(false, false, ExceptionMessage.SWW,
                    HTTPStatusCode500.InternalServerError, null);
            }
        }

        #endregion

        #region GET BY ID

        [HttpGet("{id}")]
        public async Task<IResult> GetProfileById(string id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _profileService.GetProfileByIdAsync(id, cancellationToken);

                if (result == null)
                    return ApiResponseHelper.Convert(true, false, "Not Found",
                        HTTPStatusCode400.NotFound, null);

                return ApiResponseHelper.Convert(true, true, "Success",
                    HTTPStatusCode200.Ok, result);
            }
            catch (Exception)
            {
                return ApiResponseHelper.Convert(false, false, ExceptionMessage.SWW,
                    HTTPStatusCode500.InternalServerError, null);
            }
        }

        #endregion

        #region GET ALL

        [HttpGet]
        public async Task<IResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _profileService.GetAllProfilesAsync(cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Success",
                    HTTPStatusCode200.Ok, result);
            }
            catch (Exception)
            {
                return ApiResponseHelper.Convert(false, false, ExceptionMessage.SWW,
                    HTTPStatusCode500.InternalServerError, null);
            }
        }

        #endregion

        #region UPDATE

        [HttpPut("{id}")]
        public async Task<IResult> UpdateProfile(string id, RequestUpdateProfile request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                var result = await _profileService.UpdateProfileAsync(request, id, cancellationToken);

                if (!result)
                    return ApiResponseHelper.Convert(true, false, "Not Found",
                        HTTPStatusCode400.NotFound, null);

                return ApiResponseHelper.Convert(true, true, "Updated Successfully",
                    HTTPStatusCode200.Ok, result);
            }
            catch (InvalidDataException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.UnprocessableEntity, null);
            }
            catch (Exception)
            {
                return ApiResponseHelper.Convert(false, false, ExceptionMessage.SWW,
                    HTTPStatusCode500.InternalServerError, null);
            }
        }

        #endregion

        #region DELETE (SOFT)

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteProfile(string id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _profileService.DeleteProfileAsync(id, cancellationToken);

                if (!result)
                    return ApiResponseHelper.Convert(true, false, "Not Found",
                        HTTPStatusCode400.NotFound, null);

                return ApiResponseHelper.Convert(true, true, "Deleted Successfully",
                    HTTPStatusCode200.Ok, null);
            }
            catch (Exception)
            {
                return ApiResponseHelper.Convert(false, false, ExceptionMessage.SWW,
                    HTTPStatusCode500.InternalServerError, null);
            }
        }

        #endregion
    }
}