using DocType.Services.PatientService.DTO.Request;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _service;

    public PatientController(IPatientService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(RequestAddPatient request, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(request, "system", cancellationToken);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var result = await _service.GetByIdAsync(id, cancellationToken);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllPatientAsync(cancellationToken);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(RequestUpdatePatient request, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(request, "system", cancellationToken);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(id, "system", cancellationToken);
        return result ? Ok() : NotFound();
    }
}