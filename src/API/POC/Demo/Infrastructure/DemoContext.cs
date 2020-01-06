using Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
               : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
