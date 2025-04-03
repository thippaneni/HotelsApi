using Hotels.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Persistent
{
    
    public class InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : DbContext(options)
    {
        public DbSet<Hotel> Hotels { get; set; }        
    }
}
