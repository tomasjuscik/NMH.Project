using NMH.Project.Domain.Core.Abstraction;

namespace NMH.Project.Domain.Entities;

public sealed class Site : BaseEntity
{
    private Site()
    {
        CreatedAt = DateTimeOffset.UtcNow;
    }

    public static Site Create()
    {
        return new Site();
    }

    public DateTimeOffset CreatedAt { get; private set; }

    public void ChangeCreatedAt(DateTimeOffset createdAt) => CreatedAt = createdAt;
}