using cp5.DTO.CulturalEvent;
using cp5.Models;
using cp5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cp5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CulturalEventController : ControllerBase
{
    private readonly CulturalEventService _service;

    public CulturalEventController(CulturalEventService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CulturalEvent>> Create(CulturalEventDTO request)
    {
        var response = await _service.Save(request);
        return  CreatedAtAction(nameof(ReadById), new { id = response.Id }, response);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<CulturalEventResponse>>> ReadAll()
    {
        var response = await _service.FindAll();
        return Ok(response);
    }

    [HttpGet("{id:length(24)}")]
    [Authorize]
    public async Task<ActionResult<CulturalEventResponse>> ReadById(string id)
    {
        var response = await  _service.FindById(id);
        return Ok(response);
    }

    [HttpPut("{id:length(24)}")]
    [Authorize]
    public async Task<ActionResult<CulturalEventResponse>> Update(string id, CulturalEventDTO request)
    {
        var response = await _service.Update(id, request);
        return Ok(response);
    }

    [HttpDelete("{id:length(24)}")]
    [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}