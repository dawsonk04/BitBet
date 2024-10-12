using JD.BitBet.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utBase
    {
        protected BitBetEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;
        protected DbContextOptions<BitBetEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<BitBetEntities>()
                .UseSqlServer(_configuration.GetConnectionString("BitBetConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc = new BitBetEntities(options);
        }


        [TestInitialize]
        public void Initialize()
        {
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
            dc = null;
        }

    }
}
