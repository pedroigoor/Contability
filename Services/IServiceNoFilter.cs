

using Gs_Contability.Repositories.Common.Pagination;

namespace Gs_Contability.Services
{
    public interface IServiceNoFilter<DtoResponse,DtoRequest>
    {
        PagedResult<DtoResponse> FindAll(int page, int size);
        DtoResponse FindById(int id);
        Task<DtoResponse> CreateAsync(DtoRequest modelRequest);
        Task<DtoResponse> UpdateById(int id, DtoRequest modelRequest);
        void DeleteById(int id);
    }
}
