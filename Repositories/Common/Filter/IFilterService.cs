namespace Gs_Contability.Repositories.Common.Filter
{
    public interface IFilterService<Model, ClassFilter>
    {
        IQueryable<Model> ApplyFilters(IQueryable<Model> query, ClassFilter filter);

    }
}
