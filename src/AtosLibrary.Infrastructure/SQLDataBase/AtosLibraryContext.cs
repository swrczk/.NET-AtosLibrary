using AtosLibrary.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtosLibrary.Infrastructure.SQLDataBase
{
    public class AtosLibraryContext : DbContext
    {
        public AtosLibraryContext(DbContextOptions<AtosLibraryContext> option) : base(option) { }

        public virtual DbSet<BookEntity> Book { get; set; }
        public virtual DbSet<ReaderEntity> Reader { get; set; }
        public virtual DbSet<ReservationEntity> Reservation { get; set; }
        public virtual DbSet<BookItemEntity> BookItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookItemEntity>()
                .HasMany(e => e.ReservationEntities)
                .WithOne(e => e.BookItem)
                .HasForeignKey(e => e.BookItemId);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne(e => e.BookItem)
                .WithMany(e => e.ReservationEntities)
                .HasForeignKey(e => e.BookItemId);

            modelBuilder.Entity<ReaderEntity>()
                .HasMany(e => e.ReservationEntities)
                .WithOne(e => e.Reader)
                .HasForeignKey(e => e.ReaderId);

            modelBuilder.Entity<ReservationEntity>()
                .HasOne(e => e.Reader)
                .WithMany(e => e.ReservationEntities)
                .HasForeignKey(e => e.ReaderId);

            modelBuilder.Entity<BookEntity>()
                .HasMany(e => e.BookItems)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId);

            modelBuilder.Entity<BookItemEntity>()
                .HasOne(e => e.Book)
                .WithMany(e => e.BookItems)
                .HasForeignKey(e => e.BookId);
        }
    }
}
