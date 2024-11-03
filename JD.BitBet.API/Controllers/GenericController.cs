using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JD.BitBet.API.Controllers
{
    public class GenericController<T, U, V> : ControllerBase where V : DbContext
    {
        protected DbContextOptions<V> options;
        protected readonly ILogger logger;
        dynamic manager;

        public GenericController(ILogger logger, DbContextOptions<V> options)
        {
            this.options = options;
            this.logger = logger;
            this.manager = (U)Activator.CreateInstance(typeof(U), logger, options);
        }
        /// <summary>
        /// get entities of particular type
        /// </summary>
        /// <returns>List of T</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            try
            {
                return Ok(await manager.LoadAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// get entity for a particular type
        /// </summary>
        /// <param name="id">id for entity</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(Guid id)
        {
            try
            {
                return Ok(await manager.LoadbyIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// insert a new entity
        /// </summary>
        /// <param name="entity">new entity</param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPost("{rollback?}")]
        public async Task<ActionResult> Post([FromBody] T entity, bool rollback = false)
        {
            try
            {
                Guid id = await manager.InsertAsync(entity, rollback);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// update a particular entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] T entity, bool rollback = false)
        {
            try
            {
                int rowsAffected = await manager.UpdateAsync(entity, rollback);
                // Create a small json bit 
                var result = new Dictionary<string, string>();
                result.Add("rowsAffected", rowsAffected.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        /// <summary>
        /// delete a particular entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public async Task<ActionResult> Delete(Guid id, bool rollback = false)
        {
            try
            {
                int rowsAffected = await manager.DeleteAsync(id, rollback);
                // Create a small json bit 
                var result = new Dictionary<string, string>();
                result.Add("rowsAffected", rowsAffected.ToString());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
