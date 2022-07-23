using Microsoft.EntityFrameworkCore;
using Sampleimdb.Context;
using Sampleimdb.Global_Classes;
using Sampleimdb.IRepository;
using Sampleimdb.Models;

namespace Sampleimdb.Repository
{
    public class MovieRepository : MovieInterface
    {
        private readonly MovieContext db;
        private IPrimarykeyvalue primarykeyvalue;
        public MovieRepository()
        {
            db = new MovieContext();
            primarykeyvalue = new primarykeyvalue();
        }

        public async Task<Movies> InsertMovies(Movies lead)
        {
            try
            {
                int id = await primarykeyvalue.primary_key("Movies");
                Movies obj = new Movies()
                {
                    MovieId = id,
                    DateOfRelease = lead.DateOfRelease,
                    Title = lead.Title,
                    ActorId=lead.ActorId,
                    ProducerId=lead.ProducerId,
                    CreatedBy=1,
                    CreatedDate=DateTime.Now,
                    DeleteFlag = false,
                    Status = 1,
                };
                var result = await db.Movies.AddAsync(obj); 
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;

        }
        public async Task<Movies> UpdateMovies(Movies lead)
        {
            try
            {
                var result = await db.Movies.FirstOrDefaultAsync(x => x.MovieId == lead.MovieId);
                if (result != null)
                {
                    result.MovieId = lead.MovieId;
                    result.Title = lead.Title;
                    result.DateOfRelease = lead.DateOfRelease;
                    result.ActorId = lead.ActorId;
                    result.ProducerId = lead.ProducerId;
                    result.ModifiedBy = 1;
                    result.ModifiedDate = DateTime.Now;
                    result.DeleteFlag = false;
                    result.Status = 1;
                    return result;
                    await db.SaveChangesAsync();
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Movies>DeleteMovies(int MovieId)
        {
            try
            {
                var result=await db.Movies.FirstOrDefaultAsync(x=>x.MovieId==MovieId);
                if (result != null)
                {
                    result.MovieId=MovieId;
                    result.DeletedBy = 1;
                    result.DeletedDate = DateTime.Now;
                    result.DeleteFlag = true;
                    result.Status = 0;
                    return result;
                    await db.SaveChangesAsync();
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Movies>> GetAllMovies()
        {
            try
            {
               if(db!=null)
                {
                    var query = (from a in db.Movies
                                 orderby a.MovieId descending
                                 select new Movies
                                 {
                                     MovieId = a.MovieId,
                                     Title = a.Title,
                                     DateOfRelease = a.DateOfRelease,
                                     ActorId = a.ActorId,
                                     ProducerId=a.ProducerId,
                                 });
                    ;
                    return await query.ToListAsync();
                }
                           
            return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Movies> GetMoviesById(int MovieId)
        {
            try 
            {
                if (db != null)
                {
                    var query = (from a in db.Movies
                                 where a.MovieId == MovieId
                                 select new Movies
                                 {
                                     MovieId=a.MovieId,
                                     Title=a.Title,
                                     DateOfRelease= a.DateOfRelease,
                                     ActorId=a.ActorId,
                                     ProducerId=a.ProducerId,
                                 }).FirstOrDefaultAsync();
                    return await query;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

    }
}
