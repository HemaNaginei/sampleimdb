using Microsoft.EntityFrameworkCore;
using Sampleimdb.Context;
using Sampleimdb.Global_Classes;
using Sampleimdb.IRepository;
using Sampleimdb.Models;

namespace Sampleimdb.Repository
{
    public class SampleRepository : SampleInterface
    {
        MovieContext db;
        public IPrimarykeyvalue primarykeyvalue;
        public SampleRepository()
        {
            db = new MovieContext();
            primarykeyvalue=new primarykeyvalue();
        }
        public async Task<Sample>InsertSample(Sample lead)
        {
            try
            {
                int id = await primarykeyvalue.primary_key("sample");
                Sample obj = new Sample()
                {
                    Id = id,
                    MovieId=lead.MovieId,
                    ActorId=lead.ActorId,
                    ProducerId=lead.ProducerId,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    DeleteFlag = false,
                    Status = 1,
                };
                var result = await db.Sample.AddAsync(obj);
                await db.SaveChangesAsync();
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Sample>UpdateSample(Sample lead)
        {
            try
            {
                var result = await db.Sample.FirstOrDefaultAsync(x => x.Id == lead.Id);
                if(result!=null)
                {
                    result.Id = lead.Id;
                    result.ActorId = lead.ActorId;
                    result.MovieId= lead.MovieId;
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
        public async Task<Sample> DeleteSample(int Id)
        {
            try
            {
                var result = await db.Sample.FirstOrDefaultAsync(x => x.Id == Id);
                if(result!=null)
                {
                    result.Id=Id;
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
        public async Task<List<Sample>> GetAllSample()
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Sample
                                 orderby a.Id descending
                                 select new
                                 {
                                     Id = a.Id,
                                     ActorId = a.ActorId,
                                     MovieId=a.MovieId,
                                     ProducerId=a.ProducerId,
                                 });
                    await query.ToListAsync();
                    
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Sample> GetSampleById(int Id)
        {
            try
            {
                if (db != null)
                {
                    var query = (from a in db.Sample
                                 where a.Id == Id
                                 select new Sample
                                 {
                                     Id=a.Id,
                                     ActorId =a.ActorId,
                                     MovieId=a.MovieId,
                                     ProducerId=a.ProducerId,
                                 }).FirstOrDefaultAsync();
                    await query;
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
