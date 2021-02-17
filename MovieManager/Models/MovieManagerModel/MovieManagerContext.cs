using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MovieManager.Models.MovieManagerModel
{
    public partial class MovieManagerContext : DbContext
    {
        public MovieManagerContext()
        {
        }

        public MovieManagerContext(DbContextOptions<MovieManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteUserMovie> FavouriteUserMovies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-43BN61N2;Initial Catalog=MovieManager2021;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FavouriteUserMovie>(entity =>
            {
                entity.Property(e => e.MovieId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavouriteUserMovies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__favourite__User___398D8EEE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FavoriteMovie).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
