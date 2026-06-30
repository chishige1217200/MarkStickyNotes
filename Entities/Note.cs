using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string ColorId { get; set; } = string.Empty;
        public string StatusId { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime Created { get; set; } = DateTime.Now.Date;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
