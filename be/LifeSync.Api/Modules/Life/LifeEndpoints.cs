using LifeSync.Application.Life.DTOs;
using LifeSync.Application.Life.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeSync.Api.Modules.Life;

[ApiController]
[Route("api/[controller]")]
public class LifeController : ControllerBase
{
    private readonly ILifeService _lifeService;

    public LifeController(ILifeService lifeService)
    {
        _lifeService = lifeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LifeItemDto>>> GetAll()
    {
        var items = await _lifeService.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LifeItemDto>> GetById(Guid id)
    {
        var item = await _lifeService.GetByIdAsync(id);
        if (item == null)
            return NotFound();
        
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<LifeItemDto>> Create([FromBody] LifeItemDto dto)
    {
        var createdItem = await _lifeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LifeItemDto>> Update(Guid id, [FromBody] LifeItemDto dto)
    {
        dto.Id = id;
        var updatedItem = await _lifeService.UpdateAsync(dto);
        if (updatedItem == null)
            return NotFound();
        
        return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var result = await _lifeService.DeleteAsync(id);
        if (!result)
            return NotFound();
        
        return NoContent();
    }
} 