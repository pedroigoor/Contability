using Gs_Contability.Repositories.Common.Filter;

namespace Gs_Contability.Repositories.Common.Pagination
{
    public class PaginationService<TModel, TFilter> : IPaginationService<TModel, TFilter>
          where TFilter : FilterValueDefault
    {


        public IQueryable<TModel> ApplyPagination(IQueryable<TModel> query, TFilter filter)
        {
            return query
           .Skip((filter.Page - 1) * filter.Size)
           .Take(filter.Size);
        }
    }
}
