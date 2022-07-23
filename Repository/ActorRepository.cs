using Microsoft.EntityFrameworkCore;
using Sampleimdb.Context;
using Sampleimdb.Global_Classes;
using Sampleimdb.IRepository;
using Sampleimdb.Models;

namespace Sampleimdb.Repository
{
    public class ActorRepository : ActorInterface
    {
        MovieContext db;
        public primarykeyvalue primarykeyvalue;
        public ActorRepository()
        {
            db=new MovieContext();
            primarykeyvalue = new primarykeyvalue();
        }


        public async Task<Actor> InsertActor(Actor lead)
        {
            try
            {
                int id = await primarykeyvalue.primary_key("Actor");
                Actor obj = new Actor()
                {
                    ActorId = id,
                    ActorName = lead.ActorName,
                    DOB = lead.DOB,
                    //MovieId=lead.MovieId,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    DeleteFlag = false,
                    Status = 1,
                };
                var result = await db.Actor.AddAsync(obj);
                await db.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Actor>UpdateActor(Actor lead)
        {
            try
            {
                var result = await db.Actor.FirstOrDefaultAsync(x=>x.ActorId==lead.ActorId);
                if(result!=null)
                {
                    result.ActorId=lead.ActorId;
                    result.ActorName = lead.ActorName;
                    result.DOB = lead.DOB;
                    //result.MovieId=lead.MovieId;
                    //result.Movies = lead.Movies;
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
        public async Task<Actor>DeleteActor(int ActorId)
        {
            try
            {
                var result=await db.Actor.FirstOrDefaultAsync(x=>x.ActorId== ActorId);
                if (result != null)
                {
                    result.ActorId= ActorId;
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
        public async Task<List<Actor>> GetAllActors()
        {
            try
            {
                if(db!=null)
                {
                    var query = (from a in db.Actor
                                 orderby a.ActorId descending
                                 select new Actor
                                 {
                                     ActorId=a.ActorId,
                                     ActorName=a.ActorName,
                                     DOB=a.DOB,
                                    // MovieId=a.MovieId,
                                    //Movies=a.Movies,

                                 });
                    return await query.ToListAsync();
                }
                return null; 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Actor> GetActorById(int ActorId)
        {
            try
            {
                if(db!=null)
                {
                    var query = (from a in db.Actor
                                 where ActorId == ActorId
                                 select new Actor
                                 {
                                     ActorId = a.ActorId,
                                     ActorName = a.ActorName,
                                     DOB = a.DOB,
                                     //MovieId=a.MovieId,
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
        public async Task<List<Actor_DD>> GetAllActorDD()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Actor
                                 orderby a.ActorId descending
                                 select new Actor_DD
                                 {
                                     ActorId = a.ActorId,
                                     ActorName = a.ActorName
                                 });
                    return await query.ToListAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
