using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;
public class AuthDBContext(DbContextOptions<AuthDBContext> options) 
    : IdentityDbContext<User>(options)
{

}