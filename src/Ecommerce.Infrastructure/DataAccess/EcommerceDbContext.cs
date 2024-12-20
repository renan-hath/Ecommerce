﻿using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.DataAccess
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }
    }
}
