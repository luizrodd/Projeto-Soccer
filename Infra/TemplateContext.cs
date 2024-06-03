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
        public DbSet<GameStatus> GameStatus { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.DisplayName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<User>().Property(p => p.Phone).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<User>().Property(p => p.isAdmin).IsRequired();

            //modelBuilder.Entity<Team>().HasKey(p => p.Id);
            //modelBuilder.Entity<Team>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //modelBuilder.Entity<Team>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            //modelBuilder.Entity<Team>().Property(p => p.Image);

            modelBuilder.Entity<News>().HasKey(p => p.Id);
            modelBuilder.Entity<News>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<News>().Property(p => p.Title).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<News>().Property(p => p.Description).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<News>().Property(p => p.Image);
            modelBuilder.Entity<News>().Property(p => p.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<News>().Property(p => p.Source).IsRequired();

            //modelBuilder.Entity<Game>().HasKey(p => p.Id);
            //modelBuilder.Entity<Game>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            //modelBuilder.Entity<Game>().Property(p => p.Place).IsRequired();
            //modelBuilder.Entity<Game>().Property(p => p.ResultTeamOne).HasMaxLength(2).IsRequired();
            //modelBuilder.Entity<Game>().Property(p => p.GameStatusId).IsRequired();
            //modelBuilder.Entity<Game>().Property(p => p.ResultTeamTwo).HasMaxLength(2).IsRequired();
            //modelBuilder.Entity<Game>().Property(p => p.ChampionshipId).IsRequired();

            modelBuilder.Entity<Championship>().HasKey(p => p.Id);
            modelBuilder.Entity<Championship>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Championship>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Championship>().Property(p => p.Image);
            modelBuilder.Entity<Championship>().Property(p => p.Rounds).HasMaxLength(2);

            #region Game_Relationship
            //modelBuilder.Entity<Game>()
            //    .HasOne(x => x.ChampionshipNav)
            //    .WithMany()
            //    .HasForeignKey(e => e.ChampionshipId);

            //modelBuilder.Entity<Game>()
            //    .HasOne(x => x.TeamOneNav)
            //    .WithMany(x => x.Games)
            //    .HasForeignKey(x => x.TeamOneId);

            //modelBuilder.Entity<Game>()
            //    .HasOne(x => x.TeamTwoNav)
            //    .WithMany(x => x.Games)
            //    .HasForeignKey(x => x.TeamTwoId);

            //modelBuilder.Entity<Game>()
            //    .HasOne(x => x.GameStatusNav)
            //    .WithMany()
            //    .HasForeignKey(x => x.GameStatusId);
            #endregion

            #region News_Relationship
            modelBuilder.Entity<News>()
                .HasOne(x => x.Team)
                .WithMany()
                .HasForeignKey(n => n.TeamId);
            #endregion


            modelBuilder.Entity<Game>()
              .HasOne(g => g.TeamOne)
              .WithMany(t => t.GamesOne) // Define navigation property name for TeamOne side
              .HasForeignKey(g => g.TeamOneId)
              .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if referenced by a Game

            modelBuilder.Entity<Game>()
              .HasOne(g => g.TeamTwo)
              .WithMany(t => t.GamesTwo) // Define navigation property name for TeamTwo side
              .HasForeignKey(g => g.TeamTwoId)
              .OnDelete(DeleteBehavior.Restrict); // Restrict deletion if referenced by a Game
        }


    }
}
