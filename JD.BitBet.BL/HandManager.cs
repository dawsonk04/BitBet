using JD.BitBet.BL.Models;
using JD.BitBet.PL;
using Microsoft.SqlServer.Server;

namespace JD.BitBet.BL
{
    public class HandManager : GenericManager<tblHand>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public HandManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
        public HandManager(DbContextOptions<BitBetEntities> options) : base(options) { }
        public HandManager() { }

        public async Task<Guid> InsertAsync(Hand Hand, bool rollback = false)
        {
            try
            {
                tblHand row = Map<Hand, tblHand>(Hand);
                return await base.InsertAsync(row,
                    e => e.Result == Hand.Result && 
                    e.BetAmount == Hand.BetAmount &&
                    e.GameId == Hand.GameId &&
                    rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> UpdateAsync(Hand Hand, bool rollback = false)
        {
            try
            {
                tblHand row = Map<Hand, tblHand>(Hand);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<Hand>> LoadAsync()
        {
            try
            {
                List<Hand> list = new List<Hand>();
                (await base.LoadAsync())
                    .ForEach(e => list.Add(Map<tblHand, Hand>(e)));
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Hand> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblHand> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblHand, Hand>(row[0]);
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