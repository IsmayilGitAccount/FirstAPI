using FirstAPI.DTOs.Product;

namespace FirstAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDTO>> GetAllAsync(int page, int take);

        Task<GetCategoryDetailDTO> GetByIdAsync(int id);

        Task<bool> CreateAsync(CreateCategoryDTO categoryDTO);

        Task UpdateAsync(int id, UpdateCategoryDTO categoryDTO);

        Task DeleteAsync(int id);
    }
}
