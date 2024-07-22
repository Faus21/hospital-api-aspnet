using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Lecture8Examples.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Task9.Entities;

namespace Lecture8Examples.Controllers;

[ApiController]
[Route("api/users")]
public class AccountsController : ControllerBase
{
    private readonly HospitalDbContex _contex;

    private readonly WebApplicationBuilder _appBuilder;


    public AccountsController(HospitalDbContex contex)
    {
        _contex = contex;
        _appBuilder = WebApplication.CreateBuilder();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {

        if (!_contex.Users.Where(e => e.Login == request.Login).Any())
        {
            return BadRequest();
        }

        var user = await _contex.Users.Where(e => e.Login == request.Login).FirstOrDefaultAsync();
        string hashedPass = user.Password;

        var hasher = new PasswordHasher<LoginRequest>();
        if (hasher.VerifyHashedPassword(request, hashedPass, request.Password)==PasswordVerificationResult.Failed)
        {
             return Unauthorized();
        }

        var claims = new Claim[]
        {
            new(ClaimTypes.Name, "Mykyta"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appBuilder.Configuration["SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var options = new JwtSecurityToken("https://localhost:5103", "https://localhost:5103",
            claims, expires: DateTime.UtcNow.AddMinutes(5),
            signingCredentials: creds);

        var refreshToken = "";
        using (var genNum = RandomNumberGenerator.Create())
        {
            var r = new byte[1024];
            genNum.GetBytes(r);
            refreshToken = Convert.ToBase64String(r);
        }
        
        user.RefreshToken = refreshToken;
        user.ExpirationDate = DateTime.UtcNow.AddDays(10);

        _contex.Users.Update(user);

        await _contex.SaveChangesAsync();

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(options),
            refreshToken
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(NewUserRequest request)
    {
        if (_contex.Users.Where(e => e.Login ==  request.Login).Any())
        {
            return BadRequest();
        }

        var hasher = new PasswordHasher<NewUserRequest>();
        var hashedPassword=hasher.HashPassword(request, request.Password);


        await _contex.Users.AddAsync(new User { 
            Login = request.Login,
            Password = hashedPassword
        });

        await _contex.SaveChangesAsync();

        return Ok(hashedPassword);
    }

    [HttpPost("api/refresh")]
    public async Task<IActionResult> RefreshToken(string refreshToken)
    {
        var user = await _contex.Users.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken);

        if (user == null)
        {
            return BadRequest();
        }

        var claims = new Claim[]
        {
            new(ClaimTypes.Name, "Mykyta"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appBuilder.Configuration["SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var options = new JwtSecurityToken("https://localhost:5103", "https://localhost:5103",
           claims, expires: DateTime.UtcNow.AddMinutes(5),
           signingCredentials: creds);

        var token = new JwtSecurityTokenHandler().WriteToken(options);


        using (var genNum = RandomNumberGenerator.Create())
        {
            var r = new byte[1024];
            genNum.GetBytes(r);
            user.RefreshToken = Convert.ToBase64String(r);
        };


        user.ExpirationDate = DateTime.UtcNow.AddDays(10);

        _contex.Users.Update(user);

        await _contex.SaveChangesAsync();

        return Ok(new
        {
            token = token,
            refreshToken = user.RefreshToken
        });
    }
    
}