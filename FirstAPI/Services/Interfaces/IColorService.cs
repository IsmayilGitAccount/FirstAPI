using FirstAPI.DTOs.Color;

namespace FirstAPI.Services.Interfaces
{
    public interface IColorService
    {
        Task<IEnumerable<GetColorDTO>> GetAll(int page, int take);

        Task<GetColorDetailDTO> GetByIdAsync(int id);

        Task<bool> CreateAsync(CreateColorDTO color);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, UpdateColorDTO color);
    }
}
