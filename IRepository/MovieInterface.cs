using Sampleimdb.Models;

namespace Sampleimdb.IRepository
{
    public interface MovieInterface
    {
        Task<Movies> InsertMovies(Movies lead);
        Task<Movies> UpdateMovies(Movies lead);
        Task<Movies> DeleteMovies(int MovieId);
        Task<List<Movies>> GetAllMovies();
    }
}
