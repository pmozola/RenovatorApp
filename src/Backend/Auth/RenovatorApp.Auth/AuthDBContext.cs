using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RenovatorApp.Auth;

public class AuthDBContext(DbContextOptions<AuthDBContext> options) : IdentityDbContext<IdentityUser>(options);