using JD.BitBet.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.BL
{
    public class GameStateManager : GenericManager<tblGameState>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public GameStateManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
        public GameStateManager(DbContextOptions<BitBetEntities> options) : base(options) { }
        public GameStateManager() { }

        public async Task<Guid> InsertAsync(GameState game, bool rollback = false)
        {
            try
            {
                tblGameState row = Map<GameState, tblGameState>(game);
                return await base.InsertAsync(row, null ,rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> UpdateAsync(GameState game, bool rollback = false)
        {
            try
            {
                tblGameState row = Map<GameState, tblGameState>(game);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<GameState>> LoadAsync()
        {
            try
            {
                List<GameState> list = new List<GameState>();
                (await base.LoadAsync())
                    .ForEach(e => list.Add(Map<tblGameState, GameState>(e)));
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<GameState> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblGameState> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblGameState, GameState>(row[0]);
                else
                    throw new Exception("No Row");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<GameState> LoadByUserIdAsync(Guid userId)
        {
            try
            {
                List<tblGameState> row = await base.LoadAsync(e => e.UserId == userId);
                if (row[0] != null)
                    return Map<tblGameState, GameState>(row[0]);
                else
                    throw new Exception("No Row");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
