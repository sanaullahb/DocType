using DocType.Services.DocTimeSlotService;
using DocType.Services.DocTimeSlotService.DTO.Request;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/doc-timeslots")]
public class DocTimeSlotController : ControllerBase
{
    private readonly IDocTimeSlotService _service;

    public DocTimeSlotController(IDocTimeSlotService service)
    {
        _service = service;
    }

    [HttpPost("generate/{availabilityId}")]
    public async Task<IActionResult> Generate(string availabilityId, CancellationToken cancellationToken)
    {
        var result = await _service.GenerateSlotsAsync(availabilityId, cancellationToken);
        return result ? Ok() : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Get(string doctorId, DateOnly date, CancellationToken cancellationToken)
    {
        var result = await _service.GetSlotsByDoctorAndDateAsync(doctorId, date, cancellationToken);
        return Ok(result);
    }

    [HttpPost("book")]
    public async Task<IActionResult> Book(RequestBookDocTimeSlot request, CancellationToken cancellationToken)
    {
        var result = await _service.BookSlotAsync(request, "system", cancellationToken);
        return result ? Ok() : BadRequest("Slot unavailable");
    }

    [HttpPost("cancel/{slotId}")]
    public async Task<IActionResult> Cancel(string slotId, CancellationToken cancellationToken)
    {
        var result = await _service.CancelSlotAsync(slotId, cancellationToken);
        return result ? Ok() : BadRequest();
    }
}