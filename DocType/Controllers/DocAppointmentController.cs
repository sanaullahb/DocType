using DocType.Services.DocAppointmentService;
using DocType.Services.DocAppointmentService.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace DocType.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestAddAppointment request)
        {
            var userId = User.Identity.Name;

            var result = await _service.CreateAsync(request, userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctor(string doctorId)
        {
            return Ok(await _service.GetByDoctorAsync(doctorId));
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(string patientId)
        {
            return Ok(await _service.GetByPatientAsync(patientId));
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(string id, RequestUpdateAppointmentStatus request)
        {
            var userId = User.Identity.Name;

            return Ok(await _service.UpdateStatusAsync(id, request.Status, userId));
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(string id)
        {
            var userId = User.Identity.Name;

            await _service.CancelAsync(id, userId);
            return Ok("Cancelled successfully");
        }
    }
}
