using Sampleimdb.Models;

namespace Sampleimdb.IRepository
{
    public interface ActorInterface
    {
        Task<Actor> InsertActor(Actor lead);
        Task<Actor> UpdateActor(Actor lead);
        Task<Actor> DeleteActor(int ActorId);
        Task<List<Actor>> GetAllActors();
        Task<Actor> GetActorById(int ActorId);
        Task<List<Actor_DD>> GetAllActorDD();
    }
}
