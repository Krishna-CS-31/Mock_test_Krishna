using PracWebApi.Models;

namespace PracWebApi.Repositories
{
    public interface IMarvelComicsRepository
    {
        Task<IEnumerable<MarvelComics>> GetAllAsync();
        Task<MarvelComics?> GetByIdAsync(int id);
        Task<MarvelComics> AddAsync(MarvelComics comic);
        Task<bool> UpdateAsync(MarvelComics comic);
        Task<bool> DeleteAsync(int id);
    }
}
