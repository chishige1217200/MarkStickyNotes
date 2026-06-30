using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes
{
    public class AppDbContext : DbContext
    {
        public DbSet<NoteItem> NoteItems => Set<NoteItem>();
        public DbSet<ColorItem> ColorItems => Set<ColorItem>();
        public DbSet<StatusItem> StatusItems => Set<StatusItem>();

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");
    }

    public class NoteItem
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string ColorId { get; set; } = string.Empty;
        public string StatusId { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.Date;
        public DateTime Updated { get; set; }
    }

    public class ColorItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ColorCode { get; set; } = string.Empty;
    }

    public class StatusItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
