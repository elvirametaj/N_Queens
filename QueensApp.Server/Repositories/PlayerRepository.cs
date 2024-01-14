using QueensApp.Server.Models;
using QueensApp.Server.Properties.Data;

namespace QueensApp.Server.Repositories
{
    public interface IPlayerRepository
    {
        Task Create(Player player);
    }

    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext _db;

        public PlayerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Player player)
        {
            await _db.Players.AddAsync(player);
        }
    }
}
