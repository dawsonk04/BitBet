namespace JD.BitBet.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<BitBetEntities> options;
        protected readonly ILogger logger;
        public GenericManager() { }
        public GenericManager(DbContextOptions<BitBetEntities> options, ILogger logger)
        {
            this.options = options;
            this.logger = logger;
        }
        public GenericManager(DbContextOptions<BitBetEntities> options) { this.options = options; }

        public async Task<Guid> InsertAsync(T entity, Expression<Func<T, bool>> expression = null, bool rollback = false)
        {
            try
            {
                Guid results = Guid.Empty;
                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    if ((expression == null) || (expression != null) && (!dc.Set<T>().Any()))
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        entity.Id = Guid.NewGuid();
                        dc.Set<T>().Add(entity);

                        dc.SaveChanges();
                        if (rollback) transaction?.Rollback();
                    }
                    else
                    {
                        if (logger != null) logger.LogWarning("Row already exists. {UserId}", "dawson or john");
                    }
                }
                return entity.Id;
            }
            catch (Exception)
            {
                if (logger != null)
                    logger.LogWarning($"Insert {typeof(T).Name}s - GenericManager");
                throw new Exception("Row already exists.");
            }
        }

        public async Task<int> UpdateAsync(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    dc.Entry(entity).State = EntityState.Modified;

                    results = dc.SaveChanges();
                    if (rollback) transaction?.Rollback();
                }
                return results;
            }
            catch (Exception)
            {
                if (logger != null)
                    logger.LogWarning($"Update {typeof(T).Name}s - GenericManager");
                throw;
            }
        }

        public async Task<int> DeleteAsync(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    T row = dc.Set<T>().FirstOrDefault(t => t.Id == id);

                    if (row != null)
                    {
                        dc.Set<T>().Remove(row);

                        results = dc.SaveChanges();
                        if (rollback) transaction?.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row does not exist");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                if (logger != null)
                    logger.LogWarning($"Delete {typeof(T).Name}s - GenericManager");
                throw;
            }
        }

        public async Task<List<T>> LoadAsync(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                if (filter == null) filter = e => true;

                if (logger != null)
                    logger.LogWarning($"Get {typeof(T).Name}s - GenericManager");

                IQueryable<T> rows = new BitBetEntities(options).Set<T>().Where(filter);
                return await rows.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public V Map<U, V>(U objfrom)
        {
            V objTo = (V)Activator.CreateInstance(typeof(V));

            var ToProperties = objTo.GetType().GetProperties();
            var FromProperties = objfrom.GetType().GetProperties();

            ToProperties.ToList().ForEach(o =>
            {
                var fromp = FromProperties.FirstOrDefault(x => x.Name == o.Name
                                                          && x.PropertyType == o.PropertyType);

                if (fromp != null)
                    o.SetValue(objTo, fromp.GetValue(objfrom));
            });

            return objTo;
        }

        internal Task<T> LoadByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }



    }
}
