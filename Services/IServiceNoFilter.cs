using Gs_Contability.Dto.Users;
using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Services
{
    public interface IServiceNoFilter<DtoResponse,DtoRequest>
    {
        Task<PagedResult<DtoResponse>> FindAll(int page, int size);
        Task<DtoResponse> FindById(int id);
        Task<DtoResponse> CreateAsync(DtoRequest modelRequest);
        Task<DtoResponse> UpdateById(int id, DtoRequest modelRequest);
        Task DeleteById(int id);
    }
}
