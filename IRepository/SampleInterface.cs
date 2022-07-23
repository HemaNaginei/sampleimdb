using Sampleimdb.Models;

namespace Sampleimdb.IRepository
{
    public interface SampleInterface
    {
        Task<Sample> InsertSample(Sample lead);
        Task<Sample> UpdateSample(Sample sample);
        Task<Sample> DeleteSample(int id);
        Task<List<Sample>> GetAllSample();
        Task<Sample> GetSampleById (int id);    
    }
}
