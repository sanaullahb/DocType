using CustomHTTP;
using DocType.Generic;
using DocType.Services.DocAvailaibilityService;
using DocType.Services.DocAvailaibilityService.DTO.Request;
using KininTech.SqlMapping.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DocType.Controllers.DocAvailabilityController
{
    [Route("api/doc-availability")]
    [ApiController]
    public class DocAvailabilityController : ControllerBase
    {
        private readonly IDocAvailabilityService _docAvailabilityService;

        public DocAvailabilityController(IDocAvailabilityService docAvailabilityService)
        {
            _docAvailabilityService = docAvailabilityService;
        }

        #region CREATE

        [HttpPost]
        public async Task<IResult> CreateDocAvailability(
            RequestAddDocAvailability request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                var result = await _docAvailabilityService
                    .CreateDocAvailabilityAsync(request, cancellationToken);

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
        public async Task<IResult> GetDocAvailabilityById(
            string id,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _docAvailabilityService
                    .GetDocAvailabilityByIdAsync(id, cancellationToken);

                if (result == null)
                    return ApiResponseHelper.Convert(true, false, "Record Not Found",
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
        public async Task<IResult> GetAllDocAvailability(
            CancellationToken cancellationToken)
        {
            var result = await _docAvailabilityService
                .GetAllDocAvailabilityAsync(cancellationToken);

            return ApiResponseHelper.Convert(true, true, "Success",
                HTTPStatusCode200.Ok, result);
        }

        #endregion

        #region UPDATE

        [HttpPut("{id}")]
        public async Task<IResult> UpdateDocAvailability(
            string id,
            RequestUpdateDocAvailability request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                request.Id = id; // ensure route id is used

                var result = await _docAvailabilityService
                    .UpdateDocAvailabilityAsync(request, "System", cancellationToken);

                if (!result)
                    return ApiResponseHelper.Convert(true, false, "Record Not Found",
                        HTTPStatusCode400.NotFound, null);

                return ApiResponseHelper.Convert(true, true, "Updated Successfully",
                    HTTPStatusCode200.Ok, result);
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
        public async Task<IResult> DeleteDocAvailability(
            string id,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await _docAvailabilityService
                    .DeleteDocAvailabilityAsync(id, cancellationToken);

                if (!result)
                    return ApiResponseHelper.Convert(true, false, "Record Not Found",
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