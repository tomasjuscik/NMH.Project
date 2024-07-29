namespace NMH.Project.Domain.Entities;

using NMH.Project.Domain.Core.Abstraction;

public class Author : BaseEntity
{
    private Author(string name)
    {
        Name = name;
    }

    public string Name { get; set; } // Unique index

    public virtual Image Image { get; set; } // One-To-One

    public static Author Create(string name)
    {
        return new Author(name);
    }

    public void ChangeName(string name) => Name = name;
}