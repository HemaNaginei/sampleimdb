using Microsoft.EntityFrameworkCore;
using Sampleimdb.Context;
using Sampleimdb.Global_Classes;
using Sampleimdb.IRepository;
using Sampleimdb.Models;

namespace Sampleimdb.Repository
{
    public class ProducerRepository : ProducerInterface
    {
        MovieContext db;
        private IPrimarykeyvalue primarykeyvalue;
        public ProducerRepository(MovieContext _db)
        {
            db = _db;
            primarykeyvalue = new primarykeyvalue();
            
        }
        public async Task<Producer> InsertProducer(Producer lead)
        {
            try
            {
                int id = await primarykeyvalue.primary_key("Producer");
                Producer obj = new Producer()
                {
                    ProducerId = lead.ProducerId,
                    ProducerName = lead.ProducerName,
                    //MovieId=lead.MovieId,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    DeleteFlag = false,
                    Status = 1,
                };
                var result = await db.Producer.AddAsync(obj);
                await db.SaveChangesAsync();
                return null;
            }
                catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Producer> UpdateProducer(Producer lead)
        {
            try
            {
                var result = await db.Producer.FirstOrDefaultAsync(x => x.ProducerId == lead.ProducerId);
                if(result!=null)
                {
                    result.ProducerId = lead.ProducerId;
                    result.ProducerName = lead.ProducerName;
                   // result.MovieId = lead.MovieId;
                    result.ModifiedBy = 1;
                    result.ModifiedDate = DateTime.Now;
                    result.DeleteFlag = false;
                    result.Status=1;
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
        public async Task<Producer> DeleteProducer(int ProducerId)
        {
            try
            {
                var result = await db.Producer.FirstOrDefaultAsync(x => x.ProducerId == ProducerId);
                if (result != null)
                {
                   result.ProducerId=ProducerId;
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
        public async Task<List<Producer>> GetAllProducer()
        {
            try
            {
                if(db!=null)
                {
                    var query=(from a in db.Producer orderby a.ProducerId descending 
                               select new Producer
                               {
                                   ProducerId=a.ProducerId,
                                   ProducerName=a.ProducerName,
                                   //MovieId=a.MovieId,
                               } );
                    return query.ToList();
                }
                return null;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Producer> GetProducerById(int ProducerId)
        {
            try
            {
                var query = (from a in db.Producer where a.ProducerId == ProducerId
                             select new Producer
                             {
                                 ProducerId = a.ProducerId,
                                 ProducerName = a.ProducerName,
                                 //MovieId = a.MovieId,
                             }).FirstOrDefaultAsync();
                return await query;
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Producer_DD>> GetAllProducerDD()
        {
            try
            {
                if(db!=null)
                {
                    var query = (from a in db.Producer
                                 select new Producer_DD
                                 {
                                     ProducerId=a.ProducerId,
                                     ProducerName=a.ProducerName

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
    }
}
