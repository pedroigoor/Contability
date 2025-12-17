namespace Gs_Contability.Repositories.Common.Pagination
{
    public interface IPaginationService<Model, ClassFilter>
    {
        IQueryable<Model> ApplyPagination(IQueryable<Model> query, ClassFilter filter);

    }
}
