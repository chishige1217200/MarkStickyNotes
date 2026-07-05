using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string ContentFileName { get; set; } = string.Empty;
        public string IssueTypeId { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
        public string StatusId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public string PriorityId { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string ColorId { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
