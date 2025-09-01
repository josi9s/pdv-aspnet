using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_pdv.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_pdv.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produto { get; set; }


    }
}