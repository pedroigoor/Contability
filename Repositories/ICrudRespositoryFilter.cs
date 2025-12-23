using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Repositories
{
    public interface ICrudRespositoryFilter<Model, Key, ClassFilter>
    {
        bool ExistsById(Key key);
        PagedResult<Model> FindAllPaged(ClassFilter filter);
        Model CreateAsync(Model model);
        Model? FindById(Key key);
        Model Update(Model model);
        void DeleteById(Key key);
    }
}
