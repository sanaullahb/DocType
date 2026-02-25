using CustomHTTP;
using DocType.Controllers.TImeManagementService;
using DocType.Controllers.TImeManagementService.DTO.Request;
using DocType.Data;
using DocType.DTO;
using DocType.DTO.Requests;
using DocType.Generic;
using DocType.Models;
using DocType.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DocType.ProfileControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDocController : ControllerBase
    {

        private readonly IDocService _docService;
        public AddDocController(IDocService doc)
        {
            _docService = doc;
        }
        [HttpPost]
        public async Task<IResult> CreateDoc(RequestAddDoctorInformation request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new InvalidDataException("Request cannot be  null");
            }
            string message = "Success";
            int statusCode = HTTPStatusCode200.Created;
            try
            {

                var result = await _docService.CreateDocAsync(request, cancellationToken);
                return ApiResponseHelper.Convert(true, true, message, statusCode, result);

            }

            catch (InvalidOperationException e)
            {
                statusCode = HTTPStatusCode400.UnprocessableEntity;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }


            catch (RecordAlreadyExistException e)
            {
                statusCode = HTTPStatusCode400.Conflict;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (InvalidDataException e)
            {
                statusCode = HTTPStatusCode400.UnprocessableEntity;
                message = e.Message;

                return ApiResponseHelper.Convert(true, false, message, statusCode, null);
            }
            catch (Exception e)
            {
                statusCode = HTTPStatusCode500.InternalServerError;


                message = ExceptionMessage.SWW;
                return ApiResponseHelper.Convert(false, false, message, statusCode, null);
            }

        }
    }

}
