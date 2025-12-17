using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Services
{
    public interface IServiceFilter<Dto, ClassFilter>
    {
        PagedResult<Dto> FindAll(ClassFilter filter);
        Dto FindById(int id);
        Task<Dto> CreateAsync(Dto modelRequest);
        Task<Dto> UpdateById(int id, Dto modelRequest);
        void DeleteById(int id);
    }
}
