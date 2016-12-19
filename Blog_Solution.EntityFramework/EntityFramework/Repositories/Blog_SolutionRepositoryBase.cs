using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Blog_Solution.EntityFramework.Repositories
{
    public abstract class Blog_SolutionRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<Blog_SolutionDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected Blog_SolutionRepositoryBase(IDbContextProvider<Blog_SolutionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class Blog_SolutionRepositoryBase<TEntity> : Blog_SolutionRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected Blog_SolutionRepositoryBase(IDbContextProvider<Blog_SolutionDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
