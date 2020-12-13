using ContenManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContenManagementSystem.DAL
{
    public class LeftFooterContext:DbContext
    {
        public LeftFooterContext() : base("DefaultConnection") {}
        public DbSet<LeftFooterModel> leftFooterModel { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}