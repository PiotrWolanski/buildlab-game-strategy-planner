using BuildLab.Api.Models;
using BuildLab.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildLab.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BuildPlansController : ControllerBase
{
    private readonly IBuildPlanService _buildPlanService;

    public BuildPlansController(IBuildPlanService buildPlanService)
    {
        _buildPlanService = buildPlanService;
    }

    [HttpGet]
    public ActionResult<List<BuildPlan>> GetAll()
    {
        return Ok(_buildPlanService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<BuildPlan> GetById(int id)
    {
        var buildPlan = _buildPlanService.GetById(id);

        if (buildPlan is null)
        {
            return NotFound();
        }

        return Ok(buildPlan);
    }

    [HttpPost]
    public ActionResult<BuildPlan> Create(BuildPlan buildPlan)
    {
        var createdBuildPlan = _buildPlanService.Create(buildPlan);

        return CreatedAtAction(nameof(GetById), new { id = createdBuildPlan.Id }, createdBuildPlan);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, BuildPlan buildPlan)
    {
        var wasUpdated = _buildPlanService.Update(id, buildPlan);

        if (!wasUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var wasDeleted = _buildPlanService.Delete(id);

        if (!wasDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
