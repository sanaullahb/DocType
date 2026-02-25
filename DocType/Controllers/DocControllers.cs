using CustomHTTP;
using DocType.Controllers.DocService.DTO.Request;
using DocType.Controllers.TImeManagementService;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Services;
using KininTech.SqlMapping.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DocType.ProfileControllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DocControllers : ControllerBase
    {
        private readonly IDocService _docService;

        public DocControllers(IDocService doc)
        {
            _docService = doc;
        }

        #region CREATE

        [HttpPost]
        public async Task<IResult> CreateDoc(RequestAddDoctorInformation request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                var result = await _docService.CreateDocAsync(request, cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Created Successfully",
                    HTTPStatusCode200.Created, result);
            }
            catch (RecordAlreadyExistException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.Conflict, null);
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
        public async Task<IResult> GetDocById(string id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _docService.GetDocByIdAsync(id, cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Success",
                    HTTPStatusCode200.Ok, result);
            }
            catch (RecordNotFoundException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.NotFound, null);
            }
        }

        #endregion

        #region GET ALL

        [HttpGet]
        public async Task<IResult> GetAllDocs(CancellationToken cancellationToken)
        {
            var result = await _docService.GetAllDocAsync(cancellationToken);
            return ApiResponseHelper.Convert(true, true, "Success",
                HTTPStatusCode200.Ok, result);
        }

        #endregion

        #region UPDATE

        [HttpPut("{id}")]
        public async Task<IResult> UpdateDoc(string id, RequestUpdateDocInformation request, CancellationToken cancellationToken)
        {
            if (request == null)
                return ApiResponseHelper.Convert(false, false, "Request cannot be null",
                    HTTPStatusCode400.BadRequest, null);

            try
            {
                var result = await _docService.UpdateDocInfoAsync(request, id, cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Updated Successfully",
                    HTTPStatusCode200.Ok, result);
            }
            catch (RecordNotFoundException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.NotFound, null);
            }
        }

        #endregion

        #region DELETE (SOFT)

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteDoc(string id, CancellationToken cancellationToken)
        {
            try
            {
                await _docService.DeleteDocAsync(id, cancellationToken);
                return ApiResponseHelper.Convert(true, true, "Deleted Successfully",
                    HTTPStatusCode200.Ok, null);
            }
            catch (RecordNotFoundException e)
            {
                return ApiResponseHelper.Convert(true, false, e.Message,
                    HTTPStatusCode400.NotFound, null);
            }
        }

        #endregion
    }
}