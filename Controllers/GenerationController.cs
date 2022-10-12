using BetaAPIC_.Models;
using BetaAPIC_.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetaAPIC_.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerationController : ControllerBase
{
    public GenerationController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Generation>> GetAll() =>
    GenerationService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Generation> Get(int id)
    {
        var Generation = GenerationService.Get(id);

        if (Generation == null)
            return NotFound();

        return Generation;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Generation Generation)
    {
        GenerationService.Add(Generation);
        return CreatedAtAction(nameof(Create), new { id = Generation.Id }, Generation);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Generation Generation)
    {
        if (id != Generation.Id)
            return BadRequest();

        var existingGeneration = GenerationService.Get(id);
        if (existingGeneration is null)
            return NotFound();

        GenerationService.Update(Generation);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var Generation = GenerationService.Get(id);

        if (Generation is null)
            return NotFound();

        GenerationService.Delete(id);

        return NoContent();
    }
}