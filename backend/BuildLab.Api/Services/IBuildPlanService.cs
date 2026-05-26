using BuildLab.Api.Models;

namespace BuildLab.Api.Services;

public interface IBuildPlanService
{
    List<BuildPlan> GetAll();
    BuildPlan? GetById(int id);
    BuildPlan Create(BuildPlan buildPlan);
    bool Update(int id, BuildPlan updatedBuildPlan);
    bool Delete(int id);
}
