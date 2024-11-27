namespace WebApi.Services;
using JD.BitBet.BL;
using JD.BitBet.BL.Models;
using JD.BitBet.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;
using WebApi.Models;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> GetAll();
    Task<User> GetById(Guid id);
}

public class UserService : IUserService
{
    List<User> _users;

    private readonly AppSettings _appSettings;
    private readonly DbContextOptions<BitBetEntities> dbOptions;

    public UserService(IOptions<AppSettings> appSettings,
                       DbContextOptions<BitBetEntities> options)
    {
        _appSettings = appSettings.Value;
        dbOptions = options;

    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = new UserManager(dbOptions)
                        .LoadAsync()
                        .Result
                        .SingleOrDefault(x => x.Email == model.Email
                                        && x.Password == UserManager.GetHash(model.Password));

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        _users = new UserManager(dbOptions).LoadAsync().Result;
        return _users;
    }

    public async Task<User> GetById(Guid id)
    {
        return new UserManager(dbOptions).LoadAsync().Result.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}