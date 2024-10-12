﻿using JD.BitBet.PL;

namespace JD.BitBet.BL
{
    public class TransactionManager : GenericManager<tblTransaction>
    {
        public TransactionManager() { }
        public TransactionManager(DbContextOptions<BitBetEntities> options, ILogger logger) : base(options, logger) { }
        public TransactionManager(DbContextOptions<BitBetEntities> options) : base(options) { }

        public async Task<Guid> InsertAsync(Models.Transaction transaction, bool rollback = false)
        {
            try
            {
                tblTransaction row = Map<Models.Transaction, tblTransaction>(transaction);
                return await base.InsertAsync(row, null, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(Models.Transaction transaction, bool rollback = false)
        {
            try
            {
                tblTransaction row = Map<Models.Transaction, tblTransaction>(transaction);
                return await base.UpdateAsync(row, rollback);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Models.Transaction> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblTransaction> rows = await base.LoadAsync(e => e.Id == id);
                if (rows[0] != null) return Map<tblTransaction, Models.Transaction>(rows[0]);
                else
                    throw new Exception("no row");
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Will have to include another method in here for LoadingTransactions? 

    }
}
