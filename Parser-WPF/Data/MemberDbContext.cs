
using Microsoft.EntityFrameworkCore;
using Parser_WPF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parser_WPF.Data
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<SearchMemberList> SearchMemberLists { get; set; }
        public DbSet<SearchMemberInfo> SearchMemberInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(GetProducts());

            modelBuilder.Entity<State>();
            modelBuilder.Entity<Country>();

            base.OnModelCreating(modelBuilder);
        }

        private Member[] GetProducts()
        {
            return new Member[]
            {
                new Member { Id = 1, PublicId = "204c5", Name = "Kristan Cheryl Cole", Email = "kristan@kristancole.com", Web = "http://www.kristancole.com/"},
                new Member { Id = 2, PublicId = "2722f", Name = "Mackie Derrick", Email = "mackierides@gmail.com", Web = "" },
                new Member { Id = 3, PublicId = "21fb7", Name = "Bryan Epley", Email = "bryan@bryanepley.com", Web = "http://www.girdwoodhomes.com/" },
                new Member { Id = 4, PublicId = "23a53", Name = "Julie  Erickson", Email = "julieericksonteam@gmail.com", Web = "http://www.callingalaskahome.com/" },
            };
        }
    }
}
