using JD.BitBet.BL.Models;
using JD.BitBet.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.BitBet.BL
{
    public class CardManager : GenericManager<tblCard>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public CardManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
        public CardManager(DbContextOptions<BitBetEntities> options) : base(options) { }
        public CardManager() { }

        public async Task<Guid> InsertAsync(Card Card, bool rollback = false)
        {
            try
            {
                                
                tblCard row = Map<Card, tblCard>(Card);
                row.suit = Card.suit;  
                row.rank = Card.rank;

                return await base.InsertAsync(row,
                    e => e.suit == Card.suit &&
                    e.rank == Card.rank);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> UpdateAsync(Card Card, bool rollback = false)
        {
            try
            {
                tblCard row = Map<Card, tblCard>(Card);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<Card>> LoadAsync()
        {
            try
            {
                List<Card> list = new List<Card>();
                (await base.LoadAsync())
                    .ForEach(e => list.Add(Map<tblCard, Card>(e)));
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Card> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblCard> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblCard, Card>(row[0]);
                else
                    throw new Exception("No Row");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<Card>> LoadByHandId(Guid handId)
        {
            try
            {
                List<tblCard> row = await base.LoadAsync(e => e.HandId == handId);
                if (row[0] != null)
                    return Map<tblCard, List<Card>>(row[0]);
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
