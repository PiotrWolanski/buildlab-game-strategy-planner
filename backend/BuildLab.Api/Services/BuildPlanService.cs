using BuildLab.Api.Models;

namespace BuildLab.Api.Services;

public class BuildPlanService : IBuildPlanService
{
    private readonly List<BuildPlan> _buildPlans = new()
    {
        new BuildPlan
        {
            Id = 1,
            Name = "Jinx ADC Crit Build",
            Game = "League of Legends",
            ContentType = "Ranked",
            Role = "ADC",
            Scale = "5v5",
            Status = "Testing",
            CoreElements = "Kraken Slayer, Infinity Edge, Runaan's Hurricane, Bloodthirster",
            Notes = "Focus on safe laning, scaling and front-to-back teamfights. Consider blue trinket after level 9."
        },
        new BuildPlan
        {
            Id = 2,
            Name = "Albion Small Scale Healer Setup",
            Game = "Albion Online",
            ContentType = "Small Scale",
            Role = "Healer",
            Scale = "7 players",
            Status = "Draft",
            CoreElements = "Hallowfall, Cleric Robe, Mercenary Shoes, Lymhurst Cape",
            Notes = "Designed for Avalonian Roads. Focus on positioning, defensive cooldowns and saving key healing spells for enemy engage."
        },
        new BuildPlan
        {
            Id = 3,
            Name = "Aquatic Psionic Tech Rush",
            Game = "Stellaris",
            ContentType = "Empire Strategy",
            Role = "Research / Economy",
            Scale = "Single Player",
            Status = "Testing",
            CoreElements = "Aquatic trait, Ocean world start, Psionic ascension, research focus",
            Notes = "Prioritize early unity and research economy. Delay major wars until the economy and ascension path are stable."
        }
    };

    private int _nextId = 4;

    public List<BuildPlan> GetAll()
    {
        return _buildPlans;
    }

    public BuildPlan? GetById(int id)
    {
        return _buildPlans.FirstOrDefault(buildPlan => buildPlan.Id == id);
    }

    public BuildPlan Create(BuildPlan buildPlan)
    {
        buildPlan.Id = _nextId++;
        buildPlan.CreatedAt = DateTime.UtcNow;
        _buildPlans.Add(buildPlan);

        return buildPlan;
    }

    public bool Update(int id, BuildPlan updatedBuildPlan)
    {
        var existingBuildPlan = GetById(id);

        if (existingBuildPlan is null)
        {
            return false;
        }

        existingBuildPlan.Name = updatedBuildPlan.Name;
        existingBuildPlan.Game = updatedBuildPlan.Game;
        existingBuildPlan.ContentType = updatedBuildPlan.ContentType;
        existingBuildPlan.Role = updatedBuildPlan.Role;
        existingBuildPlan.Scale = updatedBuildPlan.Scale;
        existingBuildPlan.Status = updatedBuildPlan.Status;
        existingBuildPlan.CoreElements = updatedBuildPlan.CoreElements;
        existingBuildPlan.Notes = updatedBuildPlan.Notes;

        return true;
    }

    public bool Delete(int id)
    {
        var buildPlan = GetById(id);

        if (buildPlan is null)
        {
            return false;
        }

        _buildPlans.Remove(buildPlan);

        return true;
    }
}
