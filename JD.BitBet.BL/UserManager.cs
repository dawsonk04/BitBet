using JD.BitBet.BL.Models;
using System.Reflection.Metadata;

namespace JD.BitBet.BL
{
    public class LoginFailureException : Exception
    {
        public LoginFailureException() : base("Cannot log in with these credentials.  Your IP address has been saved.")
        {
        }

        public LoginFailureException(string message) : base(message)
        {
        }
    }

    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<BitBetEntities> options) : base(options) { }

        public UserManager(ILogger logger, DbContextOptions<BitBetEntities> options) : base(options, logger) { }
        public UserManager() { }

        public static string GetHash(string Password)
        {
            using (var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(Password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
        }

        public async Task Seed()
        {
            List<User> users = await LoadAsync();

            foreach (User user in users)
            {
                if (user.Password.Length != 28)
                {
                    await UpdateAsync(user);
                }
            }

            if (users.Count == 0)
            {
                // Hardcode a couple of users with hashed passwords
                await InsertAsync(new User { Email = "jbstrange2@gmail.com", Password = "password", CreateDate = DateTime.Now });
                await InsertAsync(new User { Email = "knudtdaw0000@gmail.com", Password = "password", CreateDate = DateTime.Now });
            }
        }
        public async Task<List<User>> LoadByGameAsync(Guid gameId)
        {
            List<User> users = new List<User>();
            List<tblUser> row = await base.LoadAsync(e => e.gameId == gameId);
            if (row != null && row.Any())
            {
                int counter = 0;
                foreach (var item in row)
                {
                    users.Add(Map<tblUser, User>(row[counter]));
                    counter++;
                }
                return users;
            }
            else
                throw new Exception("No Row");
        }
        public async Task<bool> LoginAsync(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (BitBetEntities dc = new BitBetEntities(options))
                        {
                            tblUser userrow = dc.tblUser.FirstOrDefault(u => u.Email == user.Email);

                            if (userrow != null)
                            {
                                // check the password
                                if (userrow.Password == GetHash(user.Password))
                                {
                                    // Login was successfull
                                    user.Id = userrow.Id;
                                    user.Email = userrow.Email;
                                    user.Password = userrow.Password;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.");
                                }
                            }
                            else
                            {
                                throw new Exception("User could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<User>> LoadAsync()
        {
            try
            {
                List<User> rows = new List<User>();
                (await base.LoadAsync())
                        .ForEach(e => rows.Add(Map<tblUser, User>(e)));

                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> LoadByIdAsync(Guid id)
        {
            try
            {
                List<tblUser> row = await base.LoadAsync(e => e.Id == id);
                if (row[0] != null)
                    return Map<tblUser, User>(row[0]);
                else
                    throw new Exception("Row does not exist.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Guid> InsertAsync(User user, bool rollback = false)
        {
            try
            {
                Guid results = Guid.Empty;
                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    // Check if username already exists - do not allow ....
                    bool inuse = dc.tblUser.Any(u => u.Email.Trim().ToUpper() == user.Email.Trim().ToUpper());

                    if (inuse && rollback == false)
                    {
                        //throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser newUser = new tblUser();

                        newUser.Id = Guid.NewGuid();
                        newUser.Email = user.Email.Trim();
                        newUser.Password = GetHash(user.Password.Trim());
                        newUser.CreateDate = DateTime.Now;
                        Map<User, tblUser>(user);
                        // backlog Id
                        user.Id = newUser.Id;

                        dc.tblUser.Add(newUser);

                        dc.SaveChanges();
                        results = user.Id;
                        if (rollback) transaction.Rollback();
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> UpdateGameId(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    // Check if username already exists - do not allow ....
                    tblUser existingUser = dc.tblUser.Where(u => u.Email.Trim().ToUpper() == user.Email.Trim().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != user.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser upDateRow = dc.tblUser.FirstOrDefault(r => r.Id == user.Id);

                        if (upDateRow != null)
                        {
                            upDateRow.gameId = user.gameId;
                            dc.tblUser.Update(upDateRow);

                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> UpdateAsync(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (BitBetEntities dc = new BitBetEntities(options))
                {
                    // Check if username already exists - do not allow ....
                    tblUser existingUser = dc.tblUser.Where(u => u.Email.Trim().ToUpper() == user.Email.Trim().ToUpper()).FirstOrDefault();

                    if (existingUser != null && existingUser.Id != user.Id && rollback == false)
                    {
                        throw new Exception("This User Name already exists.");
                    }
                    else
                    {
                        IDbContextTransaction transaction = null;
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        tblUser upDateRow = dc.tblUser.FirstOrDefault(r => r.Id == user.Id);

                        if (upDateRow != null)
                        {
                            upDateRow.Email = user.Email;
                            upDateRow.Password = GetHash(user.Password.Trim());
                            upDateRow.gameId = user.gameId;
                            dc.tblUser.Update(upDateRow);

                            results = dc.SaveChanges();

                            if (rollback) transaction.Rollback();
                        }
                        else
                        {
                            throw new Exception("Row was not found.");
                        }
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<int> DeleteAsync(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (BitBetEntities dc = new BitBetEntities())
                {

                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser deleteRow = dc.tblUser.FirstOrDefault(r => r.Id == id);

                    if (deleteRow != null)
                    {
                        dc.tblUser.Remove(deleteRow);
                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
