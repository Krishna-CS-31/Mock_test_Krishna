using Microsoft.EntityFrameworkCore;
using PracWebApi.Data;
using PracWebApi.Models;

namespace PracWebApi.Repositories
{
    public class MarvelComicsRepository : IMarvelComicsRepository
    {
        private readonly ApplicationDbContext _context;

        public MarvelComicsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MarvelComics>> GetAllAsync()
        {
            return await _context.Comics.ToListAsync();
        }

        public async Task<MarvelComics?> GetByIdAsync(int id)
        {
            return await _context.Comics.FindAsync(id);
        }

        public async Task<MarvelComics> AddAsync(MarvelComics comic)
        {
            _context.Comics.Add(comic);
            await _context.SaveChangesAsync();
            return comic;
        }

        public async Task<bool> UpdateAsync(MarvelComics comic)
        {
            if (!_context.Comics.Any(c => c.Id == comic.Id)) return false;

            _context.Entry(comic).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comic = await _context.Comics.FindAsync(id);
            if (comic == null) return false;

            _context.Comics.Remove(comic);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
