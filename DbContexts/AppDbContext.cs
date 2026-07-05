using MarkStickyNotes.Entities;
using Microsoft.EntityFrameworkCore;
using Color = MarkStickyNotes.Entities.Color;

namespace MarkStickyNotes.DbContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes => Set<Note>();
        public DbSet<Color> Colors => Set<Color>();
        public DbSet<IssueType> IssueTypes => Set<IssueType>();
        public DbSet<Assignee> Assignees => Set<Assignee>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Priority> Priorities => Set<Priority>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color
                {
                    Id = 1,
                    Name = "Yellow",
                    ColorCode = "#D7AD04",
                    Order = 1
                },
                new Color
                {
                    Id = 2,
                    Name = "Green",
                    ColorCode = "#6FD262",
                    Order = 2
                },
                new Color
                {
                    Id = 3,
                    Name = "Pink",
                    ColorCode = "#EA86C2",
                    Order = 3
                },
                new Color
                {
                    Id = 4,
                    Name = "Purple",
                    ColorCode = "#C78EFF",
                    Order = 4
                },
                new Color
                {
                    Id = 5,
                    Name = "Blue",
                    ColorCode = "#5AC0E7",
                    Order = 5
                },
                new Color
                {
                    Id = 6,
                    Name = "Gray",
                    ColorCode = "#AAAAAA",
                    Order = 6
                },
                new Color
                {
                    Id = 7,
                    Name = "DarkGray",
                    ColorCode = "#4E4E4E",
                    Order = 7
                }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "未分類",
                    Order = 1
                }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Name = "未対応",
                    Order = 1
                },
                new Status
                {
                    Id = 2,
                    Name = "処理中",
                    Order = 2
                },
                new Status
                {
                    Id = 3,
                    Name = "処理済み",
                    Order = 3
                },
                new Status
                {
                    Id = 4,
                    Name = "完了",
                    Order = 4
                }
            );
        }
    }
}
