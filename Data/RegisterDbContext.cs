using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using register.Entity;

namespace register.Data;

public class RegisterDbContext : IdentityDbContext<User>
{
    public RegisterDbContext(DbContextOptions<RegisterDbContext> options)
        : base(options) { }
}