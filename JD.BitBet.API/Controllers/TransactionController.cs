using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace JD.BitBet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : GenericController<JD.BitBet.BL.Models.Transaction, TransactionManager, BitBetEntities>
    {
        public TransactionController(ILogger<TransactionController> logger, DbContextOptions<BitBetEntities> options) : base(logger, options) { }

    }
}
