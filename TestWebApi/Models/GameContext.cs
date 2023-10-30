using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
