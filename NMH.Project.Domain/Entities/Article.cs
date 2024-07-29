namespace NMH.Project.Domain.Entities;

using NMH.Project.Domain.Core.Abstraction;

public class Article : BaseEntity
{
    private Article(string title)
    {
        Title = title;
    }

    
    public string Title { get; private set; } // Index
    public virtual ICollection<Author> Authors { get; set; } // Many-To-Many
    public virtual Site Site { get; set; } // One-To-Many

    public static Article Create(string title)
    {
        return new Article(title);
    }

    public void ChangeTitle(string title) => Title = title;
}