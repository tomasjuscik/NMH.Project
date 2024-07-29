namespace NMH.Project.Domain.Entities;

using NMH.Project.Domain.Core.Abstraction;

public sealed class Image : BaseEntity
{
    private Image(string description)
    {
        Description = description;
    }

    public string Description { get; private set; }

    public static Image Create(string description)
    {
        return new Image(description);
    }
}