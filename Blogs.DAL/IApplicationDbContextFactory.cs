namespace Blogs.DAL
{
    public interface IApplicationDbContextFactory
    {
        ApplicationDbContext Create();
    }
}
