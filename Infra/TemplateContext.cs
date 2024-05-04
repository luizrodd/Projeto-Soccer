using APIzinha.Entitites;
using Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Infra
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.DisplayName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Ignore(u => u.Password);
            modelBuilder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.isAdmin).IsRequired();

            modelBuilder.Entity<Team>().HasKey(p => p.Id);
            modelBuilder.Entity<Team>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Team>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Team>().Property(p => p.Image);

            modelBuilder.Entity<News>().HasKey(p => p.Id);
            modelBuilder.Entity<News>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<News>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<News>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<News>().Property(p => p.Image);
            modelBuilder.Entity<News>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<News>().Property(p => p.Source).IsRequired();

            modelBuilder.Entity<Game>().HasKey(p => p.Id);
            modelBuilder.Entity<Game>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Game>().Property(p => p.Place).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.ResultTeamOne).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.GameStatus).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.ResultTeamTwo).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.ChampionshipId).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.TeamOne).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.TeamTwo).IsRequired();

            modelBuilder.Entity<Championship>().HasKey(p => p.Id);
            modelBuilder.Entity<Championship>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Championship>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Championship>().Property(p => p.Image);
            modelBuilder.Entity<Championship>().Property(p => p.Rounds).HasMaxLength(2);

            modelBuilder.Entity<Championship>()
                .HasMany(x => x.GamesList)
                .WithOne()
                .HasForeignKey(e => e.ChampionshipId);

            modelBuilder.Entity<Championship>()
               .HasMany(x => x.TeamsList)
               .WithOne()
               .HasForeignKey(e => e.ChampionshipId);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.TeamOne)
                .WithOne()
                .HasForeignKey<Team>(x => x.Id);

            modelBuilder.Entity<Game>()
              .HasOne(x => x.TeamTwo)
              .WithOne()
              .HasForeignKey<Team>(x => x.Id);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.GameStatus)
                .WithOne();

            modelBuilder.Entity<Team>()
                .HasMany(x => x.NewsList)
                .WithOne()
                .HasForeignKey(x => x.TeamId);

        }
    }
}
