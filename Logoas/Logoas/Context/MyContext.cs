using Legoas.Models;
using Logoas.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Legoas.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.Email, ar.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(ar => ar.Email);
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(r => r.AccountRoles)
                .HasForeignKey(ar => ar.RoleId);

            //modelBuilder.Entity<Person>().ToTable("tb_tr_accounts");
            //modelBuilder.Entity<Account>().ToTable("tb_tr_accounts");

            modelBuilder.Entity<Member>()
                .HasOne<Account>(m => m.Account)
                .WithOne(a => a.Member)
                .HasForeignKey<Account>(a => a.Email);
            modelBuilder.Entity<AccountOffice>()
               .HasKey(ao => new { ao.Email, ao.OfficeId });
            modelBuilder.Entity<AccountOffice>()
                .HasOne(ao => ao.Account)
                .WithMany(a => a.AccountOffices)
                .HasForeignKey(ao => ao.Email);
            modelBuilder.Entity<AccountOffice>()
                .HasOne(ao => ao.Office)
                .WithMany(o => o.AccountOffices)
                .HasForeignKey(ao => ao.OfficeId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<AccountOffice> AccountOffices { get; set; }

    }
}
    