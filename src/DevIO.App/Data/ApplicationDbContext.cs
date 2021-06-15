using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DevIO.App.ViewModels;

namespace DevIO.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DevIO.App.ViewModels.ProductViewModel> ProductViewModel { get; set; }
        public DbSet<DevIO.App.ViewModels.SupplierViewModel> SupplierViewModel { get; set; }
        public DbSet<DevIO.App.ViewModels.AddressViewModel> AddressViewModel { get; set; }
    }
}
