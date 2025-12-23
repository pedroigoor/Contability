using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Repositories
{
    public interface ICrudRespositoryNoFilter<Model, Key>
    {
        Task<bool> ExistsByIdAsync(Key key);
        Task<PagedResult<Model>> FindAllPagedAsync(int page, int size);
        Task<Model> CreateAsync(Model model);
        Task<Model?> FindByIdAsync(Key key);
        Task<Model> UpdateAsync(Model model);
        Task DeleteByIdAsync(Key key);
    }
}
