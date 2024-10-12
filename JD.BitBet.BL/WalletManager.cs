using JD.BitBet.BL.Models;

namespace JD.BitBet.BL
{
    public class WalletManager : GenericManager<tblWallet>
    {
        private const string NOTFOUND_MESSAGE = "Row does not exist";
        public WalletManager(DbContextOptions<BitBetEntities> options, ILogger logger) : base(options, logger) { }
        public WalletManager(DbContextOptions<BitBetEntities> options) : base(options) { }
        public WalletManager() { }

        public async Task<Guid> InsertAsync(Wallet wallet, bool rollback = false)
        {
            try
            {
                tblWallet row = Map<Wallet, tblWallet>(wallet);
                return await base.InsertAsync(row,
                    e => e.WalletAddress == e.WalletAddress &&
                    e.Balance  == e.Balance &&
                    e.UserId == e.UserId &&
                    rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<int> UpdateAsync(Wallet Wallet, bool rollback = false)
        {
            try
            {
                tblWallet row = Map<Wallet, tblWallet>(Wallet);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<List<Wallet>> LoadAsync()
        {
            try
            {
                List<Wallet> list = new List<Wallet>();
                (await base.LoadAsync())
                    .ForEach(e => list.Add(Map<tblWallet, Wallet>(e)));
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Wallet> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblWallet> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblWallet, Wallet>(row[0]);
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
