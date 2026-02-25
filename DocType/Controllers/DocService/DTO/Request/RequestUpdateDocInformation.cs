using DocType.Controllers.TImeManagementService.DTO.Request;

namespace DocType.Controllers.DocService.DTO.Request
{
    public class RequestUpdateDocInformation : RequestAddDoctorInformation
    {
        public string? DocID { get; set; }  

    }
}
