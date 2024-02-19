using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController(ITeacherInteface teacherInteface) : ControllerBase
{
    private readonly ITeacherInteface _teacherInteface = teacherInteface;

    [HttpPost("add-teacher")]
    public async Task<IActionResult> Post(AddTeacher teacher)
    {
        try
        {
            await _teacherInteface.AddTeacherAsync(teacher);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("get-all-teachers")]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var teachers =  await _teacherInteface.GetAllTeachersWithFanAsync();
            return Ok(teachers);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("get-by-id-teachers/{id}")]
    public async Task<IActionResult> GetByIdAsyn(string id)
    {
        try
        {
            var teacher = await _teacherInteface.GetByIdTeacherWithFanAsync(id);
            return Ok(teacher);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("update-teacher")]
    public async Task<IActionResult> Update(Teacher teacher)
    {
        try
        {
            await _teacherInteface.UpdateTeacher(teacher);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpDelete("delete-teacher/{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        try
        {
            await _teacherInteface.DeleteTeacherAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

}
