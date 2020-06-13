using Microsoft.EntityFrameworkCore;
using QuotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesApi.Data
{
    public class PaymentsDbContext : DbContext
    {

        public DbSet<Payment> Payments { get; set; }

        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
    }
}