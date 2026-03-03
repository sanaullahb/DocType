using DocType.Services.DocScheduleService.DTO.Request;
using Microsoft.AspNetCore.Mvc;

namespace DocType.Controllers
{
    [Route("api/doctor-schedules")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IDoctorScheduleService _service;

        public DoctorScheduleController(IDoctorScheduleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestAddDoctorSchedule request)
        {
            var userId = User.Identity.Name;
            var userName = User.Identity.Name;

            var result = await _service.AddAsync(request, userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, RequestUpdateDoctorSchedule request)
        {
            var userId = User.Identity.Name;

            var result = await _service.UpdateAsync(id, request, userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userId = User.Identity.Name;

            await _service.DeleteAsync(id, userId);
            return Ok("Deleted successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("doctor/{userId}")]
        public async Task<IActionResult> GetByDoctor(string userId)
        {
            var result = await _service.GetByDoctorAsync(userId);
            return Ok(result);
        }
    }
}
