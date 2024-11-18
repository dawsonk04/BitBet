using Castle.Core.Resource;
using Humanizer.Localisation;
using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Server;
using System.IO;

namespace JD.BitBet.Api.Test
{

    [TestClass]
    public class utTransaction : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Transaction>(6);
        }
        public async Task InsertTestAsync()
        {
            Transaction transaction = new Transaction
            {
                WalletId = Guid.Parse("38635c5b-d8e7-4e72-8294-525afc799689"),
                TransactionType = "Deposit",
                Amount = 10.00,
                TransactionDate = DateTime.Now,
            };
            await base.InsertTestAsync<Transaction>(transaction);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync<Transaction>(new KeyValuePair<string, string>("TransactionDate", "12/4/1990 12:00:00 AM"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Transaction>(new KeyValuePair<string, string>("TransactionDate", "12/4/1990 12:00:00 AM"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Transaction transaction = new Transaction { TransactionType = "Deposit" };
            await base.UpdateTestAsync<Transaction>(Guid.Parse("44094019-46ec-42f8-9398-0890d5f75efa"), transaction);

        }
    }
}
