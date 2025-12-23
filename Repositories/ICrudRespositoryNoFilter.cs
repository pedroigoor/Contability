using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Repositories
{
    public interface ICrudRespositoryNoFilter<Model, Key>
    {
        bool ExistsById(Key key);
        PagedResult<Model> FindAllPaged(int page, int size);
        Task<Model> CreateAsync(Model model);
        Model? FindById(Key key);
        Task<Model> Update(Model model);
        void DeleteById(Key key);
    }
}
