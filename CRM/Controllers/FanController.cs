using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;


[Route("api/[controller]")]
[ApiController]
public class FanController : ControllerBase
{
    private readonly IFanInteface _fanRepository;

    public FanController(IFanInteface fanRepository)
    {
        _fanRepository = fanRepository ?? throw new ArgumentNullException(nameof(fanRepository));
    }

    [HttpPost("add-fan")]
    public async Task<IActionResult> AddFanAsync( AddFan fan)
    {
        await _fanRepository.AddFanAsync(fan);
        return Ok();
    }

    [HttpDelete("delete-fan/{id}")]
    public async Task<IActionResult> DeleteFanAsync(string id)
    {
        await _fanRepository.DeleteFanAsync(id);
        return Ok();
    }

    [HttpGet("get-all-fans")]
    public async Task<IActionResult> GetAllFansWithTeacherAsync()
    {
        var fans = await _fanRepository.GetAllFansWithTeachersAsync();
        return Ok(fans);
    }

    [HttpGet("get-by-id-fan/{id}")]
    public async Task<IActionResult> GetByIdFanWithTeachers(string id)
    {
        var fan = await _fanRepository.GetByIdFanWithTeachers(id);
        if (fan == null)
        {
            return NotFound();
        }
        return Ok(fan);
    }

    [HttpPut("update-fan")]
    public async Task<IActionResult> UpdateFanAsync([FromBody] Fan fan)
    {
        await _fanRepository.UpdateFanAsync(fan);
        return Ok();
    }
}