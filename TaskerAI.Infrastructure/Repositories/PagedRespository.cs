namespace TaskerAI.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using TaskerAI.Common;
    using TaskerAI.Common.Extensions;

    public abstract class PagedRespository
    {
        protected virtual Paged<TEntity> GetPaged<TEntity>
        (
            IQueryable<TEntity> query,
            IList<Expression<Func<TEntity, bool>>> filter = null,
            int? pageSize = null,
            int? pageIndex = null,
            string sortBy = null,
            string sortAs = null
        ) where TEntity : class
        {
            IQueryable<TEntity> filteredQuery = query.Filter(filter);
            int count = filteredQuery.Count();
            var items = filteredQuery.OrderBy(sortBy, sortAs).Page(pageSize, pageIndex).ToList();

            return Paged<TEntity>.CreatePagedObject(items, pageIndex.GetValueOrDefault(), pageSize.GetValueOrDefault(), count);
        }
    }
}
