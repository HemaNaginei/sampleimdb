using Sampleimdb.Models;

namespace Sampleimdb.IRepository
{
    public interface ProducerInterface
    {
        Task<Producer> InsertProducer(Producer lead);
        Task<Producer> UpdateProducer(Producer lead);
        Task<Producer> DeleteProducer(int ProducerId);
        Task<Producer> GetProducerById(int ProducerId);
        Task<List<Producer>> GetAllProducer();

        Task<List<Producer_DD>> GetAllProducerDD();
    }
}
