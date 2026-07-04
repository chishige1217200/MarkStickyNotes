using System;
using System.Collections.Generic;
using System.Text;

namespace MarkStickyNotes.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
